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
    Image fillamount, overlayColor;

    

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
        GameOverGO.SetActive(true);
    }

    IEnumerator CountDown()
    {
        countDownTimer.gameObject.ScaleTo(Vector3.zero, 0.5f, 0f, EaseType.linear, LoopType.pingPong);
        int timer = 0;
        while (timer < 100)
        {
            
            if (timer == 41)
            {
                overlayColor.color = Color.yellow;
                countDownTimer.color = Color.yellow;
            }
            if(timer == 21)
            {
                overlayColor.color = Color.red;
                countDownTimer.color = Color.red;
            }
            timer++;
            countDownTimer.text = timer.ToString();
            yield return new WaitForSeconds(1);
        }
        GameOver();
    }
}
