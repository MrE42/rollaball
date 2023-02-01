using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI starText;
    public GameObject winTextObject;
    public GameObject star;

    public Rigidbody rb;
    private int count;
    private int bits;
    private float movementX;
    private float movementY;
    public bool input = true;

    public AudioSource source;
    public AudioClip oof;
    public AudioClip wow;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        count = 0;
        bits = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        if (input)
        {
            Vector2 movementVector = movementValue.Get<Vector2>();

            movementX = movementVector.x;
            movementY = movementVector.y;
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    void SetStarText()
    {
        starText.text = "Star Bits X " + bits.ToString();
        if (bits >= 16 && star != null)
        {
            star.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (input)
        {
            Vector3 movement = new Vector3(movementX, 0.0f, movementY);

            rb.AddForce(movement * speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
        else if (other.gameObject.CompareTag("StarBit"))
        {
            other.gameObject.SetActive(false);
            bits = bits + 1;

            SetStarText();
        }
        else if (other.gameObject.CompareTag("Star"))
        {
            gameObject.GetComponent<AudioSource>().clip = star.GetComponent<AudioSource>().clip;
            gameObject.GetComponent<AudioSource>().Play();
            star.SetActive(false);
        }
        else if (other.gameObject.CompareTag("GoSlow"))
        {
            speed *= 0.75f;
            source.volume = 0.5f;
            source.PlayOneShot(oof);

            if (speed <= 3.0f)
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}            
