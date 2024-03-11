using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public FlexibleColorPicker fcp;
    public Button[] buttons; 

    public ColorBlock cb;
    public Image bg;
    public float H, S, V;

    private void Update()
    {
        foreach (Button button in buttons)
        {
            cb = button.colors;
            cb.normalColor = fcp.color;
            Color.RGBToHSV(fcp.color, out  H, out  S, out  V);
            cb.highlightedColor = Color.HSVToRGB(H, S, V * 0.6f);
            cb.pressedColor = cb.highlightedColor;
            cb.selectedColor = cb.pressedColor;
            button.colors = cb;
        }
        bg.color = cb.highlightedColor * 0.8f;

    }
}