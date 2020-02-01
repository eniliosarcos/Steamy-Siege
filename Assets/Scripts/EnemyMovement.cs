using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    Transform tower;
    NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.FindGameObjectWithTag("Tower").transform;
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(tower.position);
    }
    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Tower")
        {
            Destroy(gameObject);
        }
    }
}
