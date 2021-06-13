using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform playerTransform;
    private Vector2 target;
    [SerializeField] private float speed = 1f;

    public static string PoolTag = "Enemy projectiles";

    /// <summary>
    /// How much damage a projectile deals to the player
    /// </summary>
    [Tooltip("How much damage per bullet, in units")]
    public int Damage;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        target = new Vector2(playerTransform.position.x, playerTransform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Discard();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponentInParent<PlayerHealth>().DecreaseHealth(this.Damage);
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
        //StartCoroutine(VanishAfter());
    }

    // IEnumerator VanishAfter()
    // {
    //     yield return new WaitForSeconds(1.5f);
    //     Discard();
    // }
}
