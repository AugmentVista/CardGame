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
        Debug.Log("Win method called");

        if (ScoreText != null)
        {
            if (ScoreText.WinScore > 15)
            {
                Debug.Log("Win condition met. Setting WinText to active.");
                WinText.SetActive(true);
            }
            else
            {
                Debug.Log("Win condition not met.");
            }
        }
        else
        {
            Debug.Log("ScoreText reference is not assigned.");
        }
    }
}
