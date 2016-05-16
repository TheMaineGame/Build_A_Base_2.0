using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour {
    [SerializeField] Sprite MusicOn;
    [SerializeField] Sprite MusicOff;

    [SerializeField] AudioMixer Mixer;

    float measure;

    public void Sound () 
	{
        
        Mixer.GetFloat("Master Volume Slider", out measure);

        if (measure < 0f )
        {
            Mixer.SetFloat("Master Volume Slider", 0f);
            gameObject.GetComponent<Image>().sprite = MusicOn;
        }
        else
        {
            Mixer.SetFloat("Master Volume Slider", -80f);
            gameObject.GetComponent<Image>().sprite = MusicOff;
        }
	}
}
