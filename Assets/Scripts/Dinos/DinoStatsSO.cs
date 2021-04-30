using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dinosaur/Stats")]
public class DinoStatsSO : ScriptableObject
{
    [Tooltip("The amount of healt this dino has")]
    [SerializeField] private int health;
    [Tooltip("The minimum score you get from defeating this dino")]
    [SerializeField] private int dinoScore;
    [Tooltip("How fast the dino attacks. A higher number means a slower attack")]
    [SerializeField] private float dinoAttackRate;
    [Tooltip("How fast the dino moves.")]
    [Range(0.2f, 1.2f)]
    [SerializeField] private float dinoMovementSpeed;


    public int Health { get; private set; }
    public int DinoScore { get; private set; }
    public float DinoAttackRate { get; private set; }
    public float DinoMovementSPeed { get; private set; }

    public void ResetStats()
    {
        Health = health;
        DinoScore = dinoScore;
        DinoAttackRate = dinoAttackRate;
        DinoMovementSPeed = (dinoMovementSpeed / 20);
    }
}
