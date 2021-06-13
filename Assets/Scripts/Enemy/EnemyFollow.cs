using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float minimumDistanceFromPlayer = 1f;
    private Transform playerTransform;
    private float previousPositionX;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    void Update()
    {
        if (Vector2.Distance(transform.position, playerTransform.position) > minimumDistanceFromPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, playerTransform.position) < minimumDistanceFromPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, -speed * Time.deltaTime);
        }
        float currentPositionX = transform.position.x;
        Vector3 spriteScale = transform.localScale;
        if(currentPositionX > previousPositionX+0.01)
        {
            spriteScale.x = -1;
        }
        else if(currentPositionX < previousPositionX-0.01)
        {
            spriteScale.x = 1;
        }
        transform.localScale = spriteScale;
        previousPositionX = currentPositionX;
    }
}
