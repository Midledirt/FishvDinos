using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDinoHealth : MonoBehaviour
{
    private int health;
    private ResourceManager resourceManager;
    private int dinoScore;
    private scrDino dino;

    private scrDinoStats statsHolder;

    private void Awake()
    {
        statsHolder = GetComponent<scrDinoStats>();
        dino = GetComponent<scrDino>();
    }

    private void Start()
    {
        resourceManager = ResourceManager.instance; //Get the instance
        health = statsHolder.Stats.Health;
        dinoScore = statsHolder.Stats.DinoScore;
    }

    public void TakeDamage(int _damage)
    {
        health -= _damage;
        //print("Ouch! Took " + _damage + " damage.");
        if(health <= 0f)
        {
            DinoDies();
        }
    }
    private void DinoDies()
    {
        //Check distance from goal:
        float distanceRemaining = (transform.position - dino.dinoGoalPos).magnitude;
        if(distanceRemaining < (dino.mapLength * 0.85f) && distanceRemaining > (dino.mapLength * 0.65f))
        {
            print("Dino had traveled at least 1/4 of map distance...");
            //Increase score
            dinoScore += (dinoScore / 4);
            print("Score gained is thus: " + dinoScore);
            resourceManager.GainResources(dinoScore);
            //Kill the dino
            Destroy(this.gameObject);
            return;
        }
        if(distanceRemaining < (dino.mapLength * 0.65f) && distanceRemaining > (dino.mapLength * 0.40f))
        {
            print("Dino had traveled at least 1/2 of map distance...");
            //Increase score
            dinoScore += (dinoScore / 2);
            print("Score gained is thus: " + dinoScore);
            resourceManager.GainResources(dinoScore);
            //Kill the dino
            Destroy(this.gameObject);
            return;
        }
        if(distanceRemaining <= (dino.mapLength * 0.40f))
        {
            print("Dino had traveled at least 3/4 of map distance...");
            //Increase score
            dinoScore += dinoScore;
            print("Score gained is thus: " + dinoScore);
            resourceManager.GainResources(dinoScore);
            //Kill the dino
            Destroy(this.gameObject);
            return;
        }
        else if(distanceRemaining >= (dino.mapLength * 0.75f))
        {
            print("Dino had not traveled far at all...");
            //Increase score
            print("Score gained is thus: " + dinoScore);
            resourceManager.GainResources(dinoScore);
            //Kill the dino
            Destroy(this.gameObject);
            return;
        }
    }
}
