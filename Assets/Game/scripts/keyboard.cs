using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class keyboard : MonoBehaviour {
	[SerializeField]
    InputField field;

	
	public void Press() {


        Text child = GetComponentsInChildren<Text> (               )[0];

		Debug.Log (child.text);
		if (child.text == "<-") {
			field.text = field.text.Remove (field.text.Length - 1);
		} else {
		field.text += "" + child.text;
			
		}
	}

	public void clear(){
		field.text = "";

	}
}
