using UnityEngine;
using System.Collections;

public class Spinner : MonoBehaviour {

    // literally the most useless script in the history of ever
    // just spin a thing

    [SerializeField] float[] rotationSpeeds;

	void FixedUpdate()
    {
        gameObject.transform.Rotate(new Vector3(rotationSpeeds[0]*Time.deltaTime, rotationSpeeds[1] * Time.deltaTime, rotationSpeeds[2] * Time.deltaTime));
    }
}
