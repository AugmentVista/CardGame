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


    public void Start()
    {
        DropZone = GameObject.Find("DropZone");
        ScoreText = GameObject.Find("CountText").GetComponent<ScoreText>();
    }

    public void Flip()
    {
        Sprite currentSprite = gameObject.GetComponent<Image>().sprite;
        timesFlipped++;
        Debug.Log("Times Flipped: " + timesFlipped.ToString());

        if (currentSprite == CardFront)
        {
            gameObject.GetComponent<Image>().sprite = CardBack;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = CardFront;
        }
    }

   

    [Command (requiresAuthority = false)]
    public void CmdOnClick()
    { 
        DragDrop = GetComponent<dragDrop>();
        NetworkIdentity networkIdentity = NetworkClient.connection.identity;
        PlayerManager = networkIdentity.GetComponent<PlayerManager>();
        if (!isServer)
        {
            Debug.Log("I am the Client");
        }
        Debug.Log("You have clicked on a card");
        if (/*isOwned &&*/ DragDrop.cardInDropZone) //!hasBeenFlipped)
        {
            Debug.Log("Flip should be working");
            Flip();
            ScoreText.OnFlip();
            Debug.Log("Flip has worked");
        }
        //PlayerManager.cardInDropZone = false;
    }
}