using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTheme : MonoBehaviour
{
    public Theme[] themes;
    public InputField themeName;
    public Image xIcon;
    public Image oIcon;
    public Image backgroundIcon;

    public void LoadThemes()
    {
        SaveTheme.themeIndex++;
        if (SaveTheme.themeIndex > 2)
            SaveTheme.themeIndex = 0;
        themeName.text = themes[SaveTheme.themeIndex].name;
        xIcon.sprite = themes[SaveTheme.themeIndex].xIcons;
        oIcon.sprite = themes[SaveTheme.themeIndex].oIcons;        
        backgroundIcon.sprite = themes[SaveTheme.themeIndex].backgroundImage;


    }


}
