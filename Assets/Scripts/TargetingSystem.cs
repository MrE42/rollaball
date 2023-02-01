using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetingSystem : MonoBehaviour
{

    public int initialized = 0;
    private Vector3 p_position;
    private Vector3 bit_position;
    private float speed = (float) 0.2;



    // Start is called before the first frame update
    void Start()
    {
        initialized = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (initialized == 1)
        {
            p_position = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
            transform.position = Vector3.MoveTowards(transform.position, p_position, speed);

        }

    }
}
