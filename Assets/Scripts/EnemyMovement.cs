using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public ParticleSystem _ps;
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
            ParticleSystem ps1 = Instantiate(_ps,transform.position,Quaternion.identity);
            Destroy(transform.parent.gameObject);
            Destroy(ps1.gameObject,2.0f);
        }
    }
}
