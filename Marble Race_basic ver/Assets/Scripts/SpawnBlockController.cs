using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpawnBlockController : MonoBehaviour
{
    [SerializeField]
    private int marbleNumber = 5;
    public Color MarbleColor;

    private string prefabPath = "Assets/Prefabs/Marble.prefab";
    private GameObject prefab;
    private Vector2 spawnPosition;
    private float spawnForce = 0.5f;

    private void Start()
    {
        spawnPosition = transform.Find("Spawn Point").position;
        prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        StartCoroutine(SpawnMarbles(marbleNumber));
    }

    public IEnumerator SpawnMarbles(int num)
    {
        for (int i = 0; i < num; i++)
        {
            yield return new WaitForSeconds(0.5f);

            GameObject marble = Instantiate(prefab, spawnPosition, Quaternion.identity);
            marble.transform.SetParent(transform, true);
            marble.transform.GetComponent<MarbleRespawn>().spawnPosition = spawnPosition;
            float randomAngle = Random.Range(-180f, 0f);
            Vector2 forceDirection = new Vector2(
                Mathf.Cos(randomAngle * Mathf.Deg2Rad),
                Mathf.Sin(randomAngle * Mathf.Deg2Rad)
            ).normalized;

            marble.GetComponent<Rigidbody2D>().AddForce(forceDirection * spawnForce, ForceMode2D.Impulse);
        }
    }
}
