using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private CollectibleSystem cSystem;

    void Start()
    {
        cSystem = FindObjectOfType<CollectibleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            cSystem.IncreaseTreasureAmount();
            Destroy(gameObject);
        }
    }
}
