using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<TestEnemy> dano;
    public List<GameObject> danoprefab;

    private void Update()
    {
        foreach (TestEnemy danos in dano)
        {
            if (danos.isSpawned == false && danos.SpawnTime > Time.time)
            {
                Instantiate(danoprefab[(int)danos.typeofenemy], transform.GetChild(danos.spawner).transform);
                danos.isSpawned = true;
            }
        }
    }

}
