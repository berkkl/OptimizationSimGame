using System.Collections;
using System.Collections.Generic;
using UIScripts;
using UnityEngine;

[CreateAssetMenu(menuName = "CustomUI/ThemeSO", fileName = "Theme")]
public class ThemeSO : ScriptableObject
{
    [Header("Primary")] 
    public Color primary_bg;
    public Color primary_text;
    
    [Header("Secondary")] 
    public Color secondary_bg;
    public Color secondary_text;

    [Header("Tertiary")] 
    public Color tertiary_bg;
    public Color tertiary_text;

    [Header("Other")] 
    public Color disable;


    public Color GetBackgroundColor(Style style)
    {
        switch (style)
        {
            case Style.Primary:
                return primary_bg;
            case Style.Secondary:
                return secondary_bg;
            case Style.Tertiary:
                return tertiary_bg;
            default:
                return disable;
        }
    }

    public Color GetTextColor(Style style)
    {
        Color selectedColor = disable; // Default color

        switch (style)
        {
            case Style.Primary:
                selectedColor = primary_text;
                Debug.Log("Selected Style: Primary, Color: " + selectedColor);
                break;
            case Style.Secondary:
                selectedColor = secondary_text;
                Debug.Log("Selected Style: Secondary, Color: " + selectedColor);
                break;
            case Style.Tertiary:
                selectedColor = tertiary_text;
                Debug.Log("Selected Style: Tertiary, Color: " + selectedColor);
                break;
            default:
                Debug.Log("Selected Style: Default, Color: " + selectedColor);
                break;
        }

        return selectedColor;
    }


}
