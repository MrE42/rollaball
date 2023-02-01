using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;

public class PointerHandler : MonoBehaviour
{
    public StarLauncher s;
    public SteamVR_LaserPointer laserPointer;

    void Awake()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was clicked");
        } else if (e.target.name == "Button")
        {
            Debug.Log("Button was clicked");
        } else if (e.target.CompareTag("Launch") && !s.flying)
        {
            Debug.Log("Launch Star was clicked");
            s.initiate = true;
        }
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was entered");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was entered");
        } else if (e.target.CompareTag("Launch"))
        {
            Debug.Log("Launch Star was entered");
            s.launchObject = e.target;
            s.insideLaunchStar = true;
        } else if (e.target.CompareTag("StarBit"))
        {
            Debug.Log("StarBit was entered");
            TargetingSystem t = e.target.gameObject.GetComponent<TargetingSystem>();
            t.initialized = 1;
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.name == "Cube")
        {
            Debug.Log("Cube was exited");
        }
        else if (e.target.name == "Button")
        {
            Debug.Log("Button was exited");
        } else if (e.target.CompareTag("Launch"))
        {
            Debug.Log("Launch Star was exited");
            s.insideLaunchStar = false; 
        }
    }
}