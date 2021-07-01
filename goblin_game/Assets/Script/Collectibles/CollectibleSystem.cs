using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSystem : MonoBehaviour
{
    private int totalCollectiblesAmount;
    private int collectedTreasures;

    void Start()
    {
        Collectible[] collectibles = FindObjectsOfType<Collectible>();
        totalCollectiblesAmount = collectibles.Length;
    }

    void Update()
    {
        if (collectedTreasures == totalCollectiblesAmount)
        {
            GameManager.Instance.OpenTheExit();
        }
    }

    public void IncreaseTreasureAmount()
    {
        collectedTreasures++;
    }
}
