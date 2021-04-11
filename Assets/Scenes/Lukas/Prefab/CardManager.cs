using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardManager : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Sprite fishSprite;
    public FriendlyUnitMenu friendlyunitmenu;
    public GameObject fishPrefab;
    GameObject fish;
    public void OnDrag(PointerEventData eventData)
    {
      //  fishSprite = friendlyunitmenu.fishSprite;
        fish.GetComponent<SpriteRenderer>().sprite = fishSprite;
        fish.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
     //   fishSprite = friendlyunitmenu.fishSprite;
        fish = Instantiate(fishPrefab, Vector3.zero, Quaternion.identity);
        fish.GetComponent<SpriteRenderer>().sprite = fishSprite;

        fish.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    public void OnPointerUp(PointerEventData eventData)
    {
       // fishSprite = null;
      //  Destroy(fish);
    }

    
}
