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
    Health_System health_System;
    List<GameObject> cards = new List<GameObject>();
    public List<GameObject> CardPlayOrder = new List<GameObject>();
    List<GameObject> PlayerHand = new List<GameObject>();
    public List<GameObject> CardsOnBoard = new List<GameObject>();
    public int cardsPlayed = 0;
    public int cardsDrawn = 0;

    private void Start()
    {
        PlayerArea = GameObject.Find("PlayerArea");
        EnemyArea = GameObject.Find("EnemyArea");
        dropZone = GameObject.Find("DropZone");
        scoreText = FindObjectOfType<ScoreText>();
        health_System = FindObjectOfType<Health_System>();

        scoreText.CountText.enabled = true;
        scoreText.rulesText.enabled = true;

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
        if (PlayerHand.Count < 7) 
        {
            for (var i = 0; i < 1; i++) // i = # cards to draw
            {
                int randomIndex = Random.Range(0, cards.Count);
                GameObject card = Instantiate(cards[randomIndex], new Vector2(0, 0), Quaternion.identity);
                DealtCard(card, "Dealt");
                PlayerHand.Add(card);
                cardsDrawn++;
                Debug.Log(cardsDrawn);
                health_System.ModifyHealth(-cardsDrawn, false);
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
            card.transform.SetParent(dropZone.transform, false);
            PlayerHand.Remove(card);
            cardsPlayed++;
            CardsOnBoard.Add(card);
            if (CardsOnBoard.Count > 10)
            {
                Destroy(CardsOnBoard[0]);
                CardsOnBoard.RemoveAt(0);
            }
        }
    }
}
