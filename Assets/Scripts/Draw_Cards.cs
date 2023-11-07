using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Draw_Cards : MonoBehaviour
{
    public PlayerManager PlayerManager;

    public void OnClick()
    {
        Debug.Log("fsdjfjsds");
        PlayerManager.DealCards();
    }
}
