using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeskycolor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float fraction = 0;
    Color pink = new Color(0.8576048f, 0.7059897f, 0.8962264f, 1);
    Color darkblue = new Color(0.3059375f, 0.2501335f, 0.6886792f, 1);
    public Color currentColor;
    // Skybox skybox = gameObject.GetComponent<Skybox>();

    // Update is called once per frame
    void Update()
    {
        // how far change is on a scale of 0 to 1
        // time.time is seconds, 60fps
        // animation starts at 200 frames
        fraction = (float)((((Time.time % 13.33) * 60) - 200) / 400); 
        
        if (fraction > 0 && fraction <= 0.5) {
            // move color towards dark blue
            currentColor = Color.Lerp(pink, darkblue, fraction);
            RenderSettings.skybox.color = currentColor;
            // RenderSettings.skybox.SetColor 
        } else if (fraction > 0.5 && fraction <= 1) {
            // move color back towards pink
            currentColor = Color.Lerp(pink, darkblue, fraction);
            RenderSettings.skybox.color = currentColor;
        }
    } // TO DO: i forgot to make it turn back to pink instead of just go from pink to blue
}
