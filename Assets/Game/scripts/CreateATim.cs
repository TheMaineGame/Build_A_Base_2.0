using UnityEngine;
using System.Collections;

public class CreateATim : MonoBehaviour {

	void Start()
    {
        if (Random.value <= 0.4f)
        {
            GameObject tim = Instantiate(Resources.Load("TimBot", typeof(GameObject))) as GameObject;
            tim.transform.position = transform.position;
        }
    }
}
