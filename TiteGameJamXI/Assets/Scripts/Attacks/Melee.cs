using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Melee : Attack
{
    public override void DoAttack(Animator animator, NavMeshAgent agent, GameObject target)
    {
        Vector2 direction = agent.velocity.normalized;

        RaycastHit2D[] hits = Physics2D.CircleCastAll(this.transform.position, 3f, Vector2.zero, 0f);

        Player player = null;

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.GetComponent<Player>() != null)
            {
                player = hits[i].collider.GetComponent<Player>();
            }
        }

        if (player != null)
        {
            Vector2 playerdir =  player.transform.position - transform.position;

            Debug.Log(Vector2.Angle(direction, playerdir));

            if (Vector2.Angle(direction, playerdir) < 90)
            {
                animator.SetTrigger("attack");
                Debug.Log("HIT HIT HIT!!!!");
            }
        }
    }
}
