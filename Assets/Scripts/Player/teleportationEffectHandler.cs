using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class teleportationEffectHandler : MonoBehaviour
{
    public Animator animator;
    public CinemachineVirtualCamera teleCam;
    public GameObject asset;
   
    void Start()
    {
        asset.gameObject.SetActive(false);
        StartCoroutine("teleEffect");
    }

    IEnumerator teleEffect()
    {
       
        yield return new WaitForSeconds(1);
        asset.gameObject.SetActive(true);
        animator.SetBool("Teleportation", true);
        yield return new WaitForSeconds(1);
        teleCam.Priority = 9;
        animator.SetBool("Teleportation", false);

    }
}
