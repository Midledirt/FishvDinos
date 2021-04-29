using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FishCardManager : MonoBehaviour
{
    [Header("Cards Parameters")]
    public int amtOfCards;
   // int currentamountofcards = 0;
   // int index = 0;
    public FriendlyUnitMenu[] FishCardSO;
    public GameObject CardsPrefab;
    public Transform CardHolderTransform;

    [Header("Fish Parameters")]
    public GameObject[] FishCards;
    public float cooldown;
    public int cost;
    public Sprite fishIcon;

    private void Start()
    {
        
        amtOfCards = FishCardSO.Length;
        FishCards = new GameObject[amtOfCards];

        for (int i = 0; i < amtOfCards; i++)
        {
            AddFishCard(i);
        }
    }

    public void AddFishCard(int index)
    {
        GameObject Card = Instantiate(CardsPrefab, CardHolderTransform);
        CardManager cardManager = Card.GetComponent<CardManager>();

        cardManager.friendlyunitmenu = FishCardSO[index];
        cardManager.fishSprite = FishCardSO[index].fishSprite;
        cardManager.UI = GameObject.FindGameObjectWithTag("Canvas");

        FishCards[index] = Card;

        //getting variebles
        fishIcon = FishCardSO[index].FishIcon;
        cost = FishCardSO[index].cost;
        cooldown = FishCardSO[index].cooldown;

        //updating UI
        Card.GetComponentInChildren<Image>().sprite = fishIcon;
        Card.GetComponentInChildren<TMP_Text>().text = "" + cost;

        //Added by Jont
        FishCardSO[index].ResetStats();
        //print("Attack type is: " + FishCardSO[index].AttackType + "...");
        CardManager newCardManager = FishCards[index].GetComponent<CardManager>();
        newCardManager.SetAttackType(FishCardSO[index].AttackType); //Assigns attack type
        newCardManager.SetFishHealth(FishCardSO[index].FishHealth);
        newCardManager.SetCost(FishCardSO[index].cost); //Assigns cost
        newCardManager.SetCanGenerateResources(FishCardSO[index].CanGenerateResources);
    }
}
