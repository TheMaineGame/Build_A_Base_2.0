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
        pos = start;
        this.transform.localPosition = new Vector3(0, start, 0);
    }

    public void ResetPos()
    {
        pos = start;
        this.transform.localPosition = new Vector3(0, start, 0);
    }

	void Update () {
        if(this.transform.localPosition.y >= 2000)
        {
            ResetPos();
        }
        pos += (Time.deltaTime * speed);

        this.transform.localPosition = new Vector3(0,pos,0);
	}
}
