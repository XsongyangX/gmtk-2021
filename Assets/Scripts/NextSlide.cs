using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextSlide : MonoBehaviour
{
    public string[] texts;
    public Sprite[] sprites;
    public Image demo;
    public Text currText;
    public Button nextButton;
    int countUp = 0;

    private void Update() {
        if(countUp >= texts.Length)
        {
            nextButton.gameObject.SetActive(false);
            return;
        }

        currText.text = texts[countUp];
        demo.sprite = sprites[countUp];

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
