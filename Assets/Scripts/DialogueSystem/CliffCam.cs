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
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Trigger")
        {
        
        followCam.Priority = 8;
        cliffCam.Priority = 15;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Trigger")
        {
           
            cliffCam.Priority = 8;
            followCam.Priority = 15;
        }
            
    }
}
