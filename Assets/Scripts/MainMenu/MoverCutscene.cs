using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCutscene : MonoBehaviour
{
    public GameObject paraAsset;
    private Rigidbody2D rbParaAsset;
    private Vector2 paraSpeed;
    public GameObject button;
    
    void Start()
    {
        paraSpeed = new Vector2(-1f, 0);
        rbParaAsset = paraAsset.GetComponent<Rigidbody2D>();
        rbParaAsset.gravityScale = 0;
        button.SetActive(true);
    }

    
    void Update()
    {
        
    }

    public void JustOneButtonToBecomeAnAsset()
    {
        rbParaAsset.gravityScale = 0.02f;
        rbParaAsset.velocity = paraSpeed;
        button.SetActive(false);
    }
}
