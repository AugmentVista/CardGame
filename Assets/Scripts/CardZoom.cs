/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardZoom : MonoBehaviour
{
    public GameObject Canvas;
    private GameObject ZoomCard;



    public void Awake()
    {
        Canvas = GameObject.Find("Main Canvas");
    }


    public void OnHoverEnter() 
    { 
        ZoomCard = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 240), Quaternion.identity);
        ZoomCard.transform.SetParent(Canvas.transform, false);
        ZoomCard.layer = LayerMask.NameToLayer("Zoom");

        RectTransform rect = ZoomCard.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(240, 344);
    }

    public void OnHoverExit()
    {
        Destroy(ZoomCard);
    }      
}*/
