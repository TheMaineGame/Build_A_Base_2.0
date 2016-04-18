using UnityEngine;
using System.Collections;

public class MenuSystem : MonoBehaviour {

    [SerializeField]
    GameObject[] menus;

    int whichMenu = 0;

    void Start()
    {
        Invoke("switchMenus", 0.01f);
    }

    public void menu()
    {
        whichMenu = 0;
        switchMenus();
    }

    public void Help()
    {
        whichMenu = 1;
        switchMenus();
    }

    public void Credits()
    {
        whichMenu = 2;
        switchMenus();
    }

    void switchMenus()
    {
        foreach(GameObject obj in menus)
        {
            obj.SetActive(false);
        }

        menus[whichMenu].SetActive(true);
    }
}
