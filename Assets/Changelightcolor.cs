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
    }

    Color l_red = new Color(1, 0.1361415f, 0, 1);
    Color l_yellow = new Color(0.8867924f, 0.853542f, 0.6734603f, 1);
    Color l_blue = new Color(0.1878337f, 0.2938787f, 0.5943396f, 1);
    public double l_frames = 0;
    Color currentColor;
    float fraction = 0;

    // m_Color

    // Update is called once per frame
    void Update()
    {
        l_frames = (Time.time % 13.33) * 60;
        if (l_frames >= 0 && l_frames <= 200) {
            fraction = (float)(l_frames / 200);
            currentColor = Color.Lerp(l_red, l_yellow, fraction);

        } else if (l_frames > 200 && l_frames <= 400) {
            fraction = (float)((l_frames - 200) / 200);
            currentColor = Color.Lerp(l_yellow, l_blue, fraction);

        } else if (l_frames > 400 && l_frames <= 600) {
            fraction = (float)((l_frames - 400) / 200);
            currentColor = Color.Lerp(l_blue, l_yellow, fraction);

        } else {
            fraction = (float)((l_frames - 600) / 200);
            currentColor = Color.Lerp(l_yellow, l_red, fraction);
        }

        dir_light.color = currentColor;
        // m_Color = Color.blue;
    }
}
