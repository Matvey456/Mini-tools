using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonText : MonoBehaviour
{
    [SerializeField] private List<Buttons> buttonsC = new List<Buttons>();
    private List<Button> buttons = new List<Button>();
    [SerializeField] private GameObject buttonPanel;
    
    
    private void OnValidate()
    {
        Changer();
    }

    public void GetButtons()
    {
        buttons.AddRange(buttonPanel.GetComponentsInChildren<Button>());

        buttonsC.Clear();

        for (int i = 0; i < buttons.Count; i++)
        {
            var button = buttons[i];
            var texts = button.GetComponentsInChildren<TMP_Text>();
            var newButton = new Buttons();
            newButton.button = button;

            if (texts.Length > 0)
            {
                newButton.buttonText = texts[0].text;
            }

            buttonsC.Add(newButton);
        }
    }

    public void ClearButtons()
    {
        buttons.Clear();
        buttonsC.Clear();
    }

    private void Changer()
    {
        for (int i = 0; i < buttonsC.Count; i++)
        {
            var button = buttonsC[i].button;
            var texts = buttonsC[i].button.GetComponentsInChildren<TMP_Text>();
            button.name = buttonsC[i].buttonText + "Button";
            var inter = buttonsC[i].isInteractable;
            button.interactable = inter;
            if (texts.Length > 0)
            {
                texts[0].text = buttonsC[i].buttonText;
            }
        }
    }

    [System.Serializable]
    class Buttons
    {
        public Button button;
        public string buttonText;
        public bool isInteractable = true;
    }
}