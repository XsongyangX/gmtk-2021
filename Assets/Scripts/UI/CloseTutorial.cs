using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTutorial : MonoBehaviour
{
    public void CloseTutorialWindow()
    {
        this.transform.parent.gameObject.SetActive(false);
    }
}
