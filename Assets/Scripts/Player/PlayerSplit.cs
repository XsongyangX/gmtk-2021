using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerSplit : MonoBehaviour
{
    private PlayerController playerController;
    private PlayerWeaponController splitSprite;
    private PlayerWeaponController mainSprite;

    private void Start()
    {
        this.playerController = GetComponent<PlayerController>();
        this.splitSprite = playerController.SplitPlayerSprite;
        this.mainSprite = playerController.MainPlayerSprite;
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
        var mainSpriteViewport = Camera.main.WorldToViewportPoint(this.mainSprite.transform.position);
        var splitSpriteViewport = Vector3.one - mainSpriteViewport;
        splitSpriteViewport.z = mainSpriteViewport.z;
        splitSpriteViewport.y = mainSpriteViewport.y;
        this.splitSprite.transform.position = Camera.main.ViewportToWorldPoint(splitSpriteViewport);
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
