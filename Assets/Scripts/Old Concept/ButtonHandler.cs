using UnityEngine;
using System.Collections.Generic;

public class ButtonHandler : MonoBehaviour
{
    public List<ButtonConnector> buttons;
    void Update()
    {
        if (buttons.Count > 0)
            foreach (var currentButton in buttons)
            {
                if (currentButton.button.other == null || currentButton.buttonActivator.other == null)
                {
                    currentButton.onUp?.Invoke();
                }
                else if (currentButton.button.other == currentButton.buttonActivator.gameObject)
                {
                    currentButton.onPressed?.Invoke();
                }
                else
                {
                    currentButton.onUp?.Invoke();
                }

            }
    }
}