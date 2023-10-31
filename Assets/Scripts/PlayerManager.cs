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
    int cardsDrawn = 0;

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
        Deck2.Add(Card4);
    }
    public void DealCards()
    {
        if (cardsPlayed <= 10 && cardsDrawn <= 10 && cards.Count > 0)
        {
            for (var i = 0; i < 2; i++) // Change to draw 2 cards
            {
                int randomIndex = Random.Range(1, cards.Count); // could this be an array
                GameObject card = Instantiate(cards[randomIndex], new Vector2(0, 0), Quaternion.identity);
                DealtCard(card, "Dealt");
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
        if (type == "Dealt")
        {
            {
                card.transform.SetParent(EnemyArea.transform, false); // puts cards into the enemy card after they have been dealt
                card.GetComponent<CardFlipper>().Flip(); 
            }
            /*if it is from the second random index put them in the player area here.
            {
                card.transform.SetParent(PlayerArea.transform, false);
            }
            else*/
        }
        else if (type == "Played")
        {

            card.transform.SetParent(dropZone.transform, false);
            cardsPlayed++;
            
            Debug.Log("Local cards played = " + cardsPlayed);
        }
    }   
}
