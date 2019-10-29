using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{

    [SerializeField] Transform target;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] LineRenderer line;

    void Start()
    {
        agent.SetDestination(target.position);
        StartCoroutine(RecalculatePathRotine());
    }

    /// <summary>
    /// Periodacally recalculate the destination to the target
    /// </summary>
    IEnumerator RecalculatePathRotine()
    {
        WaitForSeconds delay = new WaitForSeconds(0.1f);
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            agent.SetDestination(target.position);
        }
    }

   
}
