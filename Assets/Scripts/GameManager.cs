using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int whoPlay = 0;  // Who play
    private float scale = 1f;   //How fast the X and O pump and shrink
    private int xPlayerScore;
    private int oPlayerScore;    

    public GameObject resetButton;
    public int gameMode = 3;   // 0 = Easy Mode || 1 = Hard Mode || 2 = PCvsPC || 3 = PVP
    public Sprite[] xoImages;  //X and O images
    public bool Winner = false;
    public int gameCounter = 0;  //how much rounds 
    public WinnerDisplayClass winner_Display;
    public bool gameOnOff = true;
    public Transform[] pumpImage;  //Pump X and Y by order
    public Button[] squares;
    public int[] marked_Squares;
    public StopWatch stop_Watch;
    public GameObject[] WinLines;
    public Text oScoreText;
    public Text xScoreText;
    public Sprite emptySprite;
    public PCmodes pc_Modes;
    public Hint hint;
    public Undo undo;

    // Update is called once per frame
    void Update()
    {

        if (pumpImage[whoPlay].localScale.x >= 3f)
            scale = -1f;
        else if (pumpImage[whoPlay].localScale.x <= 2f)
            scale = 1f;

        if (gameOnOff)
        {
            pumpImage[whoPlay].localScale += new Vector3(scale, scale, 0f) * Time.deltaTime;
        }


        if (gameMode == 0)//PvE Easy
            PlayEasyMode();
        else if (gameMode == 1) //PvE Hard
            PlayHardMode();
        else if (gameMode == 2)
            PlayPCvsPC();   //PCvsPC        
        if (gameCounter == 8)
        {
            resetButton.SetActive(true);
            gameOnOff = false;
        }


    }

    private void PlayPCvsPC()
    {
            if (gameCounter <= 8)
            {
                Click(pc_Modes.PCeasy(marked_Squares));
                SwitchPlayer();

            }
    } 

    private void PlayEasyMode()
    {
        if (gameCounter <= 7 && whoPlay == 1)
        {
            Click(pc_Modes.PCeasy(marked_Squares));
            SwitchPlayer();
        }
    }

    private void PlayHardMode()
    {
        if (gameCounter <= 8 && whoPlay == 0 && gameOnOff == true)
        {
            Click(pc_Modes.PCHard(marked_Squares));
            SwitchPlayer();
        }
    }

    public void PlayerClicked(int square_index)
    {

            Click(square_index);   
            SwitchPlayer();
    }

    private void Click(int square_index)
    {
        hint.ResetHintColor();
        pumpImage[whoPlay].localScale = new Vector3(2f, 2f, 0);   // Stop pump icon
        gameCounter++;
        squares[square_index].image.sprite = xoImages[whoPlay];
        squares[square_index].interactable = false;
        marked_Squares[square_index] = whoPlay + 1;
        undo.PushToClickStack(square_index);

        if(gameCounter >=4)
        CheckMatch();
        if(gameCounter == 9)
        {
            resetButton.SetActive(true);
            if (Winner == false)
            {
                winner_Display.winnerDisplay(3);
            }
        }
    }

    private void CheckMatch ()
    {
        int o1 = marked_Squares[0] + marked_Squares[1] + marked_Squares[2];
        int o2 = marked_Squares[3] + marked_Squares[4] + marked_Squares[5];
        int o3 = marked_Squares[6] + marked_Squares[7] + marked_Squares[8];
        int o4 = marked_Squares[0] + marked_Squares[3] + marked_Squares[6];
        int o5 = marked_Squares[1] + marked_Squares[4] + marked_Squares[7];
        int o6 = marked_Squares[2] + marked_Squares[5] + marked_Squares[8];
        int o7 = marked_Squares[0] + marked_Squares[4] + marked_Squares[8];
        int o8 = marked_Squares[2] + marked_Squares[4] + marked_Squares[6];

        int[] options = new int[] {o1, o2, o3, o4, o5, o6, o7, o8};
        for(int i = 0; i <= options.Length-1; i++)
        {
            if (options[i] == 3 * (whoPlay + 1))
            {
                WindLineDisplay(i); //The options order array match the line postion
                if (whoPlay == 0)
                {
                    xPlayerScore++;
                    xScoreText.text = "Score : " + xPlayerScore;
                    Winner = true;
                    winner_Display.winnerDisplay(whoPlay);
                }
                else
                {
                    oPlayerScore++;
                    oScoreText.text = "Score : " + oPlayerScore;
                    Winner = true;
                    winner_Display.winnerDisplay(whoPlay);
                }
                gameOnOff = false;
                return;
            }
        }

    }

    private void WindLineDisplay(int line_index)
    {
        WinLines[line_index].SetActive(true);
        gameOnOff = false;
        resetButton.SetActive(true);
        DisableAllSquares();

    }

    public void DisableAllSquares()
    {
        for (int i = 0; i < squares.Length; i++)
        {
            squares[i].interactable = false;
        }
    }

    public void SwitchPlayer()
    {
        if (whoPlay == 0)
            whoPlay = 1;
        else whoPlay = 0;
    }

    private void EnableAllSquares()
    {
        for (int i = 0; i < squares.Length; i++)    //Clear all Square images and enable
        {
            squares[i].image.sprite = emptySprite;
            squares[i].interactable = true;
        }
    }

    public void Reset()
    {
        Winner = false;
        winner_Display.RemoveWinnerDisplay();
        gameCounter = 0;
        gameOnOff = true;
        resetButton.SetActive(false);
        whoPlay = 0;
        gameCounter = 0;

        EnableAllSquares();

        for (int i = 0; i < WinLines.Length; i++)   //Disable all winlines
        {
            WinLines[i].SetActive(false);
        }

        for (int i = 0; i < marked_Squares.Length; i++)  //Reset all squares XO value 
        {
            marked_Squares[i] = 50;   // Clear square
        }
        pc_Modes.ResetPcMode();
        stop_Watch.ResetWatch();

    }
}
