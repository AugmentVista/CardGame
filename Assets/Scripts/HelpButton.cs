using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class HelpButton : MonoBehaviour // lol this doesn't work
{
    public bool HelpScreenActive;

    public void Start()
    {
        HelpScreenActive = false;
    }


    public void OnClickStart()
    {
        GameObject HelpButton = GameObject.Find("HelpScreenParent");

        if (HelpButton != null)
        {
            Debug.Log("Help button if statement is running");
            PlayableDirector timeline = HelpButton.GetComponent<PlayableDirector>();
            if (timeline != null && !HelpScreenActive)
            {
                Debug.Log("Timeline if statement is running");
                Debug.Log(timeline);
                timeline.Play();
                Debug.Log(HelpScreenActive);
                HelpScreenActive = true;
                Debug.Log(HelpScreenActive);
            }
        }
    }

    public void OnClickStop()
    {
        GameObject HelpButton = GameObject.Find("HelpScreenParent");

        if (HelpButton != null)
        {
            PlayableDirector timeline = HelpButton.GetComponent<PlayableDirector>();
            if (timeline != null && HelpScreenActive != false)
            {
                HelpScreenActive = false;
                timeline.Stop();
            }
        }

    } 
}
