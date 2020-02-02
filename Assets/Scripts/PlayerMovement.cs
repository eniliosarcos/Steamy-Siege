using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private PlayerStats playerStats;
    // Start is called before the first frame update
    Vector3 pos;
    bool complete;
    bool input;
    Text text;
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
        
        //Colision con arma
        if (collisionInfo.collider.tag == "turret" && GetComponent<PlayerStats>().gears > 0)
        {
            print("asd");
            switch (collisionInfo.collider.GetComponent<raycast>().level)
            {
                case 0:
                    StartCoroutine(color(collisionInfo.collider.gameObject));
                    collisionInfo.collider.GetComponent<raycast>().shootTime -= 1;
                    collisionInfo.collider.GetComponent<raycast>().damage = 10;
                    collisionInfo.collider.GetComponent<raycast>().level = 1;
                    GetComponent<PlayerStats>().gears -= 1;
                break;
                case 1:
                    StartCoroutine(color(collisionInfo.collider.gameObject));
                    collisionInfo.collider.GetComponent<raycast>().shootTime -= 1;
                    collisionInfo.collider.GetComponent<raycast>().damage = 15;
                    collisionInfo.collider.GetComponent<raycast>().level = 2;
                    GetComponent<PlayerStats>().gears -= 2;
                break;
                case 2:
                    StartCoroutine(color(collisionInfo.collider.gameObject));
                    collisionInfo.collider.GetComponent<raycast>().shootTime -= 0.3f;
                    collisionInfo.collider.GetComponent<raycast>().damage = 25;
                    collisionInfo.collider.GetComponent<raycast>().level = 3;
                    GetComponent<PlayerStats>().gears -= 3;
                break;
            }
        }

    }

    IEnumerator color(GameObject ob)
    {
        Color color = ob.GetComponentInChildren<SpriteRenderer>().color;
        ob.GetComponentInChildren<SpriteRenderer>().color = Color.green;
        yield return new WaitForSeconds(1.0f);
        ob.GetComponentInChildren<SpriteRenderer>().color = color;
    }
}
