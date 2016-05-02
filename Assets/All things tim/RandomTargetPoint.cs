using UnityEngine;
using System.Collections;

public class RandomTargetPoint : MonoBehaviour {

    public float radius;

    public float maxTime;

    float Timer;

    void Start()
    {
        Timer = Random.Range(1, maxTime);
        pickPoint();
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        {
            pickPoint();
        }
    }


    void pickPoint()
    {
        transform.position = Random.insideUnitSphere * radius;
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        Timer = Random.Range(1, maxTime);
    }
}
