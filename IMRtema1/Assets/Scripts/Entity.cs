using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public abstract void Walk();
    public abstract void Attack();
    public abstract void StopAttack();
    public abstract void LookAtEntity(Entity entity);
    public abstract void Jump();
}
