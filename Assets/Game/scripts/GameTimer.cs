using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    [SerializeField] Text countDownTimer;
    [SerializeField]
    GameObject GameOverGO;
    [SerializeField]
    GameObject MainCanvas;

    [SerializeField]
    Image fillamount;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        StartCoroutine(CountDown());
	}
	
    public void Update()
    {
        fillamount.fillAmount += Time.deltaTime / 60;
    }

    public void GameOver()
    {
        MainCanvas.SetActive(false);
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
        GameOver();
    }
}
