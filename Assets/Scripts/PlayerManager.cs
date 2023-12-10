using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public WinScreen winScreen;


    [SerializeField]
    public AI_Controller AIcontroller;

    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject CardPlus1Plus5;
    public GameObject CardPlus3Plus2;
    public GameObject CardPlus4Plus1;
    public GameObject CardPlus5Minus2;
    public GameObject CardPlus7Minus2;
    public GameObject CardPlus9Minus5;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject dropZone;
    ScoreText scoreText;
    List<GameObject> cards = new List<GameObject>();
    public List<GameObject> CardPlayOrder = new List<GameObject>();
    public int cardsPlayed = 0;
    public int cardsDrawn = 0;

    private void Start()
    {
        PlayerArea = GameObject.Find("PlayerArea");
        EnemyArea = GameObject.Find("EnemyArea");
        dropZone = GameObject.Find("DropZone");
        scoreText = FindObjectOfType<ScoreText>();

        scoreText.CountText.enabled = true;
        scoreText.rulesText.enabled = true;

        //cards.Add(Card1);
        //cards.Add(Card2);
        //cards.Add(Card3);
        //cards.Add(Card4);
        cards.Add(CardPlus1Plus5);
        cards.Add(CardPlus3Plus2);
        cards.Add(CardPlus4Plus1);
        cards.Add(CardPlus5Minus2);
        cards.Add(CardPlus7Minus2);
        cards.Add(CardPlus9Minus5);
    }
    public void DealCards()
    {
        AIcontroller.InitializeAIHand();
        if (cardsPlayed <= 10 && cardsDrawn <= 100) 
        {
            for (var i = 0; i < 1; i++) // i = # cards to draw
            {
                int randomIndex = Random.Range(0, cards.Count);
                GameObject card = Instantiate(cards[randomIndex], new Vector2(0, 0), Quaternion.identity);
                DealtCard(card, "Dealt");
                cardsDrawn++;
            }
        }
    }
    public void PlayCard(GameObject card, string type)
    {
        DealtCard(card, type);
    }

    public void DealtCard(GameObject card, string type)
    {
        if (type == "EnemyDealt")
        {
            card.transform.SetParent(EnemyArea.transform, false);
            card.GetComponent<CardFlipper>().isEnemyCard = true;
        }
        else if (type == "Dealt")
        {
            card.transform.SetParent(PlayerArea.transform, false);
        }
        else if (type == "Played")
        {
            CardPlayOrder.Add(card);
            Debug.Log("Card is " + card);
            card.transform.SetParent(dropZone.transform, false);
            cardsPlayed++;
        }
    }
}
