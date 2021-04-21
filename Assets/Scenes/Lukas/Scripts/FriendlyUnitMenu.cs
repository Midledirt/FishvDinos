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
    [Tooltip("Decides what type of attack the fish does. 0 = no attack. 1 = basic attack.")]
    [Range(0, 1)]
    [SerializeField] private int attacktype;
    public int AttackType { get; private set; }

    public void ResetStats()
    {
        AttackType = attacktype;
    }
}
