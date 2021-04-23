using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrFishAttack : MonoBehaviour
{
    [Tooltip("Set this to the dinosaur layer")]
    [SerializeField] private LayerMask CanBeHit;
    [Tooltip("Set time between shots. Defaults to 1")]
    [SerializeField] private float attackTimer = 1;
    private float timeSinceLastAttack;
    [Tooltip("Decides if this fish can fire projectiles")]
    [SerializeField] private bool canFireProjectiles;
    [Tooltip("The projectile this fish can fire")]
    [SerializeField] private GameObject fishProjectile;
    [Tooltip("Where the projectile is fired from")]
    [SerializeField] private GameObject firePossition;
    public int fishAttackType;

    private void FixedUpdate()
    {
        //print("My attack type is: " + fishAttackType);
        Debug.DrawRay(transform.position, transform.right * 1000f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 1000f, CanBeHit);

        if(hit.collider != null && canFireProjectiles)
        {
            //print("I have a target: " + hit.collider.name);
            FireProjectile();
        }
    }
    public void AssignAttackType(int attacktype)
    {
        fishAttackType = attacktype;
        if (fishAttackType == 1)
        {
            canFireProjectiles = true;
        }
        else
            canFireProjectiles = false;
    }
    private void FireProjectile()
    {
        //Base attack function. Can be expanded and changed if necessary
        timeSinceLastAttack += Time.deltaTime; //Increment time
        if(timeSinceLastAttack >= attackTimer) //Check if enough time has passed
        {
            timeSinceLastAttack = 0; //Reset attack time
            if(firePossition == null)
            {
                //print("Firing projectile, from bodypos!");
                Instantiate(fishProjectile, transform.position, transform.rotation);
                return;
            }
            else if(firePossition != null)
            {
                //print("Firing projectile, from firepos!");
                Instantiate(fishProjectile, firePossition.transform.position, transform.rotation);
            }
        }
    }
    private void OnEnable()
    {
        print("Hi! I am a " + this.gameObject.name + "! Good to meet you :)");
    }
}
