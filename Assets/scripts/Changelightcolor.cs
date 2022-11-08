using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changelightcolor : MonoBehaviour
{
    Light dir_light;
    // Start is called before the first frame update
    void Start()
    {
        dir_light = GetComponent<Light>();
        dir_light.intensity = 1;
        dir_light.color = l_red;
    }

    Color l_red = new Color(1, 0.1361415f, 0, 1);
    Color l_yellow = new Color(0.8867924f, 0.853542f, 0.6734603f, 1);
    Color l_blue = new Color(0.1878337f, 0.2938787f, 0.5943396f, 1);
    public double l_frames = 0;
    Color currentColor;
    float fraction = 0;
    float currentIntn = 0;
    bool isFirstHalf;

    // Update is called once per frame
    void Update()
    {
        l_frames = (Time.time % 13.33) * 60;
        
        if (l_frames >= 0 && l_frames <= 200) {
            fraction = (float)(l_frames / 200);
            currentColor = Color.Lerp(l_red, l_yellow, fraction);
            // intens_speed = intens_dec;
            isFirstHalf = true;

        } else if (l_frames > 200 && l_frames <= 400) {
            fraction = (float)((l_frames - 200) / 200);
            currentColor = Color.Lerp(l_yellow, l_blue, fraction);
            isFirstHalf = true;

        } else if (l_frames > 400 && l_frames <= 600) {
            fraction = (float)((l_frames - 400) / 200);
            currentColor = Color.Lerp(l_blue, l_yellow, fraction);
            // intens_speed = intens_inc;
            isFirstHalf = false;

        } else {
            fraction = (float)((l_frames - 600) / 200);
            currentColor = Color.Lerp(l_yellow, l_red, fraction);
            isFirstHalf = false;

        }

        // if (dir_light.intensity >= 1)
        // {
        //     intens_speed = intens_dec;
        // }
        // else if (dir_light.intensity <= 0)
        dir_light.color = currentColor;
        currentIntn = intens_fraction_calculate(isFirstHalf);
        dir_light.intensity = currentIntn;
    }

    float intens_fraction_calculate(bool firstHalf)
    {
        float currentIntn;
        if (firstHalf) 
        {
            currentIntn = (float)((l_frames * -0.0025) + 1);
        }
        else
        {
            currentIntn = (float)((l_frames - 400) * 0.0025);
        }
        return currentIntn;
    }
}
