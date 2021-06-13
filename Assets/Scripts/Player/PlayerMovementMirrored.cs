using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMirrored : PlayerMovement
{
    // Update is called once per frame
    private float previousPositionMirroedX;
    void Update()
    {
        var step = this.playerController.Direction * this.playerController.Speed * Time.deltaTime;
        step.x *= -1;
        this.transform.Translate(step);

        //Flip the player sprite
        float currentPositionX = transform.position.x;
        Vector3 spriteScale = transform.localScale;
        if (currentPositionX < previousPositionMirroedX)
        {
            spriteScale.x = -1;
        }
        else if (currentPositionX > previousPositionMirroedX)
        {
            spriteScale.x = 1;
        }
        transform.localScale = spriteScale;
        previousPositionMirroedX = currentPositionX;
    }
}
