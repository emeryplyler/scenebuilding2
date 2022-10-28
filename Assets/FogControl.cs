using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public float fogDensitySpeed = 0;
    public float currentTime = 0;

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;
        RenderSettings.fogDensity += fogDensitySpeed;

        if ((Time.time % 13.33 >= 5) && (Time.time % 13.33 < 6.67)) {
            fogDensitySpeed = 0.0001f; // begin increasing density
        } 
        else if ((Time.time % 13.33 >= 6.67) && (Time.time % 13.33 < 8.34)) {
            fogDensitySpeed = -0.0001f; // begin decreasing density
        } else {
            fogDensitySpeed = 0;
            RenderSettings.fogDensity = 0;
        }
    }
}
