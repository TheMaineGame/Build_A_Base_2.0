using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {

    [SerializeField]
    GameObject ground;

    float groundSizeClamp;

    Vector3 Pos;

    void Start()
    {
        groundSizeClamp = (ground.transform.localScale.x)/2;
    }

    void Update()
    {
        Pos = transform.position;
        Pos.x = Mathf.Clamp(transform.position.x,-groundSizeClamp + ground.transform.position.x, groundSizeClamp + ground.transform.position.x);
        Pos.z = Mathf.Clamp(transform.position.z, -groundSizeClamp + ground.transform.position.z, groundSizeClamp + ground.transform.position.z);
        transform.position = Pos;
    }
}
