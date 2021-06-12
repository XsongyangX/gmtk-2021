using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour, PooledObjInterface
{
    public static string PoolTag = "Player bullets";

    public float Speed = 10f;

    internal Vector2 Direction;

    // Update is called once per frame
    void Update()
    {
        // move
        this.transform.Translate(Direction * Speed * Time.deltaTime);
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
