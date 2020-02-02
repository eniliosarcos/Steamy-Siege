using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    public int TimeWaitWave = 3;
    public bool startSpamEnemies;
    float _timer = 0;
    bool stop;
    public Text timeUI;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(stopwatch());
        _timer = TimeWaitWave;
        timeUI.text = TimeWaitWave.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (stop)
        {
            _timer -= Time.deltaTime;

            if (_timer > 1)
            {
                timeUI.text = "" + (int)_timer;
            }
            else
            {
                StartCoroutine(startText());
                startSpamEnemies = true;
                StartCoroutine(turnOff());
            }
        }
    }

    IEnumerator stopwatch()
    {

        yield return new WaitForSeconds(2.0f);
        stop = true;

    }

    IEnumerator turnOff()
    {
        yield return new WaitForSeconds(3.0f);
        timeUI.gameObject.SetActive(false);
    }

    IEnumerator startText()
    {
        yield return new WaitForSeconds(.0f);
        timeUI.text = "Enemies Incoming";
    }

}
