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

void Start()
    {
        // Cari komponen Text di dalam button (termasuk di dalam container)
        buttonText = GetComponentInChildren<Text>();

        if (buttonText != null)
        {
            buttonText.color = normalColor; // Set warna teks awal
        }
        else
        {
            Debug.LogError("Komponen Text tidak ditemukan di dalam Button.");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = highlightColor; // Ubah warna saat hover
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (buttonText != null)
        {
            buttonText.color = normalColor; // Kembalikan ke warna awal
        }
    }
}

