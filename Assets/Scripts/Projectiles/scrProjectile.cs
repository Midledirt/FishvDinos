using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrProjectile : MonoBehaviour
{
    [Header("Assign scriptable object with stats")]
    [SerializeField] private ProjectileStatsSO stats;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        spriteRenderer.sprite = stats.ProjectileSprite;
    }
    private void Update()
    {
        MoveProjectile();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dino"))
        {
            collision.TryGetComponent<scrDinoHealth>(out scrDinoHealth targetHealth);
            targetHealth.TakeDamage(stats.projectileDamage);
            //print("Hit dino!");
            Destroy(this.gameObject);
        }
    }
    private void MoveProjectile()
    {
        transform.Translate(Vector3.right * stats.projectileMovementSpeed * Time.deltaTime);
    }
}
