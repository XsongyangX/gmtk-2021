using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextSlide : MonoBehaviour
{
    public string[] texts;
    public Text currText;
    public Button nextButton;
    public GameObject treasureChest;
    public GameObject winScreen;
    int countUp = 0;

    private void Update() {
        if(countUp >= texts.Length)
        {
            nextButton.gameObject.SetActive(false);
            this.transform.parent.gameObject.SetActive(false);
            Time.timeScale = 1;
            Destroy(treasureChest);
            Win();
            return;
        }

        currText.text = texts[countUp];

    }
    
    // Update is called once per frame

    public void GoToNextSlide()
    {
        if (countUp < texts.Length)
        {
            countUp++;
        }
    }

    void Win()
    {
        winScreen.SetActive(true);
    }
}
