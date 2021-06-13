using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour, PooledObjInterface
{
    public static string PoolTag = "Player bullets";

    public float Speed = 10f;

    internal Vector2 Direction;
    
    /// <summary>
    /// How much damage per bullet, in units
    /// </summary>
    [Tooltip("How much damage per bullet, in units")]
    public int Damage;

    // Update is called once per frame
    void Update()
    {
        // move
        this.transform.Translate(Direction * Speed * Time.deltaTime);
    }

    // Triggers on collision, reduces the enemy health and destroys bullet.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().DecreaseHealth(this.Damage);
            Discard();
        }
    }

    /// <summary>
    /// What to do on discard
    /// </summary>
    public void Discard()
    {
        MyPooler.ObjectPooler.Instance.ReturnToPool(PoolTag, this.gameObject);
    }

    /// <summary>
    /// Only use this if this instance's values change over its lifetime
    /// Use to reset the values back to initial state
    /// </summary>
    public void OnObjectPooled()
    {
        StartCoroutine(VanishAfter());
    }

    IEnumerator VanishAfter()
    {
        yield return new WaitForSeconds(1.5f);
        Discard();
    }
}
