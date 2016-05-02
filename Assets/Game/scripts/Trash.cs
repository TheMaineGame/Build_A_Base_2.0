using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class Trash : MonoBehaviour, IDropHandler {
    public void OnDrop (PointerEventData eventData) {
        Destroy (eventData.pointerDrag);
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}
