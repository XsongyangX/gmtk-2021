using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndLevel1 : MonoBehaviour
{
    public GameObject endDialog;


    private void Update()
    {
        for (int i = 0; i < endDialog.transform.childCount; i++)
        {
            if (!endDialog.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                endDialog.SetActive(false);
            }
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            endDialog.SetActive(true);
            Time.timeScale = 0;
        }

    }
}
