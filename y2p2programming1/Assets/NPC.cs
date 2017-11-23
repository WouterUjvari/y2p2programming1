using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour {

    public Transform target;
    public Transform item;
    public float timer;

    public enum Task { Roam, Collect, Dance, Idle };
    public Task myTask;
    public List<GameObject> objectives = new List<GameObject>();
    
    public NavMeshAgent agent;

    void Start()
    {
        target = objectives[Random.Range(0, objectives.Count)].transform;
        agent.SetDestination(target.transform.position);
    }

    void Update()
    {
        if (myTask == Task.Roam)
        {
            if (timer >= 2.5f)
            {
                timer = 0;
                target = objectives[Random.Range(0, objectives.Count)].transform;
                agent.SetDestination(target.transform.position);
            }
            else
            {
                timer = timer + Time.deltaTime;
            }
        }

        if (myTask == Task.Collect)
        {
            if(item == null)
            {
                //FindCollectable();
            }


        }
    }
    void OnCollisionStay(Collision other)
    {
        if (myTask == Task.Collect)
        {
            if (other.gameObject.tag == "Collectable")
            {
                print("Collected");
                Destroy(other.gameObject);
                item = null;
            }
        }
    }
}
