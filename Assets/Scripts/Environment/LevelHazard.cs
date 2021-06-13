using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHazard : MonoBehaviour
{
    PlayerHealth playerHealth;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && this.tag == "BlackOoze")
        {
            playerHealth.DecreaseHealth(1);
        }
        else if(collision.gameObject.name == "Player" && this.tag == "InstaDeath")
        {
            playerHealth.DecreaseHealth(2);
        }
        

    }
}
