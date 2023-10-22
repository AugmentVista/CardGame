using UnityEngine;
using System.Collections.Generic;

/*public class AIPlayer : MonoBehaviour
{
    public PlayerManager playerManager;
    public WinScreen winScreen;
    public int targetScore = 20; // Set the AI's target score

    private List<GameObject> hand; // List to store the AI's hand of cards

    void Start()
    {
        // Find the PlayerManager in the scene
        playerManager = FindObjectOfType <PlayerManager>();
        winScreen = FindObjectOfType<winScreen>();

        // Initialize AI's hand with cards (assuming you have a card deck)
        hand = new List<GameObject>();
        InitializeAIHand();

        // Start AI's turn
        PlayAITurn();
    }

    void InitializeAIHand()
    {
        // Add cards to the AI's hand (you should replace this with your card initialization logic)
        hand.Add(/* Add card GameObject here );
        hand.Add(/* Add card GameObject here );
        hand.Add(/* Add card GameObject here );
    }

    void PlayAITurn()
    {
        // Simulate AI's turn based on the rules and strategy
        // For example, the AI can choose a card from its hand based on a strategy

        GameObject selectedCard = SelectCardToPlay();

        // Call the PlayCard method in PlayerManager to play the selected card
        playerManager.PlayCard(selectedCard);

        // End AI's turn
        // You may introduce a delay before the player's turn or other AI players take their turns
        // ...

        // Check if the AI has reached the target score and win if it did
        if (winScreen.randomWinScore() >= winScreen.ScoreText.WinScore
        {
            winScreen.Lose();
        }
    }

    GameObject SelectCardToPlay()
    {
        // Implement your AI's logic for card selection
        // This method should return the GameObject of the selected card from the AI's hand

        // Example: Play the highest-value card available
        GameObject highestValueCard = null;
        int highestValue = 0;

        foreach (var card in hand)
        {
            // Replace this with your logic to evaluate the card's value
            int cardValue = EvaluateCardValue(card);

            if (cardValue > highestValue)
            {
                highestValue = cardValue;
                highestValueCard = card;
            }
        }

        return highestValueCard;
    }

    int EvaluateCardValue(GameObject card)
    {
        // Replace this with your logic to evaluate the card's value
        // For example, if your cards have a "value" component:
        return card.GetComponent<Card>().value;
    }
}*/