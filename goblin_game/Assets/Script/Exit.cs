using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.isExitOpen = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.isExitOpen)
            {
                GameManager.Instance.FoundTheExit();
            }
        }
    }

    private void Update()
    {
        Debug.Log(GameManager.Instance.isExitOpen);
    }
}
