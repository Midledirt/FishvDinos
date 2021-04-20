using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ProjectileType")]
public class ProjectileStatsSO : ScriptableObject
{
    [Header("Assign sprite")]
    public Sprite ProjectileSprite;
    [Header("Assign stats")]
    public float projectileMovementSpeed;
    public int projectileDamage;
}
