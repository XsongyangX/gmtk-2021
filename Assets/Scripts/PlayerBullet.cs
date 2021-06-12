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
}
