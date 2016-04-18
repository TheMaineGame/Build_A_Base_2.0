using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net.Sockets;

public class email : MonoBehaviour {

    public GameObject invalidText, validText, GameOver, snapShot;

    void Awake()
    {
        Time.timeScale = 1f;
    }

	public void sendMail(string address, string fileName)
	{
		try
		{
            MailMessage mail = new MailMessage();
			
			mail.From = new MailAddress("BAB@mainegame.club");
			mail.To.Add(address);
			mail.Subject = "Build-a-Base";
			mail.Body = "Your Finished Base";

			string thing = "New Unity Project 2_Data/";
			#if UNITY_EDITOR
			thing = "";
			#endif

			mail.Attachments.Add (new Attachment (thing + fileName));
			
			SmtpClient smtpServer = new SmtpClient("smtp.themainegame.com");
			smtpServer.Port = 587;
			smtpServer.Credentials = new System.Net.NetworkCredential("broakes@themainegame.com", "THEmainegame1!") as ICredentialsByHost;
			smtpServer.EnableSsl = true;
			ServicePointManager.ServerCertificateValidationCallback = 
				delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) 
			{ return true; };
			smtpServer.Send(mail);
			validText.SetActive(true);
            StartCoroutine(QueEnd());

            
		}

        catch (Exception e)
		{
            validText.SetActive(true);
            StartCoroutine(QueEnd());
        }
	}

    IEnumerator QueEnd()
    {
        yield return new WaitForSeconds(2f);
        snapShot.SetActive(false);
        GameOver.SetActive(true);
        Time.timeScale = 0.0f;
        //disable user controls

    }

}
