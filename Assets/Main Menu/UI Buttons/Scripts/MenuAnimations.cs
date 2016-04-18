using UnityEngine;
using System.Collections;

public class MenuAnimations : MonoBehaviour {

    [SerializeField]
    Animator Menu;
    [SerializeField]
    Animator Camera;
    [SerializeField]
    Animator Fade;

    public void StartFade()
    {
        Menu.SetTrigger("Trigger");
    }

    public void MoveCamera()
    {
        Camera.SetTrigger("Trigger");
    }

    public void FadeToRed()
    {
        Fade.SetTrigger("Trigger");
    }

}
