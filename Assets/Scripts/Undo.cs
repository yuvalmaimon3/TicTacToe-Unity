using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Undo : MonoBehaviour
{
    public GameManager gameManager;
    public WinnerDisplayClass winnerDisplayClass;
    public PCmodes pcMode;
    public Sprite emptySprite;
    private Stack<int> clicks = new Stack<int>();

    public void UndoLastClick()
    {
        int last_click = clicks.Pop();
        gameManager.marked_Squares[last_click] = 50;   // Clear square
        gameManager.squares[last_click].image.sprite = emptySprite;
        gameManager.squares[last_click].interactable = true;
        gameManager.gameCounter--;
        pcMode.gameCounter--;
        gameManager.SwitchPlayer();
        if(gameManager.gameOnOff == false)
        winnerDisplayClass.RemoveWinnerDisplay();
        for (int i = 0; i < gameManager.WinLines.Length; i++)   //Disable all winlines
        {
            gameManager.WinLines[i].SetActive(false);
        }
        gameManager.gameOnOff = true;
        EnableAllSquares();

    }
    public void EnableAllSquares()
    {
        for (int i = 0; i < gameManager.squares.Length; i++)
        {
            if(gameManager.marked_Squares[i] == 50)
               gameManager.squares[i].interactable = true;
        }
        gameManager.Winner = false;
    }

    public void PushToClickStack(int square_num)
    {
        clicks.Push(square_num);
    }



}
