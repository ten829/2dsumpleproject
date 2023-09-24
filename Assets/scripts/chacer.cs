using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chacer : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        if(TryGetComponent(out agent))
        {
            agent.updateUpAxis = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }
        if(agent == null)
        {
            return;
        }
        agent.SetDestination(target.transform.position);
        agent.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
