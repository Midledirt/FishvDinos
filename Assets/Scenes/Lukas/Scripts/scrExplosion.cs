using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrExplosion : MonoBehaviour
{
    private bool gonnaExplode;
    private float explosionTimer;
    private float timeSincePlaced;
    [SerializeField] private Vector2 explosionSize;
    [SerializeField] private GameObject bombExplosion;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        if(gonnaExplode)
        {
            timeSincePlaced = 0f;
        }
    }
    private void Update()
    {
        if(gonnaExplode)
        {
            timeSincePlaced += Time.deltaTime;
            if(timeSincePlaced >= explosionTimer)
            {
                Instantiate(bombExplosion, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
    public void SetGonnaExplodeAndTimer(bool _value, float _timer)
    {
        gonnaExplode = _value;
        explosionTimer = _timer;
    }
}
