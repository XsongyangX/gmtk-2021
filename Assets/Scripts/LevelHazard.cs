using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHazard : MonoBehaviour
{
    PlayerHealth playerHealth;
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && this.tag == "BlackOoze")
        {
            playerHealth.loseHealth(-5f);
        }
        else if(collision.gameObject.tag == "Player" && this.tag == "InstaDeath")
        {
            playerHealth.loseHealth(-100f);
        }
        

    }
}
