using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestEnemy : MonoBehaviour
{
    public int SpawnTime = 2;
    public EnemyType typeofenemy;
    public int spawner;
    public bool RandomSpawn;
    public bool isSpawned;


    public enum EnemyType
    {
        Biggy,
        Smally,
        Medium,
    }
}
