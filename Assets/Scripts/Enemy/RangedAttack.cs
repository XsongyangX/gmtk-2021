using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : EnemyBaseAttack
{
    [SerializeField] private GameObject projectile;
    private AudioSource shootSound;

    private void Start()
    {
        this.shootSound = GetComponentInChildren<AudioSource>();
    }
    public override void Attack()
    {
        shootSound.Play();
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
