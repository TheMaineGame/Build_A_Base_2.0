using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    public bool GameDone;
    public bool takingPicture;

    [SerializeField] Text countDownTimer;
    [SerializeField]
    GameObject GameOverGO;
    [SerializeField]
    GameObject MainCanvas;
    [SerializeField]
    Image fillamount, overlayColor;
    [SerializeField]
    GameObject TimerCanvas;
    [SerializeField]
    GameObject SnapShot;
    [SerializeField]
    GameObject SliderCanvas;

    

	// Use this for initialization
	void Awake () {
        Time.timeScale = 1;
        
        
	}
	
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(CountDown());
        }
        Debug.Log(Time.timeSinceLevelLoad);
        fillamount.fillAmount += Time.deltaTime / 60;
    }

    public void GameOver()
    {
        MainCanvas.SetActive(false);
        GameDone = true;
        SnapShot.SetActive(false);
        TimerCanvas.SetActive(false);
        SliderCanvas.SetActive(false);
        GameOverGO.SetActive(true);
    }

    IEnumerator CountDown()
    {
        int timer = 60;
        while (timer > 0)
		{
			countDownTimer.transform.localScale = Vector3.one * 1.3f;
            countDownTimer.gameObject.ScaleTo(Vector3.one, 0.9f, 0f, EaseType.linear) ;

            if (timer == 40)
            {
                overlayColor.color = Color.yellow;
                countDownTimer.color = Color.yellow;
            }
            if(timer == 20)
            {
                overlayColor.color = Color.red;
                countDownTimer.color = Color.red;
            }
            timer--;
            countDownTimer.text = timer.ToString();
            yield return new WaitForSeconds(1);
        }
        if (takingPicture == false)
        {
            GameOver();
        }
    }
}
