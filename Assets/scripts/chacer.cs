using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chacer : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]
    private Transform target;
    private float starty;
    // Start is called before the first frame update
    void Start()
    {
        
        if(TryGetComponent(out agent))
        {
            starty = transform.position.y;
            agent.updateUpAxis = false;
            agent.updateRotation = false;
            agent.destination = transform.position;
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
        if(agent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            Vector3 nextPos = new(target.transform.position.x, starty, 0);
            agent.SetDestination(nextPos);

            nextPos = new(transform.position.x, starty, 0);
            transform.position = nextPos;
        }
        //agent.SetDestination(target.transform.position);
        //agent.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
