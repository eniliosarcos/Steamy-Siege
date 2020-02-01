using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class spawnEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    public int intervalTime;

    float _timerInterval;
    int _intervaTime;
    public Transform[] points;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        _intervaTime = intervalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerInterval() > _intervaTime)
        {
            _intervaTime += intervalTime;
            index = Random.Range(0,points.Length);
            GameObject go = Instantiate(enemies[0],points[index].position,Quaternion.identity);
            go.GetComponent<NavMeshAgent>().Warp(points[index].position);
        }
    }

    float TimerInterval()
    {
        return _timerInterval += Time.deltaTime;
    }
}
