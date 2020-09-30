using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Hint : MonoBehaviour
{
    public bool findHint = false;
    public Sprite hintSprite;
    public Sprite emptySprite;
    public GameManager gameManager;
    public int hintNuber;
    public float hintTimer = 0;

    // Update is called once per frame
    void Update()
    {
        hintTimer += Time.deltaTime;

        if(findHint == false)
        HintMove();
        
    }

    private void HintMove ()
    {
        int click;
        if(hintTimer > 1)
        {
            for (int i = 0; i < 80; i++)
            {
                click = Random.Range(0, 9);
                if (gameManager.marked_Squares[click] == 50)
                {
                    findHint = true;
                    hintNuber = click;
                    MarkTheHint();
                    return;
                }
            }
        }
    }
    public void ResetHintColor()
    {
        hintTimer = 0;
        findHint = false;
        if(gameManager.marked_Squares[hintNuber] == 50)
        {
            gameManager.squares[hintNuber].image.sprite = emptySprite;
        }
    }

    private void MarkTheHint()
    {
        gameManager.squares[hintNuber].image.sprite = hintSprite;
    }

}
