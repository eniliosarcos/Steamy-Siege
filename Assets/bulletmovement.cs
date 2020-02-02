using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletmovement : MonoBehaviour
{
    public int damage;
    public Transform target;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target!=null)    
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        else
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyMovement>().health -= damage;
            Destroy(gameObject);
        }
    }
}
