using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] bool enemiesStartActive = false;
    [SerializeField] GameObject enemiesHolder;
    void Start()
    {
        AwakeEnemies(enemiesStartActive);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hello there!");
        if (other.CompareTag("Player"))
        {
            AwakeEnemies(true);
        }
    }

    private void AwakeEnemies(bool activateEnemies)
    {
        enemiesHolder.SetActive(activateEnemies);
    }
}
