using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class TapRotation : MonoBehaviour, IPointerClickHandler, IBeginDragHandler {
    bool dragged = false;

    public void OnBeginDrag (PointerEventData eventData) {
        dragged = true;
    }

    public void OnPointerClick (PointerEventData eventData) {
        if (!dragged) {
            gameObject.transform.rotation *= Quaternion.Euler (0, 90, 0);
        }
        dragged = false;
    }

    

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}
