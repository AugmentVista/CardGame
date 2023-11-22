using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class dragDrop : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject DropZone;
    public PlayerManager PlayerManager;
    public CardFlipper cardFlipper;
    private bool isDragging = false;
    public bool cardInDropZone = false;
    private bool isOverDropZone = false;
    public bool IsDraggable = true;
    private GameObject dropZone;
    private GameObject startParent;
    private Vector2 startPosition;

   
    private void Start()
    {
        cardFlipper = GetComponent<CardFlipper>();
        Canvas = GameObject.Find("Main Canvas");
        DropZone = GameObject.Find("DropZone");
        PlayerManager = GameObject.Find("PLAYERMANAGER").GetComponent<PlayerManager>();
        if (cardFlipper != null && cardFlipper.isEnemyCard)
        {
            isDragging = false;
        }
        if (Canvas == null)
        {
            Debug.LogError("Canvas not found in dragDrop.");
            return;
        }

        if (DropZone == null)
        {
            Debug.LogError("DropZone not found in dragDrop.");
            return;
        }

        if (PlayerManager == null)
        {
            Debug.LogError("PlayerManager not found in dragDrop.");
            return;
        }
    }
    void Update()
    {
        if (isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }
    public void StartDrag()
    {
        if (!IsDraggable || (cardFlipper != null && cardFlipper.isEnemyCard))
        {
            return;
        }
        else if (IsDraggable)
        { 
            startParent = transform.parent.gameObject;
            startPosition = transform.position;
            isDragging = true;
        }
    }
    public void EndDrag()
    {
        if (!IsDraggable || !isDragging) return;
        isDragging = false;
        if (isOverDropZone)
        {
            PlayerManager.PlayCard(gameObject, "Played");
            IsDraggable = false;
            cardInDropZone = true;
        }
        else
        {
            transform.position = startPosition;
            startParent = transform.parent.gameObject;
            transform.SetParent(startParent.transform, false);
        }
    }
}