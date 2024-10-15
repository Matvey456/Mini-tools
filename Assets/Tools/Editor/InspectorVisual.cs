using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MonoBehaviour), true)]
public class InspectorVisual : Editor
{
    public override void OnInspectorGUI()
    {
        MonoBehaviour targetObject = (MonoBehaviour) target;

        DrawDefaultInspector();

        if (targetObject is ButtonText buttonText)
        {
            CreateInspectorButton("Get Data", () => buttonText.GetButtons());
            CreateInspectorButton("Clear", () => buttonText.ClearButtons());
        }

        if (targetObject is Text text)
        {
            CreateInspectorButton("Get Data", () => text.GetText());
            CreateInspectorButton("Clear", () => text.ClearText());
        }
    }

    private void CreateInspectorButton(string text, System.Action action)
    {
        if (GUILayout.Button(text))
        {
            action?.Invoke();
        }
    }
}