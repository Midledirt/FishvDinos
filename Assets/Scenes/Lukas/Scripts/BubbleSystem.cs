using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSystem : MonoBehaviour
{
    public int BubbleValue;
    public AudioSource bubblesAudio;

    private void Awake()
    {
        bubblesAudio = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        GameObject.FindObjectOfType<ResourceManager>().GainResources(BubbleValue);
        bubblesAudio.Play();

        //Destroy(this.gameObject);
    }

    private void OnMouseUp()
    {
        Destroy(gameObject);
    }
}
