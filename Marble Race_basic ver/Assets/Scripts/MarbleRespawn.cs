using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleRespawn : MonoBehaviour
{
    public Vector2 spawnPosition;
    private float spawnForce = 0.5f;

    private void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            transform.position = spawnPosition;
            
            float randomAngle = Random.Range(-180f, 0f);
            Vector2 forceDirection = new Vector2(
                Mathf.Cos(randomAngle * Mathf.Deg2Rad),
                Mathf.Sin(randomAngle * Mathf.Deg2Rad)
            ).normalized;

            transform.GetComponent<Rigidbody2D>().AddForce(forceDirection * spawnForce, ForceMode2D.Impulse);
        }

        if (collision.gameObject.name == "Duplicate")
        {
            StartCoroutine(transform.parent.GetComponent<SpawnBlockController>().SpawnMarbles(1));
        }
    }
}
