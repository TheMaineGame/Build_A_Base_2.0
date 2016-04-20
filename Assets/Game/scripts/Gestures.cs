using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gestures : MonoBehaviour {

	[SerializeField]
	Image pointer;
	[SerializeField]
	Image bbBoard;
	[SerializeField]
	GameObject gameOver;

	public Animator anim;
	public float gestureTime = 0f;

	void Start ()
	{
		pointer.enabled = false;
		bbBoard.enabled = false;
	}
	void FixedUpdate()
	{
		gestureTime++;
	}
	void Update()
	{
		if (gestureTime >= 240f) 
		{
			pointer.enabled = true;
			bbBoard.enabled = true;
		}
		if (Input.GetButtonDown ("Fire1")) 
		{
			gestureTime = 0f;
			pointer.enabled = false;
			bbBoard.enabled = false;
		}
		if (gameOver.activeSelf) 
		{
			pointer.enabled = false;
			bbBoard.enabled = false;
		}
	}
}
