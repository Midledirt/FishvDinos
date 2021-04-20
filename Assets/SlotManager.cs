using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public GameObject fish;
    public bool isOccupied = false;
 //   public CardManager cardManager;

    void OnMouseOver()
    {

       

        foreach (CardManager item in GameObject.FindObjectsOfType<CardManager>())
        {
            item.colliderName = this.GetComponent<SlotManager>();
            item.isOverColl = true;
        }

        

        if (fish == null)
        {
            fish = GameObject.FindGameObjectWithTag("Fish");
            if(fish != null)
            {
                fish.transform.SetParent(this.transform);
                Vector3 pos = new Vector3(0, 0, -1);
                fish.transform.localPosition = pos;
            }

        }
    }

    private void OnMouseExit()
    {
      //  Destroy(fish);
    }
}
