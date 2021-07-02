using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAI : MonoBehaviour
{
    public GameObject weapon;
    public GameObject projectile;
    public Transform projectileSpawn;

    public float attackRange;
    public float attackCoolDown;
    public float attackTimer;
    public float force;

    private Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        weapon.transform.LookAt(target);

        float distance = Vector3.Distance(transform.position, target.position);

        if(distance < attackRange)
        {
            attackTimer += Time.deltaTime;

            if (attackTimer >= attackCoolDown)
            {
                Shoot();
                attackTimer = 0f;
            }
        }
    }

    void Shoot()
    {
        GameObject projectileClone = Instantiate(projectile, projectileSpawn.position, Quaternion.identity);

        Rigidbody projRigidBody = projectileClone.GetComponent<Rigidbody>();

        projRigidBody.AddForce(transform.forward * force);
    }
}
