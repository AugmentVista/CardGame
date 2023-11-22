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
    public int currentPlayerHealth;

    int baseEnemyHealth = 10;
    public int currentEnemyHealth;



    private void Start()
    {
        PlayerManager = GetComponent<PlayerManager>();
        ScoreText = GameObject.Find("CountText").GetComponent<ScoreText>();
        currentPlayerHealth = basePlayerHealth;
        currentEnemyHealth = baseEnemyHealth;
        HealthText.text = "Health " + currentPlayerHealth.ToString();
        EnemyHealthText.text = "Health " + currentEnemyHealth.ToString();
    }

    public void ModifyHealth(int value, bool isEnemyCard)
    {
        if (isEnemyCard)
        {
            currentEnemyHealth += value;
            if (currentEnemyHealth < 0)
                currentEnemyHealth = 0;
            EnemyHealthText.text = "Health " + currentEnemyHealth.ToString();
        }
        else
        {
            currentPlayerHealth += value;
            if (currentPlayerHealth < 0)
                currentPlayerHealth = 0;
            HealthText.text = "Health " + currentPlayerHealth.ToString();
        }
    }
}
