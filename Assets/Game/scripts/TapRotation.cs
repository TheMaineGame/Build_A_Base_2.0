using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class TapRotation : MonoBehaviour, IPointerClickHandler, IBeginDragHandler {
    bool dragged = false;
    bool rotating = false;
    BoxCollider box;

    [SerializeField]
    LayerMask buildingLayer;

    [SerializeField]
    LayerMask ghostLayer;

    [SerializeField]
    float riseUnitsPerSec = 1;

    [SerializeField]
    float rotationDuration = 1;

    [SerializeField]
    float lowerUnitsPerSec = 1;

    [SerializeField]
    float levitateHeight = 3;

    [Tooltip ("Optional")]
    [SerializeField]
    UnityEvent cantRotate;

    public void OnBeginDrag (PointerEventData eventData) {
        dragged = true;
    }

    public void OnPointerClick (PointerEventData eventData) {
        if (!dragged && !rotating) {
            Rotate ();
        }
        dragged = false;
    }

    void Rotate () {
        var origBounds = box.bounds;
        Bounds bounds = box.bounds;
        var i = 0;
        bool intersect = false;
        var check = Quaternion.identity;
        var point = gameObject.transform.position;
        do {
            check *= Quaternion.Euler (0, 90, 0);
            box.enabled = false;
            var center = (check * (bounds.center - point)) + point;
            intersect = Physics.CheckBox (
                center,
                bounds.extents,
                check,
                buildingLayer);
            box.enabled = true;
            //Debug.Log ("Intersecting: " + intersect);
            //Debug.Log ("Center: " + center);
            //Debug.Log ("Extents: " + check * bounds.extents);
            i++;
        } while (i < 4 && intersect);
        if (i == 4) {
            cantRotate.Invoke ();
        }
        else {
            StartCoroutine (RotateCoroutine (check * gameObject.transform.rotation));
        }
        AstarPath.active.UpdateGraphs(box.bounds);
        AstarPath.active.UpdateGraphs(origBounds);
    }

    IEnumerator RotateCoroutine (Quaternion newRot) {
        rotating = true;
        // Variable setup
        var time = 0f;
        var oPos = gameObject.transform.position; // for "orginal position"
        var newPos = gameObject.transform.position + Vector3.up * levitateHeight;
        var riseTime = levitateHeight / riseUnitsPerSec;
        var ghost = new GameObject (gameObject.name + " ghost", typeof (BoxCollider));
        { // Scope for creating the ghost, so unnecessary variables get GC'd
            ghost.transform.position = oPos;
            ghost.transform.rotation = newRot;
            if (!Mathf.IsPowerOfTwo (ghostLayer.value))
                throw new ArgumentException ("Ghost layer mask is not a single layer");
            ghost.layer = (int) Mathf.Log(ghostLayer.value,2);
            var ghostbox = ghost.GetComponent<BoxCollider> ();
            ghostbox.size = box.size;
            ghostbox.center = box.center;
        }
        // Rising
        while (time < riseTime) {
            time += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp (oPos, newPos, time / riseTime);
            yield return null;
        }
        time = 0;
        // Rotating
        var oRot = gameObject.transform.rotation;
        while (time < rotationDuration) {
            time += Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Slerp (oRot, newRot, time / rotationDuration);
            yield return null;
        }
        time = 0;
        // Lowering
        var lowTime = levitateHeight / lowerUnitsPerSec;
        while (time < lowTime) {
            time += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp (newPos, oPos, time / lowTime);
            yield return null;
        }
        Destroy (ghost);
        rotating = false;
    }

    void Start () {
        box = gameObject.GetComponent<BoxCollider> ();
    }
}
