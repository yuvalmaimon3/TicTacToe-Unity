using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class StopWatch : MonoBehaviour
{
    private float seconds = 0;
    private float minutes = 0;
    public Text secondsText;
    public Text minutesText;
    public GameManager gameManager;


    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (gameManager.gameOnOff)
            Clock();
    }
    private void Clock()
    {

        seconds += Time.deltaTime;
        if (seconds >= 59)
        {
            seconds = 0f;
            minutes++;
            minutesText.text = minutes.ToString("F0");
        }
        secondsText.text = seconds.ToString("F0");


    }
    public void ResetWatch()
    {
        seconds = 0;
        secondsText.text = seconds.ToString();
        minutes = 0;
        minutesText.text = minutes.ToString();
    }
}
