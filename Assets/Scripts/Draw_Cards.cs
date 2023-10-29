using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class Draw_Cards : MonoBehaviour
{

    public PlayerManager PlayerManager;

    public void OnClick()
    {
        PlayerManager.DealCards();
    }
}
