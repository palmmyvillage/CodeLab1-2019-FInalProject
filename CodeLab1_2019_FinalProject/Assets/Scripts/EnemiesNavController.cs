using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesNavController : MonoBehaviour
{
    private GameObject target;
    private Vector3 destination;
    private Vector3 oldDest;
    
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();

        destination = target.transform.position;
        agent.SetDestination(destination);

        oldDest = destination;
    }

    // Update is called once per frame
    void Update()
    {   
        if (oldDest != destination)
        {
            agent.SetDestination(destination);
            oldDest = destination;
        }

        destination = target.transform.position;
    }
}
