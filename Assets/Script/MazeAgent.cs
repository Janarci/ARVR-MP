using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MazeAgent : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isRunning", agent.velocity.sqrMagnitude != 0);
    }

    public void MoveToDestination(Vector3 position)
    {
        agent.SetDestination(position);
    }

    public void StopAgent(bool isStopped)
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
        }
        agent.isStopped = isStopped;
    }
}
