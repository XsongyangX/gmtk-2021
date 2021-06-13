using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTutorial : MonoBehaviour
{
    public Canvas tutImgs;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
            Time.timeScale = 0;
        tutImgs.enabled = true;

        if(tutImgs.enabled == false)
        {
            Time.timeScale = 1;
        }
    }
}
