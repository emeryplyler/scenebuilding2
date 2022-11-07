using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Changelight : MonoBehaviour
{
    // public List<int> Lightstates; // TODO: may need to change from int
    private VisualElement frame;
    private Button button;
    
    void OnEnable()
    {
        var uiDocument = GetComponent<UIDocument>();
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("LightsFrame");
        button = frame.Q<Button>("Lights");
        button.RegisterCallback<ClickEvent>(ev => ChangeLight());
    }

    private int click = 0;
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
    }
    /*
    Suppose that you are executing script A, and you want to disable script B. Both of them are attached to the same object. That's an easy task:

        GetComponent(B).enabled = false;

    However, if A and B are attached to different objects, you have to do this:

        GameObject.Find("other_object_name").GetComponent(B).enabled = false;

    */
}
