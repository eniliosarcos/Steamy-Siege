using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    public GameObject[] enemies;
    public int intervalTime;

    float _timerInterval;
    int _intervaTime;
    Transform[] points;
    int index;
    // Start is called before the first frame update
    void Start()
    {
        points = GetComponentsInChildren<Transform>();
        _intervaTime = intervalTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(TimerInterval() > _intervaTime)
        {
            _intervaTime += intervalTime;
            index = Random.Range(0,points.Length);
            GameObject go = Instantiate(enemies[0],new Vector3(points[index].position.x,points[index].position.y,points[index].position.z),Quaternion.identity);
        }
    }

    float TimerInterval()
    {
        return _timerInterval += Time.deltaTime;
    }
}
