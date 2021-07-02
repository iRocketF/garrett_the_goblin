using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{
    public float delay = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
