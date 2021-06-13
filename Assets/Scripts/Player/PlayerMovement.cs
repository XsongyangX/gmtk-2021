using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        this.playerController = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(this.playerController.Direction * this.playerController.Speed * Time.deltaTime);
    }
}
