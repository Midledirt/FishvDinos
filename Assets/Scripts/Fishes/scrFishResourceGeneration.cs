using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrFishResourceGeneration : MonoBehaviour
{
    private ResourceManager resourceManager;

    private bool canGenerateResources;
    [SerializeField] private int resourcesGainedPerCycle;
    [SerializeField] private float timeBetweenNewResources;
    private float timeSincePreviousResources;

    private void Awake()
    {
        resourceManager = ResourceManager.instance;
    }
    private void Start()
    {
        timeSincePreviousResources = 0f;
    }
    private void Update()
    {
        timeSincePreviousResources += Time.deltaTime; //Increment the timer
        if(canGenerateResources && timeSincePreviousResources > timeBetweenNewResources)
        {
            timeSincePreviousResources = 0f; //Reset the timer
            resourceManager.GainResources(resourcesGainedPerCycle); //Gain resources
            //print("Just produced " + resourcesGainedPerCycle + " amount of resources!");
        }
    }
    public void SetCanGenerateResources(bool value)
    {
        canGenerateResources = value;
    }
}
