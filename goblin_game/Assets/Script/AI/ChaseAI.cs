using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAI : MonoBehaviour
{
    public float speed;
    private float ogSpeed;
    public float chaseRange;

    public bool isBlocked;

    private string currentState;
    private Transform target;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currentState = "IdleState";
        ogSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        switch (currentState)
        {
            case "IdleState":

                animator.SetBool("isWalking", false);

                if (distance < chaseRange)
                    currentState = "ChaseState";
                break;

            case "ChaseState":
                if (target.position.x > transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(0, 90, 0);

                    CheckForBlock();

                    animator.SetBool("isWalking", true);
                    transform.Translate(-transform.right * speed * Time.deltaTime);
                    

                    if (distance > chaseRange)
                        currentState = "IdleState";
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, -90, 0);

                    CheckForBlock();

                    animator.SetBool("isWalking", true);
                    transform.Translate(transform.right * speed * Time.deltaTime);

                    if (distance > chaseRange)
                        currentState = "IdleState";
                } 
                break;

            case "AttackState":
                break;
        }
    }

    void CheckForBlock()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
        {
            isBlocked = true;
            speed = 0f;
        }
        else
        {
            isBlocked = false;
            speed = ogSpeed;
        }

    }
}
