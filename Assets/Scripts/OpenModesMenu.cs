using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenModesMenu : MonoBehaviour
{
    public GameObject menuWindow;

    public void OpenMenu()
    {
        menuWindow.SetActive(true);
    }
}
