using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class DownCam : MonoBehaviour
{
    public CinemachineVirtualCamera followCam;
    public CinemachineVirtualCamera downCam;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trigger")
        {

            followCam.Priority = 8;
            downCam.Priority = 15;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Trigger")
        {

            downCam.Priority = 8;
            followCam.Priority = 15;
        }
    }
}
