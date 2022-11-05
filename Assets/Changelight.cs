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
    
    // Start is called before the first frame update
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
        ChangeTime(click);
        click = (click + 1) % 3;
    }
    private void ChangeTime(int n) {
        // move to different point in cycle corresponding to index n
        
    }

}
