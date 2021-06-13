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
    private AudioSource hitSound;

    private void Start()
    {
        this.hitSound = GetComponent<AudioSource>();
    }

    public override void Attack()
    {
        this.hitSound.Play();

        GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerHealth>()
            .DecreaseHealth(this.Damage);
    }
}
