using UnityEngine;
using System.Collections;

public class DevAcessCode : MonoBehaviour {

    [SerializeField]
    GameObject pokemon;

	void Update ()
    {
        if (Input.GetKeyDown("d"))
        {
            pokemon.GetComponent<GameTimer>().GameOver();
        }	
	}
}
