using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private ResourceManager resourceManager;
    public GameObject UI;
    public Sprite fishSprite;
    public FriendlyUnitMenu friendlyunitmenu;
    public GameObject fishPrefab;
    GameObject fish;
    public bool isOverColl = false;
    public SlotManager colliderName;
    SlotManager prevName;
    public int FishCost { get; private set; }
    public int AttackType { get; private set; }
    private void Awake()
    {
        resourceManager = ResourceManager.instance;
    }
    public void SetAttackType(int _type)
    {
        //print("Assigned attack is: " + _type);
        AttackType = _type;
    }
    public void SetCost(int _cost)
    {
        //print("My cost is: " + _cost);
        FishCost = _cost;
    }
    public void OnDrag(PointerEventData eventData)
    {
      //  fishSprite = friendlyunitmenu.fishSprite;
        fish.GetComponent<SpriteRenderer>().sprite = fishSprite;
        if (prevName != colliderName || prevName == null)
        {
            isOverColl = false;

            if (prevName != null)
            {
                prevName.fish = null;

            }
                prevName = colliderName;
        }

        if (!isOverColl)
        {
             fish.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
         //   UI.SetActive(false);

           
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 pos = new Vector3(0, 0, -1);
        fish = Instantiate(fishPrefab, pos, Quaternion.identity);
        fish.GetComponent<SpriteRenderer>().sprite = fishSprite;

        //Added by Jont
        scrFishAttack fishAttack = fish.GetComponent<scrFishAttack>();
        fishAttack.AssignAttackType(AttackType);

        //  fishSprite = friendlyunitmenu.fishSprite;
        fish.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // fishSprite = null;
        // Destroy(fish);
       // UI.SetActive(true);
       if (colliderName != null && !colliderName.isOccupied)
       {
            //Resources check
            if(resourceManager.Resources < FishCost)
            {
                print("Could not afford the fish");
                Destroy(fish);
                return;
            }
            resourceManager.SpendResources(FishCost); //Spend resources
            colliderName.isOccupied = true;
            fish.tag = "Untagged";
            fish.transform.SetParent(colliderName.transform);
            fish.transform.position = new Vector3(0, 0, -1);
            fish.transform.localPosition = new Vector3(0, 0, -1);
        }
        else
        {
            Destroy(fish);
        }
    }

    
}
