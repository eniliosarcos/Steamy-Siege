using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int gears;
    public Text texto;

    // Start is called before the first frame update
    void Start()
    {
        texto.text = "Gears: "+ gears;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
        //Colision con engranajes.
        if (collisionInfo.collider.tag == "coin")
        {
            if (gears < 3)
            {
                Debug.Log("We hit a coin");
                Destroy(collisionInfo.transform.parent.gameObject);
                gears = gears + 1;
                Debug.Log(gears);
                texto.text = "Gears: "+ gears;
            }else{
                print("Already full");
            }
       }
    }
}
