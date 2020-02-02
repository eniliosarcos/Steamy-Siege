using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public int TimeWaitWave = 3;
    public bool startSpamEnemies;
    float _timer = 0;
    public Text timeUI;
    // Start is called before the first frame update
    void Start()
    {

        timeUI.text = TimeWaitWave.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer > TimeWaitWave && !startSpamEnemies)
        {
            timeUI.text = _timer.ToString();
            startSpamEnemies = true;
            _timer = _timer - TimeWaitWave;
            Time.timeScale = 1;
        }
    }

    // float waveTimer()
    // {
    //     return _timer -= Time.deltaTime;

    // }
}
