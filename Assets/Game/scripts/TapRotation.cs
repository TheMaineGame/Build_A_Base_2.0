using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class TapRotation : MonoBehaviour, IPointerClickHandler, IBeginDragHandler {
    bool dragged = false;
    BoxCollider box;

    [SerializeField]
    LayerMask buildingLayer;

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
        var origBounds = box.bounds;
        Bounds bounds;
        var i = 0;
        bool intersect = false;
        do {
            gameObject.transform.rotation *= Quaternion.Euler (0, 90, 0);
            bounds = box.bounds;
            box.enabled = false;
            //var colliders = Physics.OverlapBox (
            //    bounds.center,
            //    bounds.extents,
            //    Quaternion.identity,
            //    buildingLayer);
            intersect = Physics.CheckBox (
                bounds.center,
                bounds.extents,
                Quaternion.identity,
                buildingLayer);
            box.enabled = true;
            //Debug.Log ("Intersecting: " + intersect);
            //if (intersect) {
            //    foreach (var c in colliders) {
            //        Debug.Log (c);
            //    }
            //}
            //Debug.Log ("Bounds: " + bounds);
            i++;
        } while (i < 4
            && intersect);
        AstarPath.active.UpdateGraphs(box.bounds);
        AstarPath.active.UpdateGraphs(origBounds);
    }

    void Start() {
        box = gameObject.GetComponent<BoxCollider> ();
    }
}
