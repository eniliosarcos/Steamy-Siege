using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLifetine : MonoBehaviour
{
    // Start is called before the first frame update

    public float lifetime = 4.0f;
    void Start()
    {
        //  Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Awake()
    {
        
    }
}
