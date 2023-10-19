using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    public GameObject DropZone;
    public TextMeshProUGUI CountText;
    private int Card1inPlay; // Initialize to 0
    private int Card2inPlay; // Initialize to 0
    public int Card1Value;
    public int Card2Value;
    public int WinScore;
    public WinScreen winScreen;
    public int WinThresholdValue = 15;

    



    private void Update()
    {
        UpdateUI();
    }
    public void OnFlip()
    {
        Card1inPlay = 0; 
        Card2inPlay =0;
        Debug.Log(DropZone.transform.childCount);
        for (int i = 0; i < DropZone.transform.childCount; i++)
        {
            var childGameObject = DropZone.transform.GetChild(i).gameObject;
            if (childGameObject.name.StartsWith("Card1"))
            {
                Card1inPlay++;  
            }
            if (childGameObject.name.StartsWith("Card2"))
            {
                Card2inPlay++;
                
            }
        }
        Debug.Log("Number of Card1 in play: " + Card1inPlay);
        Debug.Log("Number of Card2 in play: " + Card2inPlay);
        Debug.Log(Card1Value);
        Debug.Log(Card2Value);   
    }


    public void UpdateUI()
    {
        CountText.text = ((Card1Value * Card1inPlay) + (Card2Value * Card2inPlay)).ToString();

        int WinScore = (Card1Value * Card1inPlay) + (Card2Value * Card2inPlay);
        Debug.Log("Winscore is: " + WinScore);
        winScreen.Win();
    }
}
