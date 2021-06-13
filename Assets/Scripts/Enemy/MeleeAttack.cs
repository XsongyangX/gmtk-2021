using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : EnemyBaseAttack
{
    /// <summary>
    /// How much damage per melee strike
    /// </summary>
    [Tooltip("How much damage per bullet, in units")]
    public int Damage;

    public override void Attack()
    {
        Debug.Log("Melee attack");
        GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerHealth>()
            .DecreaseHealth(this.Damage);
    }
}
