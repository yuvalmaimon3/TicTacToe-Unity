using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinnerDisplayClass : MonoBehaviour
{
    public GameObject [] x_O_Draw_Images;

    public void winnerDisplay(int who_play)
    {
        if(who_play == 0)
        {

            x_O_Draw_Images[0].SetActive(true);

        }
        else if(who_play == 1)
        {

            x_O_Draw_Images[1].SetActive(true);
        }
        else
        {
            x_O_Draw_Images[2].SetActive(true);     
        }
    }

    public void RemoveWinnerDisplay()
    {
        for (int i = 0; i <= 2; i++)
        {
            x_O_Draw_Images[i].SetActive(false);
        }
    }


}
