using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerSplit : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerWeaponController splitSprite;

    private void Start()
    {
        this.playerController = GetComponent<PlayerController>();
        this.splitSprite = playerController.SplitPlayerSprite;
    }

    /// <summary>
    /// When the player splits, the split sprite is hurled out of
    /// the main sprite
    /// </summary>
    public void OnSplit()
    {
        // activate
        this.splitSprite.gameObject.SetActive(true);

        // spawn at a left-right mirror position
        Vector3 middleScreen = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        middleScreen.z = 0;
        Vector3 spawnedPosition = -(
                    this.transform.position
                    -
                    middleScreen
                );
        spawnedPosition.y = this.transform.position.y;
        this.splitSprite.transform.position = spawnedPosition;
    }

    /// <summary>
    /// When the player merges back, the split sprite comes back
    /// to the player
    /// </summary>
    public void OnMerge()
    {
        // return
        this.splitSprite.transform.localPosition = Vector3.zero;

        // deactivate
        this.splitSprite.gameObject.SetActive(false);
    }
}
