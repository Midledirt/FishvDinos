using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrExplosionScript : MonoBehaviour
{
    private float bombTimer;
    private float timeSinceExplosion;
    private void Start()
    {
        timeSinceExplosion = 0f;
        bombTimer = 2f;
    }
    private void Update()
    {
        timeSinceExplosion += Time.deltaTime;
        if(timeSinceExplosion >= bombTimer)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dino"))
        {
            collision.TryGetComponent<scrDinoHealth>(out scrDinoHealth dinoHealth);
            dinoHealth.TakeDamage(10);
        }
    }
}
