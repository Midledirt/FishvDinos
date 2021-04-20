using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrFishHealth : MonoBehaviour
{
    [SerializeField] private int fishHealth;

    public void TakeDamage(scrFishHealth _target, int _damage)
    {
        if(_target == this)
        {
            fishHealth -= _damage;
            print("I TOOK " + _damage + " DAMAGE!");
            if (fishHealth <= 0)
            {
                FishDies();
            }
        }

    }
    private void FishDies()
    {
        Destroy(this.gameObject);
    }
    private void OnEnable()
    {
        scrDino.OnDealingDamage += TakeDamage;
    }
    private void OnDisable()
    {
        scrDino.OnDealingDamage -= TakeDamage;
    }
}
