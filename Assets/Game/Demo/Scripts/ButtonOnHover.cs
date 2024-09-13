using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonTextHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI buttonText; // Reference to the TextMeshPro text component

    void Start()
    {
        if (buttonText == null)
        {
            buttonText = GetComponent<TextMeshProUGUI>();
        }
    }

    // When the mouse pointer enters the button area
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Set the text to bold
        buttonText.fontStyle = FontStyles.Bold;
    }

    // When the mouse pointer exits the button area
    public void OnPointerExit(PointerEventData eventData)
    {
        // Reset the text style back to normal
        buttonText.fontStyle = FontStyles.Normal;
    }
}
