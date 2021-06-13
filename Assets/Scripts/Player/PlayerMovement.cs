using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected PlayerController playerController;
    private float previousPositionX;
    // Start is called before the first frame update
    void Start()
    {
        this.playerController = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(this.playerController.Direction * this.playerController.Speed * Time.deltaTime);
        float currentPositionX = transform.position.x;
        Vector3 spriteScale = transform.localScale;
        if (currentPositionX < previousPositionX)
        {
            spriteScale.x = -1;
        }
        else if (currentPositionX > previousPositionX)
        {
            spriteScale.x = 1;
        }
        transform.localScale = spriteScale;
        previousPositionX = currentPositionX;
    }
}
