using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDinoStats : MonoBehaviour
{
    [Header("Assign stats scriptable object for dinosaur")]
    public DinoStatsSO Stats;

    private void Awake()
    {
        if(Stats != null)
        {
            Stats.ResetStats();
        }
        else
            Debug.LogError("You have not assigned stats for: " + gameObject.name + " You can do so in the prefab");
    }
}
