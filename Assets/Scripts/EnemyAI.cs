using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    [SerializeField] float detectionRadius = 12f;
    private float distanceToTarget = Mathf.Infinity;
    private float rotationSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.position);
        if (distanceToTarget < detectionRadius)
        {
            GetsProvoked();
        }
        else
        {
            EnterIdleAnimation();
        }
    }

    private void OnDrawGizmos()
    {
        // Display the detection radius when selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    private void GetsProvoked() // string reference
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            navMeshAgent.SetDestination(target.position);
            EnterChaseAnimation();
        }
        else
        {
            RotateTowards(target);
            EnterAttackAnimation();
        }
    }

    private void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    /* ANIMATION STATES */
    private void EnterIdleAnimation()
    {
        animator.SetTrigger("idle");
    }
    private void EnterChaseAnimation()
    {
        animator.SetTrigger("chase");
        animator.SetBool("attack", false);
    }

    private void EnterAttackAnimation()
    {
        animator.SetBool("attack", true);
        // TODO: add event - enemy hits player
    }
}
