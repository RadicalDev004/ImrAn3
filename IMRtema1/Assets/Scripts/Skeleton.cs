using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Entity
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
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
