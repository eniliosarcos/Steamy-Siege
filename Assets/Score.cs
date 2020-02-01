using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public PlayerStats player;
    public GameObject playerGameobject;
    public Text text;
    private PlayerStats playerStats;

 void Awake()
    {
        
        // playerStats = GetComponent<PlayerStats>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = playerGameobject.GetComponent<PlayerStats>().gears.ToString();
        // Debug.Log(playerStats.gears);
    }
}
