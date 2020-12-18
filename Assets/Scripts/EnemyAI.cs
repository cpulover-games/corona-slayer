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
        if (distanceToTarget < detectionRadius){
            GetsProvoked();
        } else {
            animator.SetTrigger("idle");
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
            animator.SetTrigger("chase");
            animator.SetBool("attack", false);
        }
        else
        {
            RotateTowards(target);
            AttackTarget();
        }
    }

   private void RotateTowards (Transform target) {
            Vector3 direction = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
   }
    private void AttackTarget(){
        animator.SetBool("attack", true);
    }
}
