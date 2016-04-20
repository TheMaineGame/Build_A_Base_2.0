using UnityEngine;
using System.Collections;

public class ScreenshotTHIS : MonoBehaviour {

    [SerializeField]
    GameObject Canvas;
    [SerializeField]
    GameObject input;
    [SerializeField]
    GameObject Image;
    [SerializeField]
    GameObject GameOver;
    [SerializeField]
    GameObject ConfirmButtons;


    [SerializeField]
    GameObject Slider;
    [SerializeField]
    GameObject CameraImage;

    [SerializeField]
    CameraControll customCamera;

    AudioSource AS;

    void Start()
    {
        AS = GetComponent<AudioSource>();

    }

    public void OnClick ()
    {
        Canvas.SetActive(false);
        GameOver.SetActive(false);
        gameObject.GetComponent<GameTimer>().takingPicture = true;
        Slider.SetActive(true);
        CameraImage.SetActive(false);
        ConfirmButtons.SetActive(true);
	}

    public void TakePicture()
    {
        Slider.SetActive(false);
        ConfirmButtons.SetActive(false);
        Application.CaptureScreenshot("Screenshot.png");
        StartCoroutine("Enable");
        customCamera.enabled = false;
    }

    IEnumerator Enable()
    {
        yield return new WaitForSeconds(0.5f);
        AS.Play();
        Image.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Image.SetActive(false);
        yield return new WaitForSeconds(0.45f);
        input.SetActive(true);
        
    }
}
