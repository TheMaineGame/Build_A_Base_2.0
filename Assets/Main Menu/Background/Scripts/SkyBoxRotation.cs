using UnityEngine;
using System.Collections;

public class SkyBoxRotation : MonoBehaviour {

    [SerializeField]
    float rotationSpeed;

    float rotation;

    void Update()
    {
        rotation += rotationSpeed * Time.deltaTime;

        if (rotation == 0 && rotation < 0)
        {
            rotation = 360;
        } else if (rotation == 360 && rotation > 0)
        {
            rotation = 0;
        }

        RenderSettings.skybox.SetFloat("_Rotation", rotation);
    }

}
