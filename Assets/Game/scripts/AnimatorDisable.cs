using UnityEngine;
using System.Collections;

public class AnimatorDisable : MonoBehaviour {

    [SerializeField]
    Animator anim;

    public void animDone()
    {
        anim.enabled = false;
    }
}
