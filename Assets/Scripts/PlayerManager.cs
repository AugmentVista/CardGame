using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class PlayerManager : NetworkBehaviour
{
    
    public GameObject Card1;
    public GameObject Card2;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject dropZone;
    List<GameObject> cards = new List<GameObject>();
    public bool cardInDropZone = false;


    [SyncVar]
    int cardsPlayed = 0;
    int cardsDrawn = 0;

    public override void OnStartClient()
    {
        base.OnStartClient();
        PlayerArea = GameObject.Find("PlayerArea");
        EnemyArea = GameObject.Find("EnemyArea");
        dropZone = GameObject.Find("DropZone");
       

    }


    [Server]
    public override void OnStartServer()
    {
        cards.Add(Card1);
        cards.Add(Card2);
    }

    [Command] public void CmdDealCards()
    {
        if (cardsPlayed <= 10 && cardsDrawn <= 5)
        {
            for (var i = 0; i < 5; i++)
            {
                GameObject card = Instantiate(cards[Random.Range(0, cards.Count)], new Vector2(0, 0), Quaternion.identity);
                NetworkServer.Spawn(card, connectionToClient);
                RpcShowCard(card, "Dealt");
                cardsDrawn++;
            }
        }
        else
        { 
            return; 
        }    
    }

    public void PlayCard(GameObject card)
    {
        CmdPlayCard(card);
    }

    [Command]
    void CmdPlayCard(GameObject card)
    {
        RpcShowCard(card, "Played");
    
    }


    [ClientRpc]
    void RpcShowCard(GameObject card, string type)
    {
        if (type == "Dealt")
        {
            if (isOwned)
            {
                card.transform.SetParent(PlayerArea.transform, false);
            }
            else
            {
                card.transform.SetParent(EnemyArea.transform, false);
                card.GetComponent<CardFlipper>().Flip(); // something is weird here the cards flip over in the dropzone when they shouldn't
            }
        }
        else if (type == "Played")
        {

            card.transform.SetParent(dropZone.transform, false);
            cardsPlayed++;
            cardInDropZone = true;
            Debug.Log("Local cards played = " + cardsPlayed);
            if (isOwned)
            {
                card.GetComponent<CardFlipper>().Flip();
            }
        }
    }   
}
