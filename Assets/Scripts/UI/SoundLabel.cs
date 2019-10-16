using System;
using TMPro;
using UnityEngine;

public class SoundLabel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _labelText;

    public void SetText(String text)
    {
        _labelText.text = text;
    }
}