using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrDinoHealth : MonoBehaviour
{
    [SerializeField] private int health;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            print("Ouch taking this much damage: " + 1);
            TakeDamage(1);
        }
    }

    public void TakeDamage(int _damage)
    {
        health -= _damage;
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
