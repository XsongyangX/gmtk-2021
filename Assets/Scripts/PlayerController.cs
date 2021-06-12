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
    public float Speed = 3f;

    /// <summary>
    /// Where the cursor is in world coords
    /// </summary>
    public Vector3 Aim;
    
    /// <summary>
    /// This is to shoot from the main player
    /// </summary>
    public PlayerWeaponController MainPlayerSprite;
    
    /// <summary>
    /// This is to shoot from the split image
    /// </summary>
    public PlayerWeaponController SplitPlayerSprite;

    private PlayerSplit playerSplit;

    // Unity Monobehavior callbacks
    #region 

    private void Start()
    {
        this.playerSplit = GetComponent<PlayerSplit>();
    }

    private void Update()
    {
        // move
        this.transform.Translate(direction * Speed * Time.deltaTime);
        
        // aim
        this.Aim = Camera.main.ScreenToWorldPoint(
            Mouse.current.position.ReadValue()
        );
        this.Aim.z = 0;
    }
    #endregion

    /// <summary>
    /// Listener to a fire event
    /// </summary>
    /// <param name="context">Struct from Unity's Input System</param>
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.canceled)
        {
            MainPlayerSprite.ShootBullet(this.Aim);
            if (SplitPlayerSprite.isActiveAndEnabled) SplitPlayerSprite.ShootBullet(this.Aim);
        }
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

    /// <summary>
    /// Listener to the split action
    /// </summary>
    /// <param name="context"></param>
    public void OnSplit(InputAction.CallbackContext context)
    {
        if (context.canceled) {
            // split if only one sprite is active

            if (this.SplitPlayerSprite.isActiveAndEnabled) this.playerSplit.OnMerge();
            else this.playerSplit.OnSplit();
        }
    }
}
