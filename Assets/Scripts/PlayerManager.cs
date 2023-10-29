using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public WinScreen winScreen;
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject dropZone;
    ScoreText scoreText;
    List<GameObject> cards = new List<GameObject>();
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
    }
    public void DealCards()
    {
        if (cardsPlayed <= 10 && cardsDrawn <= 8 && cards.Count > 0)
        {
            for (var i = 0; i < 2; i++) // Change to draw 2 cards
            {
                int randomIndex = Random.Range(0, cards.Count);
                GameObject card = Instantiate(cards[randomIndex], new Vector2(0, 0), Quaternion.identity);
                ShowCard(card, "Dealt");
                cardsDrawn++;
            }
        }
        else
        {
            // Handle the case where you can't deal more cards, e.g., display a message.
            return;
        }
    }
    public void PlayCard(GameObject card)
    {
        ShowCard(card, "Played");
    
    }
    void ShowCard(GameObject card, string type)
    {
        if (type == "Dealt")
        {
            /*if (isOwned)  change to reference AI cards
            {
                card.transform.SetParent(PlayerArea.transform, false);
            }
            else*/
            {
                card.transform.SetParent(EnemyArea.transform, false);
                card.GetComponent<CardFlipper>().Flip(); // something is weird here the cards flip over in the dropzone when they shouldn't
            }
        }
        else if (type == "Played")
        {

            card.transform.SetParent(dropZone.transform, false);
            cardsPlayed++;
            
            Debug.Log("Local cards played = " + cardsPlayed);
            /*if (isOwned) // change to reference AI cards
            {
                
                card.GetComponent<CardFlipper>().Flip(); // when card is placed into dropzone
            }*/
        }
    }   
}
