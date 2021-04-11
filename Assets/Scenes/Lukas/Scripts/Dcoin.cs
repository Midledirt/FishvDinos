using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dcoin : MonoBehaviour, IPointerDownHandler
{
    public float FALL_SPEED = 1f;

    public float VERTICAL_DESTINATION = 1F;

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Bubbly");
        
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
