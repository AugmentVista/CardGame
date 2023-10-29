using Mirror;
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
    public int timesFlipped = 0;
    public Sprite currentSprite;
    private bool isFlipped = false;

    public void Start()
    {
        currentSprite = gameObject.GetComponent<Image>().sprite;
        DropZone = GameObject.Find("DropZone");
        ScoreText = GameObject.Find("CountText").GetComponent<ScoreText>();
        DragDrop = GetComponent<dragDrop>();
        UpdateVisualState();
    }
    void UpdateVisualState()
    {
        if (isFlipped)
        {
            gameObject.GetComponent<Image>().sprite = CardFront;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = CardBack;
        }
    }
    public void Flip()
    {
        if (timesFlipped < 2)
        {
            timesFlipped++;
            Debug.Log("Times Flipped: " + timesFlipped.ToString());

            if (currentSprite == CardFront)
            {
                gameObject.GetComponent<Image>().sprite = CardBack;
            }
            else if (currentSprite == CardBack)
            {
                gameObject.GetComponent<Image>().sprite = CardFront;
            }
        }
        else
        {
            return;
        }
    }

    public void FlipCard()
    {
        Debug.Log("DragDrop: " + DragDrop);
        Debug.Log("ScoreText: " + ScoreText);
        Debug.Log("gameObject: " + gameObject);
        // Check if the card is in the DropZone, so it can be flipped
        if (timesFlipped < 2 && DragDrop.cardInDropZone)
        {
            Flip();
            ScoreText.OnFlip(this);
            
        }
    }
}