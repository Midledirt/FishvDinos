using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    [Tooltip("Set this to the dinosaur layer")]
    [SerializeField] private LayerMask CanBeHit;
    [Tooltip("Set time between shots. Defaults to 1")]
    [SerializeField] private float bombTimer = 1;

    [Tooltip("Decides if this fish can fire projectiles")]
    [SerializeField] private bool canBlowUp = true;
    [Tooltip("The projectile this fish can fire")]
    [SerializeField] private GameObject fishBomb;
    [Tooltip("Where the projectile is fired from")]
    [SerializeField] private GameObject BombPos;
    
   
    public bool blownup = false;



    private void FixedUpdate()
    {
       
        Debug.DrawRay(transform.position, transform.right * 1000f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1000f, CanBeHit);

        if (hit.collider != null && canBlowUp == true)
        {
           
            BlowUp();
            Debug.Log("CanBlowUp");

        }
    }


    private void BlowUp()
    {
    
         //   if (BombPos == null)
         //   {
                //print("Firing projectile, from bodypos!");
             //   Instantiate(fishBomb, transform.position, transform.rotation);
         //       return;
        //    }
         //   else if (BombPos != null)
         //   {
                //print("Firing projectile, from firepos!");
                Instantiate(fishBomb, BombPos.transform.position, transform.rotation);
              Debug.Log("BOMBPREFAB");
        //    }

        blownup = true;
        
    }

    private void Update()
    {
        if (blownup == true)
        {
            Debug.Log("WentBoomb");
            Destroy(gameObject, 2);
        }
    }

}
