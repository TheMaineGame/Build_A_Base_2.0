using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundController : MonoBehaviour {
    [SerializeField] Sprite MusicOn;
    [SerializeField] Sprite MusicOff;
    

	public void Sound () 
	{
		if (AudioListener.volume == 0)
        {
            AudioListener.volume = 1;
            AudioListener.pause = false;
            gameObject.GetComponent<Image>().sprite = MusicOn;
        }
        else
        {
            AudioListener.volume = 0;
            AudioListener.pause = true;
            gameObject.GetComponent<Image>().sprite = MusicOff;
        }
	}
}
