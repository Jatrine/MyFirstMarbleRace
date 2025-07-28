using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleRespawn : MonoBehaviour
{
    private SpawnBlockController block;
    public Vector2 spawnPosition;

    private void Start()
    {
        block = transform.parent.GetComponent<SpawnBlockController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            transform.position = spawnPosition;

            block.InitiliazeMarbleSpeed(gameObject);
        }

        if (collision.gameObject.name == "Duplicate")
        {
            StartCoroutine(block.SpawnMarbles(1));
        }
    }
}
