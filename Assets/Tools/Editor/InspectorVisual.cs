using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ButtonText))]
public class InspectorVisual : Editor
{
    public override void OnInspectorGUI()
    {
        ButtonText buttonText = (ButtonText) target;

        DrawDefaultInspector();

        if (GUILayout.Button("Get Data"))
        {
            buttonText.GetButtons();
        }
        
        if (GUILayout.Button("Clear"))
        {
            buttonText.ClearButtons();
        }
    }
}