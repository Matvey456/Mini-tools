using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{
    [SerializeField] private List<Texts> textsC = new List<Texts>();
    private List<TMP_Text> texts = new List<TMP_Text>();
    [SerializeField] private GameObject textPanel;

    private void OnValidate()
    {
        Changer();
    }

    private void Changer()
    {
        for (int i = 0; i < texts.Count; i++)
        {
            var text = texts[i];
            text.name = textsC[i].textValue + "Text";
            
            text.text = textsC[i].textValue;
        }
    }
    
    public void GetText()
    {
        texts.AddRange(textPanel.GetComponentsInChildren<TMP_Text>());
        
        textsC.Clear();

        for (int i = 0; i < texts.Count; i++)
        {
            var text = texts[i];
            var newText = new Texts();
            newText.textName = text;
            newText.textValue = text.text;

            textsC.Add(newText);
        }
    }

    public void ClearText()
    {
        texts.Clear();
        textsC.Clear();
    }
    
    [System.Serializable]
    class Texts
    {
        public TMP_Text textName;
        public string textValue;
    }
}
