using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseAttack : MonoBehaviour
{
    [SerializeField] private float minimumAttackDistance = 1.5f;
    [SerializeField] private float cooldownTime = 2f;
    float timeUntilNextAttack; 
    private Transform playerTransform;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector2.Distance(transform.position, playerTransform.position) <= minimumAttackDistance) && (timeUntilNextAttack < Time.time))
        {
            Attack();
            Cooldown();
        }
    }
    public virtual void Attack()
    {
        Debug.Log("Base attack");
    }
    public void Cooldown()
    {
        timeUntilNextAttack = Time.time + cooldownTime;
    }
}
