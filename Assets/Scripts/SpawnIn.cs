using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnIn : MonoBehaviour
{
    public AudioClip star_appears;
    public AudioClip star_collected;
    public AudioSource star;
    private bool sceneA = false;
    private bool first_try = true;
    private double acceleration = -9.8f;
    private float initial_speed = 9.8f;
    private float speed;
    public Rigidbody rb;
    private float time = 0;

    void Start()
    {
        star = GetComponent<AudioSource>();
        gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        //Logic for the initial spawning sequence
        if (sceneA == true && first_try == false)
        {
            time = time + Time.fixedDeltaTime;
            if (time >= 2.27f)
            {
                rb.velocity = new Vector3(0, 0, 0);
                transform.Rotate(new Vector3(0, 200, 0) * Time.fixedDeltaTime);
            }
            else
            {
                speed = (float) (initial_speed + acceleration * time);
                rb.velocity = new Vector3(0, speed, 0);
                transform.Rotate(new Vector3(0, 400, 0) * Time.fixedDeltaTime);
            }
            
            
            if (star.isPlaying != true)
            {
                sceneA = false;
                rb.isKinematic = true;
                star.clip = star_collected;
            }
        }
        else
        {
            transform.Rotate(new Vector3(0, 100, 0) * Time.fixedDeltaTime);

        }
    }

    void OnEnable()
    {
        star.clip = star_appears;
        star.Play();
        sceneA = true;
        rb.isKinematic = false;
        StartCoroutine(Timer());
    }
    
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(0.2f);
        first_try = false;
    }


}
