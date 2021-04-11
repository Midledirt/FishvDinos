using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Fish Cards", fileName ="New Fish Card")]

public class FriendlyUnitMenu : ScriptableObject
{
    public Texture FishIcon;
    public Sprite fishSprite;
    public int cost;
    public float cooldown;

}
