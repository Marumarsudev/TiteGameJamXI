using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{


    //Options
    public float stopDistance;
    public float playerDetectionDistance;
    public float playerLossDistance;

    public float attackRate = 1f;
    private float attackTime = 1f;

    private Animator animator;
    private SpriteRenderer sprite;
    public Attack attackScript;
    public WaveHandler daddy;
    public List<GameObject> followedPath;
    public Vector3 spawnPos;
    private NavMeshAgent agent;
    private Transform player;
    private int pathIndex;
    private bool followingPlayer;
    public bool isHit;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        pathIndex = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.stoppingDistance = 0;
        agent.SetDestination(followedPath[pathIndex].transform.position);
    }

    public void Attack()
    {
        attackScript.DoAttack(animator, agent, player.gameObject);
    }

    public void Damaged()
    {
        animator.SetBool("hit", true);
        isHit = true;
        agent.speed = 1.5f;
        agent.SetDestination(spawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.velocity.x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (!agent.pathPending && !followingPlayer)
        {
            if (agent.remainingDistance - 0.5f <= agent.stoppingDistance)
            {
                if (!isHit)
                {
                    pathIndex = pathIndex + 1 > followedPath.Count - 1 ? 0 : pathIndex + 1;
                    agent.SetDestination(followedPath[pathIndex].transform.position);
                }
                else
                {
                    daddy.EnemyBack();
                    Destroy(this.gameObject);
                }
            }
        }

        if (attackTime < attackRate) attackTime += Time.deltaTime;

        if (Vector2.Distance(transform.position, player.position) < playerDetectionDistance && attackTime >= attackRate && !isHit)
        {
            attackTime = 0f;
            Attack();
        }
    }
}
