using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDinoHealth : MonoBehaviour
{
    [SerializeField] private int health;


    public void TakeDamage(int _damage)
    {
        health -= _damage;
        print("Ouch! Took " + _damage + " damage.");
        if(health <= 0f)
        {
            DinoDies();
        }
    }
    private void DinoDies()
    {
        //Increase score

        //Kill the dino
        Destroy(this.gameObject);
    }
}
