using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int TimeWaitWave;
    public bool startSpamEnemies;
    float _timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waveTimer() > TimeWaitWave && !startSpamEnemies)
        {
            startSpamEnemies = true;
        }
    }

    float waveTimer()
    {
        return _timer += Time.deltaTime;
    }
}
