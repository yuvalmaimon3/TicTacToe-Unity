using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCmodes : MonoBehaviour
{
    public int gameCounter = 0;
    private string gamePath; 
    
    public int PCeasy(int [] marked_squares)
    {
        int click;
        for (int i = 0; i < 80; i++)
        {
            click = Random.Range(0, 9);
            if (marked_squares[click] == 50)
            {
                return click;
            }
        } 
            return 50;  //The program perform PCeasy function at the same frame the user click. 
                        //it casue prblem because at the same frame the program performe 2 actions.
    }

    public int PCHard(int [] marked_squares)
    {
        if (gameCounter == 0)
        {
            gameCounter++;
            return 0;
        }
        else if (gameCounter == 1)
        {
            if (marked_squares[2] == 50 && (marked_squares[5] == 50 && marked_squares[8] == 50 && marked_squares[1] == 50))
            {
                gameCounter++;
                gamePath = "028";
                return 2;
            }
            else //Click on 6
            {
                gameCounter++;
                gamePath = "06";
                return 6;
            }
        }
         


        else if (gamePath == "06")
            return HardMode06(marked_squares);
        else
        if (gamePath == "028")
            return HardMode028(marked_squares);
        return 55;
    }

    private int HardMode028(int[] marked_squares)
{
         if (gameCounter == 2)
         {
            if (marked_squares[1] == 50)  //0,2
            {
                gameCounter++;
                return 1; // Win
            }
            else
            {
                gameCounter++;
                return 8;
            }
        }
        else if (gameCounter == 3)   
        {
            if(marked_squares[4] == 50  )
            {
                gameCounter++;
                return 4;
            }
            if (marked_squares[5] == 50)
            {
                gameCounter++;
                return 5;
            }
            else //5 Blocked
            {
                if(marked_squares[6] == 50)
                {
                    gameCounter++;
                    return 6;
                }
                else
                {
                    gameCounter++;
                    return 4;
                }
            }
            

        }
        else if (gameCounter == 4)
        {
            if (marked_squares[7] == 50)
            {
                gameCounter++;
                return 7;   //Win
            }    
            else
            {
                gameCounter++;
                return 3;   //Win
            }    

        }
            return 55;
    }
    private int HardMode06(int[] marked_squares)
    {
        if (gameCounter == 2)
        {
            if(marked_squares[3] == 50)
            {
                gameCounter++;
                return 3;   //Win 036
            }
            else if(marked_squares[2] == 50)
            {
                gameCounter++;
                return 2;
            }
            else
            {
                gameCounter++;
                return 8;
            }
        }
        if(gameCounter == 3)
        {
            if(marked_squares[4] == 50)
            {
                gameCounter++;
                return 4; 

            }
            else if(marked_squares[2] ==50)
            {
                gameCounter++;
                return 2; 
            }
            else
            {
                gameCounter++;
                return 5;
            }
        }
        else if(gameCounter == 4)
        {
            gameCounter++;
            return 1;      
        }


        return 55;
    }
    public void ResetPcMode()
    {
        gameCounter = 0;
        gamePath = "Reset";

    }
}

