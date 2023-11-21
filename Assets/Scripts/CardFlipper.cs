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
    public AI_Controller AIController;
    public int timesFlipped = 0;
    public Sprite currentSprite;
    private bool isFlipped = false;
    public bool isEnemyCard = false;
    public int valueOfCard;

    public void Start()
    {
        currentSprite = gameObject.GetComponent<Image>().sprite;
        DropZone = GameObject.Find("DropZone");
        ScoreText = GameObject.Find("CountText").GetComponent<ScoreText>();
        DragDrop = GetComponent<dragDrop>();
        PlayerManager = FindObjectOfType<PlayerManager>();
        AIController = FindObjectOfType<AI_Controller>();

        if (AIController == null)
        {
            Debug.LogError("AI_Controller component not found on the CardFlipper GameObject.");
        }
        else
        {
            Debug.Log("AI_Controller component found on the CardFlipper GameObject.");
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
        if (timesFlipped <= 10)
        {
                timesFlipped++;
            if (currentSprite == CardBack)
            {
                currentSprite = CardFront;
                Debug.Log("Cardback == true");
                gameObject.GetComponent<Image>().sprite = CardFront;
                isFlipped = false;
                    Debug.Log("Am i Flipped?" + isFlipped.ToString());
                    Debug.Log("currentSprite: " + currentSprite.name);
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

    public void FlipCard()
    {
        if (timesFlipped <= 10 && DragDrop.cardInDropZone)
        {
            Flip();
            ScoreText.OnFlip(this, PlayerManager);
            AIController.PlayAITurn();
        }
    }
}