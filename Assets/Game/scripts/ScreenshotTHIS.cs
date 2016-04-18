using UnityEngine;
using System.Collections;

public class ScreenshotTHIS : MonoBehaviour {

    [SerializeField]
    GameObject Canvas;
    [SerializeField]
    GameObject input;
    [SerializeField]
    GameObject Image;

    AudioSource AS;

    void Start()
    {
        AS = GetComponent<AudioSource>();
    }

    public void OnClick ()
    {
        Canvas.SetActive(false);
        Application.CaptureScreenshot("Screenshot.png");
        StartCoroutine("Enable");
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
        Canvas.SetActive(true);

    }
}
