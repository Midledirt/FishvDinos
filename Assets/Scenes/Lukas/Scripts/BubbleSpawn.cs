using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawn : MonoBehaviour
{
    public float minTime;
    public float maxTime;
    public float time;

    public GameObject bubbles;
    public Vector2 minPos;
    public Vector2 maxPos;
    Vector3 pos;


    // Start is called before the first frame update
    private void Start()
    {
        time = Random.Range(minTime, maxTime);
        pos.x = Random.Range(minPos.x, maxPos.x);
        pos.y = Random.Range(minPos.y, maxPos.y);
        pos.z = -1;
        StartCoroutine(SpawnBubble());
    }

    // Update is called once per frame
    public IEnumerator SpawnBubble()
    {
        yield return new WaitForSeconds(time);
        Instantiate(bubbles, pos, Quaternion.identity);
       
        time = Random.Range(minTime, maxTime);
        pos.x = Random.Range(minPos.x, maxPos.x);
        pos.y = Random.Range(minPos.y, maxPos.y);
        pos.z = -1;
       StartCoroutine(SpawnBubble());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bubble")
        {
            Destroy(collision.gameObject);
        }
    }
}
