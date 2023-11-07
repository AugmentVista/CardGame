using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health_System : MonoBehaviour
{
    public PlayerManager PlayerManager;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI EnemyHealthText;
    public ScoreText ScoreText;

    int basePlayerHealth = 10;
    int currentPlayerHealth; 


    private void Start()
    {
        PlayerManager = GetComponent<PlayerManager>();
        HealthText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        EnemyHealthText = GameObject.Find("EnemyHealthText").GetComponent<TextMeshProUGUI>();
        ScoreText = GameObject.Find("CountText").GetComponent<ScoreText>();  
    }
    void Update()
    {
        currentPlayerHealth = basePlayerHealth - ScoreText.Score;
        HealthText.text = "Health " + currentPlayerHealth.ToString();
    }


























}
