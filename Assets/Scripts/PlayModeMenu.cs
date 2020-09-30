using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayModeMenu : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject menuWindow;

    public void EasyModeSetup()
    {
        gameManager.gameMode = 0;
        gameManager.Reset();
        menuWindow.SetActive(false);
    }
    public void HardmodeSetup()
    {
        gameManager.gameMode = 1;
        gameManager.Reset();
        menuWindow.SetActive(false);
    }


    public void PCvsPC()
    {
        gameManager.gameMode = 2;
        gameManager.Reset();
        menuWindow.SetActive(false);
    }

    public void PvPSetup()
    {
        gameManager.gameMode = 3;
        gameManager.Reset();
        menuWindow.SetActive(false);
    }

    public void OpenPlayModeMenu()
    {
        menuWindow.SetActive(true);
    }
}
