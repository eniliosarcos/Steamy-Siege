using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject coin;
    public ParticleSystem _ps;
    public int health;
    Transform tower;
    NavMeshAgent _agent;
    // Start is called before the first frame update
    void Start()
    {
        tower = GameObject.FindGameObjectWithTag("Tower").transform;
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(tower.position);
    }

    private void Update() {
        if(health<=0)
        {
            Instantiate(coin,transform.position,Quaternion.identity);
            Destroy(transform.parent.gameObject);
        }

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
