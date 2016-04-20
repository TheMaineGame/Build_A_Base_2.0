using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gestures : MonoBehaviour {

	[SerializeField]
	Image pointer;
	[SerializeField]
	Image bbBoard;

	void Update()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			pointer.enabled = false;
			bbBoard.enabled = false;
		}
	}
}
