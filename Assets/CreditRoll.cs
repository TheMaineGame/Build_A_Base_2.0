using UnityEngine;
using System.Collections;

public class CreditRoll : MonoBehaviour {

    [SerializeField]
    float speed;

    float pos;

    float start;

    void Start()
    {
        start = this.gameObject.transform.localPosition.y;
    }

    void OnEnable()
    {
        pos = start;
    }

	void Update () {
        pos += (Time.deltaTime * speed);

        this.transform.localPosition = new Vector3(0,pos,0);
	}
}
