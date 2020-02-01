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
    
    void Awake() {
    playerStats = GetComponent<PlayerStats>();
    }
    public int speed;

    Ray ray;
    void Start()
    {
    }
    // Update is called once per framel
    private void LateUpdate() {
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

        if (complete){
            transform.position = Vector3.MoveTowards(transform.position, pos, step);
        }

        if(transform.position == pos && complete){
            complete = false;
        }

    }
        void OnCollisionEnter(Collision collisionInfo) 
    {
       if (collisionInfo.collider.tag == "Enemy")
       {
           if (playerStats.gears<3)
           {
           Debug.Log("We hit an enemy");
           Destroy(collisionInfo.gameObject);
           playerStats.gears = playerStats.gears+1;
           Debug.Log(playerStats.gears);
            }
       }
    }
}
