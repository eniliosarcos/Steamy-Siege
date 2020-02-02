using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spawnEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    public bool spawnBoss;
    public int intervalTime;

    float _timerInterval;
    int _intervaTime;
    public Transform[] points;
    int index;
    public int timeSpamBoss;
    public int timeincreaseHealth;
    public WaveManager waveManager;
    // Start is called before the first frame update
    void Start()
    {
        _intervaTime = intervalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(waveManager.startSpamEnemies)
        {
            if(TimerInterval() > _intervaTime && !spawnBoss)
            {
                if(TimerInterval()>timeSpamBoss)
                {
                    spawnBoss = true;
                }

                _intervaTime += intervalTime;
                index = Random.Range(0,points.Length);
                GameObject go = Instantiate(enemies[Random.Range(0,enemies.Length-1)],points[index].position,Quaternion.identity);
                //go.transform.Rotate (90f, 0f, 0f);
                go.GetComponentInChildren<NavMeshAgent>().Warp(points[index].position);
            }

            if(spawnBoss)
            {
                if(TimerInterval() > (_intervaTime-2))
                {
                _intervaTime += intervalTime;
                index = Random.Range(0,points.Length);
                if(TimerInterval() > timeincreaseHealth)
                {
                                    GameObject go = Instantiate(enemies[Random.Range(0,enemies.Length)],points[index].position,Quaternion.identity);
                                go.GetComponentInChildren<NavMeshAgent>().Warp(points[index].position);
                                go.GetComponentInChildren<EnemyMovement>().health += 50;
                }
                else
                {
                GameObject go = Instantiate(enemies[Random.Range(0,enemies.Length)],points[index].position,Quaternion.identity);
                                go.GetComponentInChildren<NavMeshAgent>().Warp(points[index].position);
                }
                
                //go.transform.Rotate (90f, 0f, 0f);

                }

            }
        }

    }

    float TimerInterval()
    {
        return _timerInterval += Time.deltaTime;
    }
}
