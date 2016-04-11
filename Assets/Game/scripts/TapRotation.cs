using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class TapRotation : MonoBehaviour, IPointerClickHandler {
    public void OnPointerClick (PointerEventData eventData) {
        gameObject.transform.rotation *= Quaternion.Euler (0, 90, 0);
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }
}
