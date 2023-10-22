using Mirror;
using UnityEngine;
using UnityEngine.UI;

public class CardFlipper : NetworkBehaviour
{
    public dragDrop DragDrop;
    public ScoreText ScoreText;
    public PlayerManager PlayerManager;
    public GameObject DropZone;
    public Sprite CardFront;
    public Sprite CardBack;
    public int timesFlipped = 0;
    public Sprite currentSprite;


    [SyncVar]
    private bool isFlipped = false;

    public void Start()
    {
        currentSprite = gameObject.GetComponent<Image>().sprite;
        DropZone = GameObject.Find("DropZone");
        ScoreText = GameObject.Find("CountText").GetComponent<ScoreText>();
        DragDrop = GetComponent<dragDrop>();
        UpdateVisualState();
    }

    [Command]
    public void CmdFlipCard()
    {
        if (!isFlipped)
        {
            isFlipped = true;
        }
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

    [ClientRpc]
    public void RpcUpdateCardFlipState(bool flipped)
    {
        isFlipped = flipped;
        UpdateVisualState();
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

    // Update this method to be a [Command] method, not a local method
    [Command]
    public void CmdFlipCard1()
    {
        Debug.Log("DragDrop: " + DragDrop);
        Debug.Log("ScoreText: " + ScoreText);
        Debug.Log("gameObject: " + gameObject);
        // Check if the card is in the DropZone, so it can be flipped
        if (timesFlipped < 2 && DragDrop.cardInDropZone)
        {
            Flip();
            ScoreText.OnFlip(this);
            // Notify clients to update the card's flipped state
            RpcUpdateCardFlipState(gameObject, timesFlipped);
        }
    }

    // This method is called on clients to update the card's flipped state
    [ClientRpc]
    void RpcUpdateCardFlipState(GameObject card, int flipCount)
    {
        // Make sure the card object is the same on all clients
        if (isLocalPlayer)
        {
            // Update the card's state based on the received flipCount
            timesFlipped = flipCount;

            // Update the visual representation of the card
            if (timesFlipped < 2)
            {
                currentSprite = card.GetComponent<Image>().sprite;
                if (currentSprite == CardFront)
                {
                    card.GetComponent<Image>().sprite = CardBack;
                }
                else
                {
                    card.GetComponent<Image>().sprite = CardFront;
                }
            }
        }
    }
}