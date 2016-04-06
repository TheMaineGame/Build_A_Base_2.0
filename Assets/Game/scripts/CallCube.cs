using UnityEngine;
using System.Collections;

public class CallCube : MonoBehaviour
{
    [SerializeField]
    GameObject m_livingQuarters;
    [SerializeField]
    Transform cameraPos;
    [SerializeField]
    LayerMask buildings;

    public void CubeCall()
    {
        var pos = new Vector3 (
            Mathf.Round (cameraPos.position.x),
            Mathf.Round (cameraPos.position.y),
            Mathf.Round (cameraPos.position.z)
            );
        if (!Physics.CheckBox (
            pos,
            m_livingQuarters.GetComponent<BoxCollider>().bounds.extents,
            m_livingQuarters.transform.rotation,
            buildings)
            ) {
            GameObject poop = Instantiate (m_livingQuarters, pos, Quaternion.identity) as GameObject;
        }
        else {

        }
    }
}