using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSystem : MonoBehaviour
{
    public int BubbleValue;
    public AudioSource bubbles;


    private void OnMouseDown()
    {
        GameObject.FindObjectOfType<ResourceManager>().GainResources(BubbleValue);
        bubbles.Play();

        //Destroy(this.gameObject);
    }

    private void OnMouseUp()
    {
        Destroy(gameObject);
    }
}
