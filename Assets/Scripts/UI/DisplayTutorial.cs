using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTutorial : MonoBehaviour
{
    public GameObject tutImgs;


    private void Update()
    {
        for (int i = 0; i < tutImgs.transform.childCount; i++)
        {
            if (!tutImgs.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                Time.timeScale = 1;
                tutImgs.SetActive(false);
            }
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
        tutImgs.SetActive(true);
        Time.timeScale = 0;
        }
        
    }
}
