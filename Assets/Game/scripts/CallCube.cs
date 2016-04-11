using UnityEngine;
using System;

public class CallCube : MonoBehaviour {
    [SerializeField]
    GameObject m_livingQuarters;
    [SerializeField]
    Transform cameraPos;
    [SerializeField]
    LayerMask buildings;

    public void CubeCall () {
        var pos = new Vector3 (
            Mathf.Round (cameraPos.position.x),
            Mathf.Round (cameraPos.position.y),
            Mathf.Round (cameraPos.position.z)
            );
        var offset = Vector3.zero;
        var buildingExtents = m_livingQuarters.GetComponent<BoxCollider> ().bounds.extents;
        Func<Vector3, bool> check = (Vector3 off) => Physics.CheckBox (
            pos + off,
            buildingExtents,
            m_livingQuarters.transform.rotation,
            buildings);
        bool intersecting = check (offset);
        var stepVec = Vector3.forward;
        var lenSide = 0;
        while (intersecting) {
            var turnCount = 0;
            while (intersecting && turnCount < 2) {
                var stepCount = 0;
                while (intersecting && stepCount < lenSide) {
                    offset += stepVec;
                    intersecting = check (offset);
                    stepCount++;
                }
                stepVec.Set (stepVec.z, 0, -stepVec.x);
                turnCount++;
            }
            lenSide++;
        }
        var building = Instantiate (m_livingQuarters);
        building.transform.position = pos + offset;
    }
}