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
    public int timesFlipped = 0;
    public Sprite currentSprite;
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
            ScoreText.OnFlip(this, PlayerManager);
            UpdateHealthSystem();
            AIController.PlayAITurn();
        }
    }
}