using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementMirrored : PlayerMovement
{
    // Update is called once per frame
    void Update()
    {
        var step = this.playerController.Direction * this.playerController.Speed * Time.deltaTime;
        step.x *= -1;
        this.transform.Translate(step);
    }
}
