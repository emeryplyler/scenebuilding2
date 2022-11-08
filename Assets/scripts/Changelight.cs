using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Changelight : MonoBehaviour
{
    public Light dir_light;
    void Start()
    {
        // Light dir_light = GameObject.Find("Directional Light (1)").GetComponent<Light>();
        half = Color.Lerp(pink, darkblue, 0.5f);
    }
    // public List<int> Lightstates; // TODO: may need to change from int
    private VisualElement frame;
    private Button button;
    // GameObject.Find("Directional Light (1)").GetComponent<Changelightcolor>
    
    enum lightlevel
    {
        dark=1,
        dim=2,
        bright=3
    }
    Color l_red = new Color(1, 0.1361415f, 0, 1);
    Color l_yellow = new Color(0.8867924f, 0.853542f, 0.6734603f, 1);
    Color l_blue = new Color(0.1878337f, 0.2938787f, 0.5943396f, 1);
    Vector3 l_vec1 = new Vector3(45, -90, 0);
    Vector3 l_vec2 = new Vector3(225, -90, 0);
    Vector3 l_vec3 = new Vector3(405, -90, 0);
    Color pink = new Color(0.8576048f, 0.7059897f, 0.8962264f, 1);
    Color darkblue = new Color(0.3059375f, 0.2501335f, 0.6886792f, 1);
    Color half = new Color(0, 0, 0, 1);
    
    void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("LightsFrame");
        button = frame.Q<Button>("Lights");
        button.RegisterCallback<ClickEvent>(ev => ChangeLight());
    }

    public int click = 0;
    private void ChangeLight() {
        // disable other scripts
        
        ChangeTime(click);
        click = (click + 1) % 4;
    }
    private void ChangeTime(int n) {
        // move to different point in cycle corresponding to index n
        // index 0: dark
        // index 1: dim
        // index 2: bright 
        // index 3: enable other scripts again
        switch (n)
        {
            case 0:
                setLights(lightlevel.dark);
                ToggleScripts(false);
                break;
            case 1:
                setLights(lightlevel.dim);
                ToggleScripts(false);
                break;
            case 2:
                setLights(lightlevel.bright);
                ToggleScripts(false);
                break;
            case 3:
                ToggleScripts(true);
                break;
        }
    }
    private void ToggleScripts(bool allowed)
    {
        GameObject.Find("Directional Light (1)").GetComponent<Changelightcolor>().enabled = allowed;
        GameObject.Find("Directional Light (1)").GetComponent<Changelightrotation>().enabled = allowed;
        GameObject.Find("Scripts").GetComponent<changeskycolor>().enabled = allowed;
        GameObject.Find("Scripts").GetComponent<FogControl>().enabled = allowed;
    }
    private void setLights(lightlevel setting)
    {
        switch (setting)
        {
            case lightlevel.dark:
                dir_light.color = l_blue;
                dir_light.intensity = 0.1f;
                GameObject.Find("Directional Light (1)").transform.eulerAngles = l_vec2;
                RenderSettings.skybox.SetColor("_Tint", darkblue);
                RenderSettings.fogDensity = 0.04f;
                break;
            case lightlevel.dim:
                dir_light.color = l_red;
                dir_light.intensity = 0.5f;
                GameObject.Find("Directional Light (1)").transform.eulerAngles = l_vec1;
                RenderSettings.skybox.SetColor("_Tint", pink);
                RenderSettings.fogDensity = 0;
                break;
            case lightlevel.bright:
                dir_light.color = l_yellow;
                dir_light.intensity = 1;
                GameObject.Find("Directional Light (1)").transform.eulerAngles = l_vec1;
                RenderSettings.skybox.SetColor("_Tint", pink);
                RenderSettings.fogDensity = 0;
                break;
        }
    }
    /*
    Suppose that you are executing script A, and you want to disable script B. Both of them are attached to the same object. That's an easy task:

        GetComponent(B).enabled = false;

    However, if A and B are attached to different objects, you have to do this:

        GameObject.Find("other_object_name").GetComponent(B).enabled = false;

    */
}
