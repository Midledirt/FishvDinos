using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// THIS SCRIPT IS NOT COMPLETE YET:
/// There needs to be a way to spawn different enemy types!
/// </summary>

public class scrDinoSpawner : MonoBehaviour
{
    public int CurrentWave { get; set; }

    [SerializeField] private GameObject dino;
    [SerializeField] private GameObject[] spawnPossitions; //Needs to be set in inspector
    private int currentWaveSize = 5;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //For testing
        {
            SpawnNewWave();
            CurrentWave += 1;
        }
    }
    private void SpawnNewWave()
    {
        for(int i = 0; i < currentWaveSize; i++)
        {
            StartCoroutine(SpawnDelay(GetRandomNumber() * .2f)); //Runs the spawn function, at random time
        }
    }
    private void SpawnEnemy()
    {
        //Select spawn possition randomly
        var location = GetRandomNumber();
        //Get random number between the length of the spawn array

        switch(location)
        {
            case 0:
                GameObject newdinoInstancePos0 = Instantiate(dino, spawnPossitions[0].transform.position,Quaternion.identity,transform);
                scrDinoMovement dinoMovement0 = newdinoInstancePos0.GetComponent<scrDinoMovement>();
                dinoMovement0.AssignGoalPos(spawnPossitions[0]);
                return;            
            case 1:
                GameObject newdinoInstancePos1 = Instantiate(dino, spawnPossitions[1].transform.position,Quaternion.identity,transform);
                scrDinoMovement dinoMovement1 = newdinoInstancePos1.GetComponent<scrDinoMovement>();
                dinoMovement1.AssignGoalPos(spawnPossitions[1]);
                return;            
            case 2:
                GameObject newdinoInstancePos2 = Instantiate(dino, spawnPossitions[2].transform.position,Quaternion.identity,transform);
                scrDinoMovement dinoMovement2 = newdinoInstancePos2.GetComponent<scrDinoMovement>();
                dinoMovement2.AssignGoalPos(spawnPossitions[2]);
                return;            
            case 3:
                GameObject newdinoInstancePos3 = Instantiate(dino, spawnPossitions[3].transform.position,Quaternion.identity,transform);
                scrDinoMovement dinoMovement3 = newdinoInstancePos3.GetComponent<scrDinoMovement>();
                dinoMovement3.AssignGoalPos(spawnPossitions[3]);
                return;
        }
    }
    private IEnumerator SpawnDelay(float _spawndelay)
    {
        yield return new WaitForSeconds(_spawndelay);
        SpawnEnemy();
    }
    private int GetRandomNumber() //Returns a random number between 0 and the length of the spawnPossitions array
    {
        return Random.Range(0, spawnPossitions.Length);
    }
}
