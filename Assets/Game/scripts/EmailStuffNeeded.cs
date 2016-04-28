using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EmailStuffNeeded : MonoBehaviour {

    //Email Variables
    public InputField inputFieldEmail;
    public Text emailAddressText, placeHolderText;



    public void sendMailPressed()
    {
        GetComponent<email>().sendMail(emailAddressText.text, "Screenshot.png");
        emailAddressText.text = "";
        inputFieldEmail.text = "";
        
    }

    public void EraseText()
    {
        if (placeHolderText.text != "")
            placeHolderText.text = "";
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        Application.Quit();
    }
}

