using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSystem : MonoBehaviour
{
    public int BubbleValue;

    private void OnMouseDown()
    {
        GameObject.FindObjectOfType<ResourceManager>().GainResources(BubbleValue);

        //Destroy(this.gameObject);
    }

    private void OnMouseUp()
    {
        Destroy(gameObject);
    }
}
