using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager instance;
    [Tooltip("Drag the score from the Canvas -> Fish slot -> Resource to this field")]
    [SerializeField] private TextMeshProUGUI currentResources;
    [Tooltip("How many resources the player starts with")]
    [SerializeField] private int startingResources;

    public int Resources { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Resources = startingResources;
        currentResources.text = Resources.ToString();
    }

    public void GainResources(int _amount)
    {
        //print("Resources updated");
        Resources += _amount; //Update the variable
        currentResources.text = Resources.ToString(); //Update the text
    }
    public void SpendResources(int _amount)
    {
        Resources -= _amount; //Update the variable
        currentResources.text = Resources.ToString(); //Update the text
    }
}
