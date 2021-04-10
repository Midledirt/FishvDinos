using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dcoin : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public float FALL_SPEED = 1f;

    public float VERTICAL_DESTINATION = 1F;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Bubbly");
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Scribbly");
    }

    public void OnMouseDown()
    {
        Debug.Log("You pressedme");
    }



    // Update is called once per frame
    //   void Update()
    //{
    //   if (transform.position.y > VERTICAL_DESTINATION)
    //   {
    //      transform.position -= new Vector3(0, -FALL_SPEED);
    // }
    //}
}
