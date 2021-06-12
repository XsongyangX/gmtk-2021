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
    /// Shoots a bullet in that direction
    /// </summary>
    /// <param name="destination">World position to shoot the bullet</param>
    public void ShootBullet(Vector2 destination)
    {
        var gameObject = Instantiate(Bullet, this.transform.position, Quaternion.identity);
        var bullet = gameObject.GetComponent<PlayerBullet>();
        bullet.Direction = (destination - (Vector2)this.transform.position).normalized;
    }
}
