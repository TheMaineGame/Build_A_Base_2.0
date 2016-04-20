using UnityEngine;
using System.Collections;

public class ConfimButtons : MonoBehaviour {

    [SerializeField]
    GameObject pokemon;

    public void Confirm()
    {
        pokemon.GetComponent<ScreenshotTHIS>().TakePicture();
    }
}
