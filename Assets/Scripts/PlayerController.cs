using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    /// <summary>
    /// Where the player is going, (0,0) means stop
    /// </summary>
    //[SerializeField]
    Vector2 direction;

    /// <summary>
    /// How fast the place moves per frame (update call)
    /// </summary>
    [Tooltip("Speed of the player per frame")]
    public float Speed = 0.5f;

    // Unity Monobehavior callbacks
    #region 
    private void Update()
    {
        this.transform.Translate(direction.x * Speed, direction.y * Speed, 0);
    }
    #endregion

    /// <summary>
    /// Listener to a fire event
    /// </summary>
    /// <param name="context">Struct from Unity's Input System</param>
    public void OnFire(InputAction.CallbackContext context)
    {
        print("Fired");
    }

    /// <summary>
    /// Listener to a move stimulus. The 2D stimulus can receive many
    /// inputs at the same time.
    /// started - the action is received by Unity
    /// performed - an input inside the action is completed
    /// canceled - the action has been cancelled/completed
    /// </summary>
    /// <param name="context">Struct from Unity's Input System</param>
    public void OnMove(InputAction.CallbackContext context)
    {
        var value = context.ReadValue<Vector2>();

        // Starting the action does nothing
        if (context.started) {}
        
        // An input is completed inside the action
        else if (context.performed) 
        {
            direction = value;
        }

        // The action is completed or reached a stopped state
        else if (context.canceled) {
            direction = value;
        }

        // exceptional phase
        else throw new UnityException("Unexpected context " + context.phase);
    }
}
