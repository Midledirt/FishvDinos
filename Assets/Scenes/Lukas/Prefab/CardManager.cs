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
    public bool FiresTwoAttacks { get; private set; }
    public int FishHealth { get; private set; }
    public bool CanGenerateResources { get; private set; }

    public bool ExplodeSettings { get; private set; }
    public float ExplosionTimer { get; private set; }
    public bool HasMeleeAttack { get; private set; }
    public int MeleeDamage { get; private set; }

    private void Awake()
    {
        resourceManager = ResourceManager.instance;
    }
    public void SetMelleAttack(bool value, int _damage)
    {
        HasMeleeAttack = value;
        MeleeDamage = _damage;
    }
    public void SetFiresTwoAttacks(bool value)
    {
        FiresTwoAttacks = value;
    }
    public void SetAttackType(int _type)
    {
        //print("Assigned attack is: " + _type);
        AttackType = _type;
    }
    public void SetFishHealth(int _amount)
    {
        FishHealth = _amount;
    }
    public void SetCanGenerateResources(bool value)
    {
        CanGenerateResources = value;
    }
    public void SetExplosionSettings(bool value, float timer)
    {
        ExplodeSettings = value;
        ExplosionTimer = timer;
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
            if (!colliderName.isOccupied)
            {

               fish.transform.position = new Vector3(0, 0, -1);
                fish.transform.localPosition = new Vector3(0, 0, -1);
                 isOverColl = false;

                if (prevName != null)
                {
                  prevName.fish = null;

                }
                 prevName = colliderName;
            }
        }
        else
        {
            if(!colliderName.isOccupied)
            {
                fish.transform.position = new Vector3(0, 0, -1);
                fish.transform.localPosition = new Vector3(0, 0, -1);

            }
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
        fish.transform.localScale = friendlyunitmenu.size;
        fish.GetComponent<SpriteRenderer>().sprite = fishSprite;

        //Added by Jont
        scrFishAttack fishAttack = fish.GetComponent<scrFishAttack>();
        fishAttack.AssignAttackType(AttackType);
        fishAttack.AssignDoubleAttack(FiresTwoAttacks);
        fishAttack.AssignMelleAttack(HasMeleeAttack, MeleeDamage);
        scrFishHealth fishHealth = fish.GetComponent<scrFishHealth>();
        fishHealth.AssignHealth(FishHealth);
        scrFishResourceGeneration fishResourceGeneration = fish.GetComponent<scrFishResourceGeneration>();
        fishResourceGeneration.SetCanGenerateResources(CanGenerateResources);
        scrExplosion fishExplosion = fish.GetComponent<scrExplosion>();
        fishExplosion.SetGonnaExplodeAndTimer(ExplodeSettings, ExplosionTimer);

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
