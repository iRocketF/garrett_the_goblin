using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAI : MonoBehaviour
{
    public GameObject weapon;
    public GameObject projectile;
    public Transform projectileSpawn;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        weapon.transform.LookAt(target);
    }
}
