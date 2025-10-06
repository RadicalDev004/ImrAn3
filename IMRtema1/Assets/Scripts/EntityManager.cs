using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public float attackDistance = 1;
    public List<Entity> entities;
    public Dictionary<(Entity, Entity), EntityState> PairStates = new();

    public enum EntityState
    {
        idle,
        attacking
    }

    void Start()
    {
        entities = FindObjectsOfType<Entity>().ToList();
    }

    void Update()
    {
        for (int i = 0; i < entities.Count - 1; i++)
        {
            var e1 = entities[i];
            for (int j = i + 1; j < entities.Count; j++)
            {
                var e2 = entities[j];

                if (e1 == e2) continue;

                if (!PairStates.ContainsKey((e1, e2)))
                    PairStates.Add((e1, e2), EntityState.idle);
                //print(Vector3.Distance(e1.transform.position, e2.transform.position));
                if(Vector3.Distance(e1.transform.position, e2.transform.position) <= attackDistance && PairStates[(e1, e2)] != EntityState.attacking)
                {
                    e1.transform.LookAt(e2.transform);
                    e2.transform.LookAt(e1.transform);
                    PairStates[(e1, e2)] = EntityState.attacking;
                    e1.Attack();
                    e2.Attack();
                }
                else if (Vector3.Distance(e1.transform.position, e2.transform.position) > attackDistance && PairStates[(e1, e2)] == EntityState.attacking)
                {
                    e1.StopAttack();
                    e2.StopAttack();
                    PairStates[(e1, e2)] = EntityState.idle;
                }
            }
        }
    }
}
