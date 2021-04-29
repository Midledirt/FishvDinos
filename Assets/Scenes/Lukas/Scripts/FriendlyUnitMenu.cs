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
    [Tooltip("Decides if this fish fires two projectiles right afther each other")]
    [SerializeField] private bool firesTwoAttacks;
    [Range(2, 20)]
    [Tooltip("Decides how much health the fish has")]
    [SerializeField] private int fishHealth;
    [Tooltip("Decides if the fish generates resources passively")]
    [SerializeField] private bool canGenerateResources;
    [Tooltip("Decides if this fish will explode or not")]
    [SerializeField] private bool canExplode;
    [Tooltip("Set how much time it takes before this fish explodes")]
    [SerializeField] private float explotionTimer;
    [Tooltip("Decides if this fish has a melee attack")]
    [SerializeField] private bool hasMeleeAttack;
    [Tooltip("Decides how much melee damage this fish does")]
    [SerializeField] private int meleeDamage;
    public int AttackType { get; private set; }
    public int FishHealth { get; private set; }
    public bool CanGenerateResources { get; private set; }
    public bool FiresTwoAttacks { get; private set; }
    public float ExplotionTimer { get; private set; }
    public bool HasMeleeAttack { get; private set; }
    public int MelleDamage { get; private set; }
    public bool CanExplode { get; private set; }

    public void ResetStats()
    {
        CanGenerateResources = canGenerateResources;
        AttackType = attacktype;
        FishHealth = fishHealth;
        CanExplode = canExplode;
        ExplotionTimer = explotionTimer;
        FiresTwoAttacks = firesTwoAttacks;
        HasMeleeAttack = hasMeleeAttack;
        MelleDamage = meleeDamage;
    }
}
