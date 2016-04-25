using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

/// <summary>
/// Used to drag and drop the buildings.
/// </summary>
public class DragNDrop : MonoBehaviour, IDragHandler {
    [SerializeField]
    LayerMask floor;
    [SerializeField]
    LayerMask buildings;

    BoxCollider box;

    public void Start() {
        box = GetComponent<BoxCollider> ();
    }

    public void OnDrag (PointerEventData eventData) {
        // Assembling important variables to be accessed by shorter names
        var worldPos = eventData.pointerCurrentRaycast.worldPosition;
        var screenPos = eventData.pointerCurrentRaycast.screenPosition;
        var cam = eventData.pressEventCamera;

        // Change the position of the origin to world space for ray calculation
        var pointerPos = cam.ScreenToWorldPoint (screenPos);
        
        // Create a ray to calculate new point on floor
        var toFloor = new Ray (pointerPos, worldPos - pointerPos);

        RaycastHit hit;
        // Debug.DrawRay (pointerPos, worldPos - pointerPos);
        if (Physics.Raycast (toFloor, out hit, 10000, floor)) {
            var point = hit.point;
            var snapped = new Vector3 (Mathf.Round (point.x), Mathf.Round (point.y), Mathf.Round (point.z));
            var offset = snapped - gameObject.transform.position;
            var extents = box.bounds.extents;
            var center = gameObject.transform.rotation * box.center;
            // Debug.Log("Checking point " + (snapped + center) + ", extents " + extents);
            box.enabled = false;
            // Debug.Log ("Box.enabled is " + box.enabled);
            // var colliders = Physics.OverlapBox (snapped + center, extents, Quaternion.identity, buildings);
            // foreach (var c in colliders)
                // Debug.Log ("Overlapping: " + c);
            if (!Physics.CheckBox(snapped + center, extents, Quaternion.identity, buildings))
                gameObject.transform.position = snapped;
            box.enabled = true;
        }
    }
}
