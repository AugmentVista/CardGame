using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Cards : MonoBehaviour
{



    public GameObject Card1;
    public GameObject Card2;
    public GameObject PlayerArea;
    public GameObject EnemyArea;




    
    void Start()
    {
        
    }


    public void OnClick()
    {
        GameObject playerCard = Instantiate(Card1, new Vector3(0, 0, 0), Quaternion.identity); // creates a new Card1 at the origin point of 0,0,0
        playerCard.transform.SetParent(PlayerArea.transform, false);

    }
    
}
