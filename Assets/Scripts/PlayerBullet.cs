using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float Speed = 10f;

    internal Vector2 Direction;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Direction * Speed * Time.deltaTime);
    }

    // Triggers on collision, reduces the enemy health and destroys bullet.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().DecreaseHealth(1);
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
