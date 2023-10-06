using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class Draw_Cards : MonoBehaviour
{

    public PlayerManager PlayerManager;

    public void OnClick()
    {
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
        PlayerManager.CmdDealCards();
    }
}
