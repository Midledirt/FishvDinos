using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BombType")]
public class BombStats : ScriptableObject
{
    [Header("Assign sprite")]
    public Sprite BomberSprite;
    [Header("Assign stats")]
    //public float projectileMovementSpeed;
    public int BombDamage;
}
