using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] bool enemiesStartActive = false;
    [SerializeField] GameObject enemiesHolder;
    [SerializeField] int screen;
    void Start()
    {
        AwakeEnemies(enemiesStartActive);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AwakeEnemies(true);
        }
    }

    private void AwakeEnemies(bool activateEnemies)
    {
        enemiesHolder.SetActive(activateEnemies);
    }
    public void CheckChildCount()
    {
        if(enemiesHolder.transform.childCount <= 1)
        {
            GameObject.FindGameObjectWithTag("DoorHolder").GetComponent<DoorHolder>().OpenDoor(screen);
            Debug.Log("Ready to destroy the " + screen + "door");
        }
    }
}
