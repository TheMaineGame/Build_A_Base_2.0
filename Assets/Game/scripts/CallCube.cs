using UnityEngine;
using System.Collections;

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
        var stepVec = Vector3.forward;
        var buildingExtents = m_livingQuarters.GetComponent<BoxCollider> ().bounds.extents;
        if (!Physics.CheckBox (
            pos,
            buildingExtents,
            m_livingQuarters.transform.rotation,
            buildings
            )) {
            for (var segmentLength = 1; true; segmentLength++) {
                for (var corners = 0; corners < 2; corners++) {
                    for (var step = 1; step < segmentLength; step++) {
                        offset += stepVec;
                        if (!Physics.CheckBox (
                            pos + offset,
                            m_livingQuarters.GetComponent<BoxCollider> ().bounds.extents,
                            m_livingQuarters.transform.rotation,
                            buildings)) {
                            goto Exit;
                        }
                    }
                    stepVec = new Vector3 (-stepVec.y, stepVec.x, 0);
                }
            }
        }
    Exit:
        Instantiate (m_livingQuarters, pos + offset, Quaternion.identity);
    }
}