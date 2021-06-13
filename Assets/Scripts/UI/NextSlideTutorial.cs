using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextSlideTutorial : MonoBehaviour
{
    public string[] texts;
    public Sprite[] sprites;
    public Text currText;
    public Image img;
    public Button nextButton;
    int countUp = 0;

    private void Update() {
        if(countUp >= texts.Length)
        {
            nextButton.gameObject.SetActive(false);
            this.transform.parent.gameObject.SetActive(false);
            Time.timeScale = 1;
            return;
        }

        currText.text = texts[countUp];
        img.sprite = sprites[countUp];
    }
    
    // Update is called once per frame

    public void GoToNextSlide()
    {
        if (countUp < texts.Length)
        {
            countUp++;
        }
    }
}
