using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{

    List<NavMeshAgent> agents;

    // Start is called before the first frame update
    void Start()
    {
        agents = new List<NavMeshAgent>();
        agents.Add(GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            agents.ForEach(agent => {
                agent.SetDestination(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            });
        }

        if (Input.GetMouseButtonDown(0))
        {
            agents.Clear();

            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D[] hit2D;

            hit2D = Physics2D.CircleCastAll(pos, 1.5f, Vector2.zero, 0f);

            for (int i = 0; i < hit2D.Length; i++) 
            {
                if (hit2D[i].transform.tag == "Player")
                {
                    agents.Add(hit2D[i].transform.GetComponent<NavMeshAgent>());
                }
            }
        }
    }
}
