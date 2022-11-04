using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeskycolor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        currentColor = pink;
    }

    public float fraction = 0;
    Color pink = new Color(0.8576048f, 0.7059897f, 0.8962264f, 1);
    Color darkblue = new Color(0.3059375f, 0.2501335f, 0.6886792f, 1);
    public Color currentColor;
    public float colorframes = 0;
    // Skybox skybox = gameObject.GetComponent<Skybox>();
    public double skytime = 0;

    // Update is called once per frame
    void Update()
    {
        skytime = Time.time % 13.33;
        if (skytime > 3.33 && skytime <= 6.67) {
            // move color towards dark blue
            fraction = (float)(((skytime * 60) - 200) / 200);
            currentColor = Color.Lerp(pink, darkblue, fraction);
            // RenderSettings.skybox.color = currentColor;
            RenderSettings.skybox.SetColor("_Tint", currentColor);

        } else if (skytime > 6.67 && skytime <= 10) {
            // move color back towards pink
            fraction = (float)(((skytime * 60) - 400) / 200);
            currentColor = Color.Lerp(darkblue, pink, fraction);
            // RenderSettings.skybox.color = currentColor;
            RenderSettings.skybox.SetColor("_Tint", currentColor);
        }

        colorframes++; // increment frames count
        if (colorframes > 800) {
            colorframes = 0; // max of 800
        }
    }
}
