using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CliffCam : MonoBehaviour
{
    public CinemachineVirtualCamera followCam;
    public CinemachineVirtualCamera cliffCam;

    private void Start()
    {
        // cliffCam.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trigger")
        {
            // cliffCam.enabled = true;
        followCam.Priority = 9;
        cliffCam.Priority = 10;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Trigger")
        {
           // cliffCam.enabled = false;
            cliffCam.Priority = 9;
            followCam.Priority = 10;
        }
            
    }
}
