using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/Fish Cards", fileName ="New Fish Card")]

public class FriendlyUnitMenu : ScriptableObject
{

    public Vector2 size;
    public Sprite FishIcon;
    public Sprite fishSprite;
  //  public Sprite fishcard;
    public int cost;
    public float cooldown;
    [Tooltip("Decides what type of attack the fish does. 0 = no attack. 1 = basic attack.")]
    [Range(0, 1)]
    [SerializeField] private int attacktype;
    [Range(2, 20)]
    [Tooltip("Decides how much health the fish has")]
    [SerializeField] private int fishHealth;
    [Tooltip("Decides if the fish generates resources passively")]
    [SerializeField] private bool canGenerateResources;
    [SerializeField] public bool canExplode;
    public int AttackType { get; private set; }
    public int FishHealth { get; private set; }
    public bool CanGenerateResources { get; private set; }

    public bool CanExplode { get; private set; }

    public void ResetStats()
    {
        CanGenerateResources = canGenerateResources;
        AttackType = attacktype;
        FishHealth = fishHealth;
        CanExplode = canExplode;
    }
}
