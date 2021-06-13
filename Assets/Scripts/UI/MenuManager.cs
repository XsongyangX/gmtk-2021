using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

public class MenuManager : MonoBehaviour
{
    public GameObject InputRebinderControls;
    private PlayerInput playerInput;

    private void Start()
    {
        this.playerInput = GetComponent<PlayerInput>();
    }

    public void OnMenuButton(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            ControlMenuToggle();
        }
    }

    public void ControlMenuToggle()
    {
        // close the menu and resume
        if (this.InputRebinderControls.activeInHierarchy)
        {
            this.InputRebinderControls.SetActive(false);
            Time.timeScale = 1;

            // unity bug
            // // action map switch
            // this.playerInput.SwitchCurrentActionMap("Player");
        }
        // activate the menu object and pause the game
        else
        {
            Time.timeScale = 0;
            this.InputRebinderControls.SetActive(true);

            // unity bug
            // // action map switch
            // this.playerInput.SwitchCurrentActionMap("UI");
        }
    }

    // public void OnCloseMenuButton()
    // {
    //     this.InputRebinderControls.SetActive(false);
    // }
}
