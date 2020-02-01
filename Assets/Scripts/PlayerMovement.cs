using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerStats playerStats;
    // Start is called before the first frame update
    Vector3 pos;
    bool complete;
    bool input;
    int counter;
    public int speed;
    bool max;
    Ray ray;
    public GameObject waveClearedUI;
    public GameObject prepareWaveUI;

    void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    void Start()
    {
    }
    // Update is called once per framel
    private void LateUpdate()
    {
        input = Input.GetButton("Fire1");
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    }
    void FixedUpdate()
    {

        float step = speed * Time.deltaTime;
        if (input)
        {

            complete = true;
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                pos = hit.point;
            }
        }

        if (complete)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(pos.x, 0, pos.z), step);
        }

        if (transform.position == pos && complete)
        {
            complete = false;
        }

    }

    //Colisiones del personaje.
    void OnCollisionEnter(Collision collisionInfo)
    {
        //Colision con engranajes.
        if (collisionInfo.collider.tag == "Enemy")
        {
            if (playerStats.gears < 3)
            {
                Debug.Log("We hit an enemy");
                Destroy(collisionInfo.gameObject);
                playerStats.gears = playerStats.gears + 1;
                Debug.Log(playerStats.gears);
                waveClearedUI.SetActive(true);
                prepareWaveUI.SetActive(true);
            }
       }

        //Colision con arma
        if (collisionInfo.collider.tag == "Weapon" && counter == 0)
        {
            Debug.Log("We repaired a weapon");
            collisionInfo.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            counter = 1;
            return;
        }

        if (collisionInfo.collider.tag == "Weapon" && counter == 1)
        {
            Debug.Log("Weapon upgraded");
            counter = 2;
            collisionInfo.gameObject.GetComponent<Renderer>().material.color = Color.green;
            return;
        }

        if (collisionInfo.collider.tag == "Weapon" && counter == 2 && !max)
        {
            Debug.Log("Weapon upgraded to level 2");
            collisionInfo.gameObject.GetComponent<Renderer>().material.color = Color.red;
            max = true;
        }

    }
}
