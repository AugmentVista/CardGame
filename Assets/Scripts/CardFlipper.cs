using UnityEngine;
using UnityEngine.UI;


public class CardFlipper : MonoBehaviour
{
    public dragDrop DragDrop;
    public ScoreText ScoreText;
    public PlayerManager PlayerManager;
    public GameObject DropZone;
    public Sprite CardFront;
    public Sprite CardBack;
    public Health_System Health;
    public AI_Controller AIController;
    public int timesFlipped;
    public Sprite currentSprite;
    public static int comboCount = 0;
    private bool isFlipped = false;
    public bool isEnemyCard = false;
    public int valueOfCard;
    public int cardHealthModifier;

    public void Start()
    {
        currentSprite = gameObject.GetComponent<Image>().sprite;
        DropZone = GameObject.Find("DropZone");
        ScoreText = GameObject.Find("CountText").GetComponent<ScoreText>();
        DragDrop = GetComponent<dragDrop>();
        Health = FindObjectOfType<Health_System>();
        PlayerManager = FindObjectOfType<PlayerManager>();
        AIController = FindObjectOfType<AI_Controller>();
        if (AIController == null)
        {
            Debug.LogError("AI_Controller component not found on the CardFlipper GameObject.");
        }

        UpdateVisualState();
    }


    void UpdateVisualState()
    {
        if (!isFlipped)
        {
            gameObject.GetComponent<Image>().sprite = CardFront;
        }
        else if (isFlipped)
        {
            gameObject.GetComponent<Image>().sprite = CardBack;
        }
    }



    public void ComboChecker()
    {
        if (PlayerManager.CardPlayOrder.Count > 0)
        {
            GameObject lastPlayedCard = null;
            GameObject currentPlayedCard = PlayerManager.CardPlayOrder[PlayerManager.CardPlayOrder.Count - 1];
            if (PlayerManager.CardPlayOrder.Count > 1)
            {
                lastPlayedCard = PlayerManager.CardPlayOrder[PlayerManager.CardPlayOrder.Count - 2];
            }
            string lastCardName = (lastPlayedCard != null) ? lastPlayedCard.name : "None";
            Debug.Log("Last card played: " + lastCardName);

            string currentCardName = currentPlayedCard.name;

            Debug.Log("Current card played: " + currentCardName);

            if (lastPlayedCard != null && lastCardName == currentCardName)
            {
                Debug.Log("Last card and current card are the same.");
                Debug.Log("Before incrementing comboCount. Combo count is: " + comboCount);
                comboCount++;
                Debug.Log("After incrementing comboCount. Combo count is: " + comboCount);
                Debug.Log("Combo count is: " + comboCount);
                ScoreText.Score = ScoreText.Score + comboCount;
            }
            else if (lastPlayedCard != null && lastCardName != currentCardName)
            {
                comboCount = 0;
                Debug.Log("Combo count has been reset");
            }
        }
    }

    public void Flip()
    {
        if (timesFlipped <= 0)
        {
                timesFlipped++;
            if (currentSprite == CardBack)
            {
                currentSprite = CardFront;

                gameObject.GetComponent<Image>().sprite = CardFront;
                isFlipped = false;

                UpdateVisualState();
            }
            else if (currentSprite == CardFront)
            {
                gameObject.GetComponent<Image>().sprite = CardBack;
                currentSprite = CardBack;
                isFlipped = true;
                UpdateVisualState();
            }
        }
        else
        {
            return;
        }
    }

    public void UpdateHealthSystem()
    {
        Health.ModifyHealth(cardHealthModifier, isEnemyCard);
    }


    public void FlipCard()
    {
        if (timesFlipped <= 0 && DragDrop.cardInDropZone)
        {
            Flip();
            ComboChecker();
            ScoreText.OnFlip(this, PlayerManager);
            UpdateHealthSystem();
            AIController.PlayAITurn();
        }
    }
}