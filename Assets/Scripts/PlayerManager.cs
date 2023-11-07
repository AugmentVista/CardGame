using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public WinScreen winScreen;
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject dropZone;
    ScoreText scoreText;
    List<GameObject> cards = new List<GameObject>();
    List<GameObject> Deck2 = new List<GameObject>();
    int cardsPlayed = 0;
    public int cardsDrawn = 0;

    private void Start()
    {
        PlayerArea = GameObject.Find("PlayerArea");
        EnemyArea = GameObject.Find("EnemyArea");
        dropZone = GameObject.Find("DropZone");
        scoreText = FindObjectOfType<ScoreText>();
        scoreText.CountText.enabled = true;
        scoreText.rulesText.enabled = true;

        cards.Add(Card1);
        cards.Add(Card2);
        cards.Add(Card3); 
        cards.Add(Card4);
        Deck2.Add(Card1);
        Deck2.Add(Card2); 
        Deck2.Add(Card3);
        Deck2.Add(Card4);
    }
    public void DealCards()
    {
        Debug.Log("dfjsjdfsjdfjsjdfbjsdjjbsdjfsjfj");
        if (cardsPlayed <= 15 && cardsDrawn <= 15) 
        {
            for (var i = 0; i < 2; i++) // enemy cards
            {
                //Debug.Log("Deck2 card" + Deck2.Count);
                int randomIndex = Random.Range(0, Deck2.Count); 
                GameObject Enemycard = Instantiate(Deck2[randomIndex], new Vector2(0, 0), Quaternion.identity);
                DealtCard(Enemycard, "EnemyDealt");
                //Debug.Log("Enemy has drawn a card");

            }
        }
        if (cardsPlayed <= 15 && cardsDrawn <= 15) // limits player to drawing and playing 10 cards
        {
            for (var i = 0; i < 2; i++) // player cards
            {
                //Debug.Log(cards.Count);
                int randomIndex = Random.Range(0, cards.Count);
                GameObject card = Instantiate(cards[randomIndex], new Vector2(0, 0), Quaternion.identity);
                DealtCard(card, "Dealt");
                //Debug.Log("player has drawn a card"); 
                cardsDrawn++;
            }
        }
        else
        {
            // Handle the case where you can't deal more cards
            return;
        }
    }
    public void PlayCard(GameObject card)
    {
        DealtCard(card, "Played");
    }
    void DealtCard(GameObject card, string type)
    {
        if (type == "EnemyDealt")
        {
            {
                card.transform.SetParent(EnemyArea.transform, false);
            }
        }
        else if (type == "Dealt")
        {
            card.transform.SetParent(PlayerArea.transform, false);
        }
        else if (type == "Played")
        {

            card.transform.SetParent(dropZone.transform, false);
            cardsPlayed++;
            //card.GetComponent<CardFlipper>().Flip();
        }
    }   
}
