using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinScreen : MonoBehaviour
{
    public GameObject WinText;
    public ScoreText ScoreText;

    void Start()
    {
        ScoreText = GameObject.Find("CountText").GetComponent<ScoreText>();
        WinText.SetActive(false);
    }
    public void Win()
    {
            if (ScoreText.WinScore > 15)
            {
                WinText.SetActive(true);
            }
            else
            {
            return; 
            }
    }
}
