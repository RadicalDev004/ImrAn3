using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Entity
{
    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        lastPos = transform.position;
    }

    private void Update()
    {
        var currentPos = transform.position;
        var deltaPos = currentPos - lastPos;
        if (deltaPos.sqrMagnitude * 10000000 > 1f && !isWalking)
        {
            isWalking = true;
            animator.SetBool("walk", true);
        }
        if (deltaPos.sqrMagnitude * 10000000 <= 1f && isWalking)
        {
            isWalking = false;
            animator.SetBool("walk", false);
        }
        lastPos = currentPos;
    }

    public override void Attack()
    {
        animator.SetBool("bareAttack", true);
    }

    public override void Jump()
    {
        throw new System.NotImplementedException();
    }

    public override void LookAtEntity(Entity entity)
    {
        throw new System.NotImplementedException();
    }

    public override void Walk()
    {
        throw new System.NotImplementedException();
    }

    public override void StopAttack()
    {
        animator.SetBool("bareAttack", false);
    }
}
