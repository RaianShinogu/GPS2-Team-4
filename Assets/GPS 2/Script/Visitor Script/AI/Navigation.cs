using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigation : MonoBehaviour
{

     GameObject targetEnd;
    [SerializeField] NavMeshAgent agent;


    void Awake()
    {
        targetEnd = GameObject.Find("End");
    }
    void Start()
    {
        agent.SetDestination(targetEnd.transform.position);
        StartCoroutine(RecalculatePathRotine());
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Finish"))
        {         
            Destroy(gameObject);
        }
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
            agent.SetDestination(targetEnd.transform.position);
        }
    }

    
   
}
