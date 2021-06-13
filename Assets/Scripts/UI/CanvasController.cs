using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public Canvas tutorialCanvas;

   public void closeTutorialMenu()
    {
            Image img = this.GetComponentInParent(typeof(Image)) as Image;
        if (img != null)
            img.enabled = false;
        }
    }
