using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class scrFishHealth : MonoBehaviour
{
    public static Action<GameObject> OnFishKilled;
    private int fishHealth;
    public AudioSource fishdamage;

    private void Awake()
    {
        fishdamage = GetComponent<AudioSource>();
    }

    public void TakeDamage(scrFishHealth _target, int _damage)
    {
        if(_target == this)
        {
            fishHealth -= _damage;
            print("I TOOK " + _damage + " DAMAGE!");
            fishdamage.Play();
            if (fishHealth <= 0)
            {
                FishDies();
            }
        }

    }
    public void AssignHealth(int _amount)
    {
        fishHealth = _amount;
    }
    private void FishDies()
    {
        //Free up the space
        OnFishKilled?.Invoke(this.gameObject); //Used to tell the slot manager that the space is freed up
        //Kill the fish
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
