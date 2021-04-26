using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// THIS SCRIPT IS NOT COMPLETE YET:
/// There needs to be a way to spawn different enemy types!
/// </summary>

public class scrDinoSpawner : MonoBehaviour
{
    GameManager gameManager;

    [Header("Assign dinos")]
    [Tooltip("Drag all dinos here")]
    [SerializeField] private GameObject[] dinos;
    private GameObject dino;
    [SerializeField] private GameObject[] spawnPossitions; //Needs to be set in inspector
    private int currentWaveSize;

    [Header("Customize waves")]
    [Tooltip("How many waves there are in total")]
    [SerializeField] private int numberOfWaves;
    [Tooltip("How much time there is from one wave is defeated, before a new starts")]
    [SerializeField] private float timeBetweenWaves;
    [Tooltip("The size of the first wave")]
    [SerializeField] private int startingWaveSize;
    [Tooltip("How many new dinos there are per wave")]
    [SerializeField] private int numberOfNewDinosPerWave;
    private float timeSinceLastWave;
    private float gameWonTimer; //Used to prevent the game from ending on the exact frame the last dino dies
    public int CurrentWave { get; private set; }

    private void Start()
    {
        CurrentWave = 0;
        timeSinceLastWave = 0;
        currentWaveSize = startingWaveSize;
        gameManager = GameManager.instance; //Get the instance
        gameWonTimer = 0f;
    }

    private void Update()
    {
        CheckForDinoesLeft();
    }
    private void CheckForDinoesLeft()
    {
        List<GameObject> _dinosLeft = new List<GameObject>();
        foreach(GameObject dino in GameObject.FindGameObjectsWithTag("Dino"))
        {
            _dinosLeft.Add(dino);
        }
        //print("These are the dinos left: " + _dinosLeft.Count);
        if(_dinosLeft.Count <= 0)
        {
            timeSinceLastWave += Time.deltaTime; //Increment timer
            if (timeSinceLastWave >= timeBetweenWaves && CurrentWave < numberOfWaves) //Spawn new waves
            {
                timeSinceLastWave = 0f; //Reset timer
                SpawnNewWave(); //Spawn the wave
                currentWaveSize += numberOfNewDinosPerWave; //Increment wave size
                CurrentWave += 1; //Increment current wave
                return;
            }
            if (CurrentWave >= numberOfWaves && _dinosLeft.Count <= 0)
            {
                gameWonTimer += Time.deltaTime;
                if(gameWonTimer >= 6)
                {
                    GameWon(); //End the game
                }
            }
        }
    }
    private void GameWon()
    {
        //print("Game Won");
        gameManager.SetGameWonPanel();
    }
    private GameObject GetRandomDino() //Returns a random dino from the array
    {
        GameObject _dino = dinos[Random.Range(0, dinos.Length)];
        return dino = _dino;
    }
    private void SpawnNewWave()
    {
        for(int i = 0; i < currentWaveSize; i++)
        {
            StartCoroutine(SpawnDelay(GetRandomNumber(0, 10))); //Runs the spawn function, at random time
        }
    }
    private void SpawnEnemy()
    {
        //Select spawn possition randomly
        var location = GetRandomPossition();
        //Get random number between the length of the spawn array

        switch(location)
        {
            case 0:
                GameObject newdinoInstancePos0 = Instantiate(GetRandomDino(), spawnPossitions[0].transform.position,Quaternion.identity,transform);
                scrDino dinoMovement0 = newdinoInstancePos0.GetComponent<scrDino>();
                dinoMovement0.AssignGoalPos(spawnPossitions[0]);
                return;            
            case 1:
                GameObject newdinoInstancePos1 = Instantiate(GetRandomDino(), spawnPossitions[1].transform.position,Quaternion.identity,transform);
                scrDino dinoMovement1 = newdinoInstancePos1.GetComponent<scrDino>();
                dinoMovement1.AssignGoalPos(spawnPossitions[1]);
                return;            
            case 2:
                GameObject newdinoInstancePos2 = Instantiate(GetRandomDino(), spawnPossitions[2].transform.position,Quaternion.identity,transform);
                scrDino dinoMovement2 = newdinoInstancePos2.GetComponent<scrDino>();
                dinoMovement2.AssignGoalPos(spawnPossitions[2]);
                return;            
            case 3:
                GameObject newdinoInstancePos3 = Instantiate(GetRandomDino(), spawnPossitions[3].transform.position,Quaternion.identity,transform);
                scrDino dinoMovement3 = newdinoInstancePos3.GetComponent<scrDino>();
                dinoMovement3.AssignGoalPos(spawnPossitions[3]);
                return;
            case 4:
                GameObject newdinoInstancePos4 = Instantiate(GetRandomDino(), spawnPossitions[4].transform.position, Quaternion.identity, transform);
                scrDino dinoMovement4 = newdinoInstancePos4.GetComponent<scrDino>();
                dinoMovement4.AssignGoalPos(spawnPossitions[4]);
                return;
        }
    }
    private IEnumerator SpawnDelay(float _spawndelay)
    {
        yield return new WaitForSeconds(_spawndelay);
        SpawnEnemy();
    }
    private int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
    private int GetRandomPossition() //Returns a random number between 0 and the length of the spawnPossitions array
    {
        return Random.Range(0, spawnPossitions.Length);
    }
}
