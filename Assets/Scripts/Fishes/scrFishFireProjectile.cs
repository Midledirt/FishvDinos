using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrFishFireProjectile : MonoBehaviour
{
    [SerializeField] private LayerMask CanBeHit;

    [Tooltip("Sets the time between each attack")]
    [SerializeField] private float attackTimer;
    private float timeSinceLastAttack;
    private void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.right * 1000f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1000f, CanBeHit);

        if(hit.collider != null)
        {
            print("I have a target: " + hit.collider.name);
            FireProjectile();
        }
    }
    private void FireProjectile()
    {
        //Base attack function. Can be expanded and changed if necessary
        timeSinceLastAttack += Time.deltaTime; //Increment time
        if(timeSinceLastAttack >= attackTimer) //Check if enough time has passed
        {
            timeSinceLastAttack = 0; //Reset attack time

        }
    }
    private void OnEnable()
    {
        print("Hi! I am a " + this.gameObject.name + "! Good to meet you :)");
    }
}
