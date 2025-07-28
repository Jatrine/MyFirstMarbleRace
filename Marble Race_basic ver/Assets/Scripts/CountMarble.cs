using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountMarble : MonoBehaviour
{
    private int marbleCount;
    public TMP_Text num;

    void Start()
    {
        marbleCount = transform.parent.GetComponent<SpawnBlockController>().ExistingMarbles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
