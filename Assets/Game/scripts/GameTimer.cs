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
    Image fillamount;

	// Use this for initialization
	void Start () {
        Time.timeScale = 2;
        StartCoroutine(CountDown());
	}
	
    public void Update()
    {
        fillamount.fillAmount += Time.deltaTime / 60;
    }

    public void GameOver()
    {
        MainCanvas.SetActive(false);
        GameDone = true;   
        GameOverGO.SetActive(true);
    }

    IEnumerator CountDown()
    {
        int timer = 60;
        while (timer > 0)
        {
            if (timer == 41)
            {
                countDownTimer.color = Color.yellow;
            }
            if(timer == 21)
            {
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
