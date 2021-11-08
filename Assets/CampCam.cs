using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CampCam : MonoBehaviour
{
    public CinemachineVirtualCamera followCam;
    public CinemachineVirtualCamera campCam;

    private void Start()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trigger")
        {

            followCam.Priority = 9;
            campCam.Priority = 15;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Trigger")
        {

            campCam.Priority = 9;
            followCam.Priority = 15;
        }

    }
}
