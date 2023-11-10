using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health_System : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public ScoreText ScoreText;

    [SerializeField]
    private TextMeshProUGUI HealthText;

    [SerializeField]
    private TextMeshProUGUI EnemyHealthText;

    int basePlayerHealth = 10;
    int currentPlayerHealth; 

    int baseEnemyHealth = 10;
    int currentEnemyHealth;

    

    private void Start()
    {
        PlayerManager = GetComponent<PlayerManager>();
       
        ScoreText = GameObject.Find("CountText").GetComponent<ScoreText>();  
    }

    void Update()
    {
        currentPlayerHealth = basePlayerHealth - ScoreText.Score;
        HealthText.text = "Health " + currentPlayerHealth.ToString();

        currentEnemyHealth = baseEnemyHealth - ScoreText.AIscore; 
        EnemyHealthText.text = "Health " + currentEnemyHealth.ToString();
    }
}
