using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class TapRotation : MonoBehaviour, IPointerClickHandler, IBeginDragHandler {
    bool dragged = false;
    BoxCollider box;

    [SerializeField]
    LayerMask buildingLayer;

    [Tooltip ("Optional")]
    [SerializeField]
    ParticleSystem CantDoThatParticles;

    [SerializeField]
    float riseUnitsPerSec = 1;

    [SerializeField]
    float rotationDuration = 1;

    [SerializeField]
    float lowerUnitsPerSec = 1;

    [SerializeField]
    float levitateHeight = 3;

    public void OnBeginDrag (PointerEventData eventData) {
        dragged = true;
    }

    public void OnPointerClick (PointerEventData eventData) {
        if (!dragged) {
            Rotate ();
        }
        dragged = false;
    }

    void Rotate () {
        Bounds bounds;
        var i = 0;
        bool intersect = false;
        do {
            gameObject.transform.rotation *= Quaternion.Euler (0, 90, 0);
            bounds = box.bounds;
            box.enabled = false;
            intersect = Physics.CheckBox (
                bounds.center,
                bounds.extents,
                Quaternion.identity,
                buildingLayer);
            box.enabled = true;
            // Debug.Log ("Intersecting: " + intersect);
            // Debug.Log ("Bounds: " + bounds);
            i++;
        } while (i < 4 && intersect);
        if (i == 4) {
            CantDoThatParticles.Emit (1);
        }
        else {

        }
    }

    IEnumerator RotateCoroutine (Quaternion newRot) {
        var time = 0f;
        var oPos = gameObject.transform.position; // for "orginal position"
        var newPos = gameObject.transform.position + Vector3.up * levitateHeight;
        var riseTime = riseUnitsPerSec * levitateHeight;
        while (time < riseTime) {
            time += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp (oPos, newPos, time / riseTime);
            yield return null;
        }
        time = 0;
        var oRot = gameObject.transform.rotation;
        while (time < rotationDuration) {
            time += Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Lerp (oRot, newRot, time / rotationDuration);
            yield return null;
        }
        time = 0;
        var lowTime = lowerUnitsPerSec * levitateHeight;
        while (time < lowTime) {
            time += Time.deltaTime;
            gameObject.transform.position = Vector3.Lerp (newPos, oPos, time / lowTime);
            yield return null;
        }
    }

    void Start () {
        box = gameObject.GetComponent<BoxCollider> ();
    }
}
