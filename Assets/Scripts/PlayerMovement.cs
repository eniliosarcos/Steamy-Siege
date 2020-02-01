using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 pos;
    bool complete;
    bool input;

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
}
