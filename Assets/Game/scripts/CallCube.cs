using UnityEngine;
using System.Collections;

public class CallCube : MonoBehaviour
{
    [SerializeField]
    GameObject m_livingQuarters;

    [SerializeField]
    Transform cameraPos;

    public void CubeCall()
    {
        GameObject poop = Instantiate(m_livingQuarters);
        poop.transform.position = new Vector3(Mathf.Round(cameraPos.position.x), Mathf.Round(cameraPos.position.y), Mathf.Round(cameraPos.position.z));
    }
}