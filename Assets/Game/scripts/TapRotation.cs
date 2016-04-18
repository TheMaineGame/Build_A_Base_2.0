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
        } while (i < 4
            && intersect);
    }

    void Start() {
        box = gameObject.GetComponent<BoxCollider> ();
    }
}
