using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    
    private Transform target;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        agent.SetDestination(target.position);
    }

    public void Desutroy()
    {
        Instantiate(this.gameObject, new Vector3(-13.37f, 0, 0), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
