using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyMakarelExplosion : MonoBehaviour
{
    [Header("Assign scriptable object with stats")]
    [SerializeField] private BombStats stats;
    private SpriteRenderer spriteRenderer;
   // private float projectileTimeBeforeDespawn = 20f;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        spriteRenderer.sprite = stats.BomberSprite;
    }
    private void Update()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dino"))
        {
            collision.TryGetComponent<scrDinoHealth>(out scrDinoHealth targetHealth);
            targetHealth.TakeDamage(stats.BombDamage);
            //print("Hit dino!");
            Destroy(this.gameObject);
        }
    }
  





  
}
