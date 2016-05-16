using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class TestSelected : MonoBehaviour, ISelectHandler, IDeselectHandler {
    public void OnDeselect (BaseEventData eventData) {
        Debug.Log ("Deselected " + gameObject.name, gameObject);
    }

    public void OnSelect (BaseEventData eventData) {
        Debug.Log ("Selected " + gameObject.name, gameObject);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
