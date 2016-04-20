using UnityEngine;
using System.Collections;

public class CreateATim : MonoBehaviour {

	void Start()
    {
        if (Random.value <= 0.4f)
        {
            int numberOfTims = Random.Range(1, 3);
            for (int i = 0; i < numberOfTims; i++)
            {
                GameObject tim = Instantiate(Resources.Load("TimBot", typeof(GameObject))) as GameObject;
                tim.transform.position = transform.position;
            }
        }
    }
}
