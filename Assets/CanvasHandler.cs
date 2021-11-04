using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasHandler : MonoBehaviour
{

    public Vector3 pos;

    public GameObject robot;
    public Camera cam;
    private Vector3 roboPos;
    public RectTransform rt;
    private RectTransform canvasRT;
    private Vector3 roboScreenPos;

    // Use this for initialization
    void Start()
    {
        roboPos = robot.transform.position;

        canvasRT = GetComponent<RectTransform>();
        roboScreenPos = cam.WorldToViewportPoint(robot.transform.TransformPoint(roboPos));
        rt.anchorMax = roboScreenPos;
        rt.anchorMin = roboScreenPos;
    }

    // Update is called once per frame
    void Update()
    {
        roboScreenPos = cam.WorldToViewportPoint(robot.transform.TransformPoint(roboPos));
        rt.anchorMax = roboScreenPos;
        rt.anchorMin = roboScreenPos;
    }
}
