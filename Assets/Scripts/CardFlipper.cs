using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFlipper : NetworkBehaviour
{
    public dragDrop DragDrop;
    public PlayerManager PlayerManager;

    public bool hasBeenFlipped = false;
    public Sprite CardFront;
    public Sprite CardBack;

    /*private void Start()
    {
        DragDrop = GetComponent<dragDrop>();
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
    }*/



    public void Flip()
    {
        Sprite currentSprite = gameObject.GetComponent<Image>().sprite;

        if (currentSprite == CardFront)
        {
            gameObject.GetComponent<Image>().sprite = CardBack;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = CardFront;
        }
    }

    [ClientRpc]
    public void RpcOnClick(GameObject card)
    {
        DragDrop = GetComponent<dragDrop>();
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();


        if (isOwned && !DragDrop.IsDraggable && !hasBeenFlipped)
        {
         Flip();
        hasBeenFlipped = true;
        }
    }
}