using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowsEditorChanges : MonoBehaviour
{
    public GameManager gameManager;
    public Sprite [] xIcons;
    public Sprite[] oIcons;
    public Sprite[] backgroundImages;
    public Image player1Icon, player2Icon, backgroundImage;
    private int player1IconNum;
    private int player2IconNum;
    private int backgroundImageNum;

    public void ChangePlayer1Icon()
    {
        if (player1Icon.sprite == xIcons[player1IconNum])
            player1IconNum++;

        if (player1IconNum > 1)
        {
            player1IconNum = 0;
        }
        player1Icon.sprite = xIcons[player1IconNum];
    }
    public void ChangePlayer2Icon()
    {
        if (player2Icon.sprite == oIcons[player2IconNum])
            player2IconNum++;

        if (player2IconNum > 1)
        {
            player2IconNum = 0;
        }
        player2Icon.sprite = oIcons[player2IconNum];
    }
    public void ChangeBackgroundImage()
    {
        if (backgroundImage.sprite == backgroundImages[backgroundImageNum])
            backgroundImageNum++;

        if (backgroundImageNum > 2)
        {
            backgroundImageNum = 0;
        }
        backgroundImage.sprite = backgroundImages[backgroundImageNum];
    }

}
