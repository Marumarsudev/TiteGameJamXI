using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hole : MonoBehaviour
{

    public bool isDug;
    private bool isTriggered;

    private SpriteRenderer sprite;

    private Animator animator;

    public Sprite notDug;
    public Sprite dug;

    private int trapType;

    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        isDug = false;
        isTriggered = false;
        sprite.sprite = notDug;
    }

    public void reset()
    {
        isDug = false;
        animator.SetTrigger("remove");
    }

    public void dig(int trap)
    {
        if (!isDug)
        {
            isDug = true;
            isTriggered = false;
            switch(trap)
            {
                case 0:
                    trapType = 0;
                    animator.SetTrigger("spike");
                break;

                case 1:
                    trapType = 1;
                    animator.SetTrigger("beartrap");
                break;

                case 2:
                    trapType = 2;
                    animator.SetTrigger("rune");
                break;
            }
        }
        else if (isTriggered)
        {
            isDug = true;
            isTriggered = false;
            animator.SetTrigger("reset");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Knight" && trapType != 0)
        {
            return;
        }
        else if (other.tag == "Ranger" && trapType != 1)
        {
            return;
        }
        else if (other.tag == "Mage" && trapType != 2)
        {
            return;
        }

        if (isDug && !isTriggered)
        {
            NavMeshAgent agent = other.GetComponent<NavMeshAgent>();

            if (agent != null && !agent.GetComponent<Enemy>().isHit)
            {
                isTriggered = true;
                animator.SetTrigger("trigger");
                agent.GetComponent<Enemy>().Damaged();
            }
        }
    }
}
