using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MagicAnimationScript : MonoBehaviour {

    [SerializeField]
	private Animator CameraAnimator;
    [SerializeField]
	private Animator CanvasAnimator;
    [SerializeField]
	private Animator filler;
    [SerializeField]
	private GameObject FakeLoadingScreen;

    int Count;

    public void TriggerStart()
    {
        CameraAnimator.SetTrigger("DiveIn");
        CanvasAnimator.SetTrigger("GoClicked");
        StartCoroutine("FakeTheLoadingScreen");
    }

    public void TriggerQuit()
    {
        CanvasAnimator.SetTrigger("QuitClicked");
        StartCoroutine(QuitCoroutine());
    }

    IEnumerator QuitCoroutine()
    {
        yield return new WaitForSeconds(3);
        Application.Quit();
    }

    IEnumerator FakeTheLoadingScreen()
    {
        StartCoroutine("TriggerLoadBar");
        yield return new WaitForSeconds(8);
		SceneManager.LoadScene (1);
    }

    IEnumerator TriggerLoadBar()
    {
        yield return new WaitForSeconds(3.5f);
        FakeLoadingScreen.SetActive(true);
        filler.SetTrigger("DiveIn");
    }
}
