using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using Unity.Collections.LowLevel.Unsafe;


public class PlayerManager : NetworkBehaviour
{

    public GameObject Card1;
    public GameObject Card2;
    public GameObject PlayerArea;
    public GameObject EnemyArea;
    public GameObject dropZone;




    List<GameObject> cards = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

        cards.Add(Card1);
        cards.Add(Card2);


    }


    public override void OnStartClient()
    {
        base.OnStartClient();
        PlayerArea = GameObject.Find("PlayerArea");
        EnemyArea = GameObject.Find("EnemyArea");
        dropZone = GameObject.Find("DropZone");
    }


    public void OnClick()
    {
        for (var i = 0; i < 5; i++)
        {
            GameObject playerCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity); // creates a new Card1 at the origin point of 0,0,0
            playerCard.transform.SetParent(PlayerArea.transform, false);
        }
        for (var i = 0; i < 5; i++)
        {
            GameObject enemyCard = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            enemyCard.transform.SetParent(EnemyArea.transform, false);
        }
    }
}
