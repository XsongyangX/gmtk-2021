using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int hearts = 2;
    // Start is called before the first frame update
    public void DecreaseHealth(int damageDealt)
    {
        hearts -= damageDealt;
        if (hearts <= 0)
        {
            DestroyEnemy();
        }
    }
    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
