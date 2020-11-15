using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Range : Attack
{
    public GameObject arrow;
    public float arrowspeed;

    public override void DoAttack(Animator animator, NavMeshAgent agent, GameObject target)
    {
        animator.SetTrigger("attack");

        Vector2 dir = target.transform.position - transform.position;

        GameObject shot = Instantiate(arrow, transform.position, Quaternion.identity);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        shot.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        shot.GetComponent<Rigidbody2D>().velocity = dir.normalized * arrowspeed * Time.deltaTime;
    }
}
