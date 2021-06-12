using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : EnemyBaseAttack
{
    [SerializeField] private GameObject projectile;
    public override void Attack()
    {
        Debug.Log("Ranged attack");
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
