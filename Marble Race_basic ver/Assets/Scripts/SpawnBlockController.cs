using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpawnBlockController : MonoBehaviour
{
    [SerializeField]
    private int initialMarbles = 3;
    public int ExistingMarbles = 0;
    public Color MarbleColor;

    private string prefabPath = "Assets/Prefabs/Marble.prefab";
    private GameObject prefab;
    private Vector2 spawnPosition;
    public float spawnSpeed = 1f;

    private void Start()
    {
        spawnPosition = transform.Find("Spawn Point").position;
        prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        StartCoroutine(SpawnMarbles(initialMarbles));
    }

    public IEnumerator SpawnMarbles(int num)
    {
        for (int i = 0; i < num; i++)
        {
            yield return new WaitForSeconds(0.5f);

            GameObject marble = Instantiate(prefab, spawnPosition, Quaternion.identity);
            marble.transform.SetParent(transform, true);
            marble.transform.GetComponent<MarbleRespawn>().spawnPosition = spawnPosition;
            ExistingMarbles++;

            InitiliazeMarbleSpeed(marble);
        }
    }

    public void InitiliazeMarbleSpeed(GameObject marble)
    {
        float randomAngle = Random.Range(-180f, 0f);
        Vector2 forceDirection = new Vector2(
            Mathf.Cos(randomAngle * Mathf.Deg2Rad),
            Mathf.Sin(randomAngle * Mathf.Deg2Rad)
        ).normalized;

        marble.GetComponent<Rigidbody2D>().velocity = forceDirection * spawnSpeed;
    }
}
