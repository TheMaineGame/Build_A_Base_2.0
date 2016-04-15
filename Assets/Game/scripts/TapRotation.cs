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
        var bounds = box.bounds;
        var i = 0;
        box.enabled = false;
        do {
            gameObject.transform.rotation *= Quaternion.Euler (0, 90, 0);
            i++;
        } while (i < 4
            && Physics.CheckBox (
                bounds.center,
                bounds.extents,
                Quaternion.identity,
                buildingLayer)
            );
        box.enabled = true;
    }

    void Start() {
        box = gameObject.GetComponent<BoxCollider> ();
    }
}
