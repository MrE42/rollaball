using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Revolve : MonoBehaviour
{
    public float revSpeed = 7.5f;
    private float radius;
    private float angle;

    private void Start()
    {
        radius = transform.position.x;
    }
    // Update is called once per frame
    void Update()
    {
        angle += revSpeed * Time.deltaTime;

        float xNew = Mathf.Sin(angle) * radius;
        float zNew = Mathf.Cos(angle) * radius;

        transform.position = new Vector3(xNew, 0.5f, zNew);
    }
}
