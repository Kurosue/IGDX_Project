using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HighlighButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
 public UnityEngine.Color normalColor = UnityEngine.Color.white;
    public UnityEngine.Color highlightColor = UnityEngine.Color.yellow;
    private Text buttonText;
    private bool isPointerOver = false;  // Flag untuk melacak status pointer

    void Start()
    {
        buttonText = GetComponentInChildren<Text>();

        if (buttonText != null)
        {
            buttonText.color = normalColor;  // Set warna awal
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonText != null && !isPointerOver)
        {
            buttonText.color = highlightColor;  // Ubah warna saat hover
            isPointerOver = true;  // Tandai bahwa pointer berada di atas tombol
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonText != null && isPointerOver)
        {
            buttonText.color = normalColor;  // Kembalikan warna ke normal saat pointer keluar
            isPointerOver = false;  // Tandai bahwa pointer sudah keluar
        }
    }
}

