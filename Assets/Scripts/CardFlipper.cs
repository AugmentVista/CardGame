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
    private bool isFlipped = false; // 0

    public void Start()
    {
        currentSprite = gameObject.GetComponent<Image>().sprite;
        DropZone = GameObject.Find("DropZone");
        ScoreText = GameObject.Find("CountText").GetComponent<ScoreText>();
        DragDrop = GetComponent<dragDrop>();
        PlayerManager = FindObjectOfType<PlayerManager>();
        UpdateVisualState();
    }
    void UpdateVisualState()
    {
        if (!isFlipped)
        {
            Debug.Log("Flipped is false     1 "); // 1
            gameObject.GetComponent<Image>().sprite = CardFront;
        }
        else if (isFlipped)
        {
            Debug.Log("Flipped is true    6 "); // 6
            gameObject.GetComponent<Image>().sprite = CardBack;
        }
    }
    public void Flip()
    {
        if (timesFlipped <= 10)
        {
            timesFlipped++;
                Debug.Log("Times Flipped:" + timesFlipped.ToString() + "   2"); // 2
                Debug.Log(currentSprite + "    3"); // 3


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
                    Debug.Log(CardFront + "  CardFront == true?");
                    Debug.Log("Am i Flipped?" + isFlipped.ToString() + "    4"); // 4
                    Debug.Log("currentSprite:" + currentSprite.name + "     5"); // 5
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
            
        }
    }
}