using UnityEngine;
using System.Collections;

public class CallCube : MonoBehaviour 
{
	[SerializeField]GameObject m_livingQuarters;

	public void CubeCall () 
	{
		m_livingQuarters.SetActive (true);
	}
}
