using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Draw_Cards : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public WinScreen winScreen;

    public void OnClick()
    {
        Debug.Log("fsdjfjsds");
        PlayerManager.DealCards();
        winScreen.Win();
        Console.WriteLine("Win(); is working in Draw_Cards");
    }
}
