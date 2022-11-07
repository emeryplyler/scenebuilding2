using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class movepan : MonoBehaviour
{
    public CinemachineVirtualCamera currentCamera;
    public CinemachineTrackedDolly dolly;
    // Start is called before the first frame update
    void Start()
    {
        // Camera camera = GetComponent<Camera>();
        dolly = currentCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    public float obj_speed = 0.002f;
    // public double m_PathPosition = 0;  

    // Update is called once per frame
    void Update()
    {
        dolly.m_PathPosition += obj_speed;
        if (dolly.m_PathPosition >= 1) {
            obj_speed *= -1;
        } else if (dolly.m_PathPosition <= 0) {
            obj_speed *= -1;
        }
    }
}
