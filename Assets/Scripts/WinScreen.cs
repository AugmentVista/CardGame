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
        Debug.Log(ScoreText.WinScore);
        if (ScoreText != null)
        {
            if (ScoreText.WinScore > 15)
            {
                Debug.Log("Win condition met. Setting WinText to active.");
                Debug.Log(WinText.name);
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
