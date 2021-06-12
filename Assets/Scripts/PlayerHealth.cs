using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 3;

    public void DecreaseHealth(int damage)
    {
        this.Health -= damage;
        if (this.Health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        print("You died");
    }
}
