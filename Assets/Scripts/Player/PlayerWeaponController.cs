using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    /// <summary>
    /// Reference to a bullet prefab
    /// </summary>
    [Tooltip("Prefab of the bullet")]
    public GameObject Bullet;

    /// <summary>
    /// Source of shooting sound
    /// </summary>
    private AudioSource shootSound;

    private void Start()
    {
        this.shootSound = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Shoots a bullet in that direction
    /// </summary>
    /// <param name="destination">World position to shoot the bullet</param>
    public void ShootBullet(Vector2 destination)
    {
        // spawn bullet
        var gameObject = MyPooler.ObjectPooler.Instance.GetFromPool(
            PlayerBullet.PoolTag, this.transform.position, Quaternion.identity);
        var bullet = gameObject.GetComponent<PlayerBullet>();
        bullet.Direction = (destination - (Vector2)this.transform.position).normalized;

        // bullet sound
        this.shootSound.Play();
    }
}
