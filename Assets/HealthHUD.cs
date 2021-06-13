using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public Text livesLeft;
    PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        livesLeft.text = playerHealth.Health.ToString();
    }
}
