using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ThemeName", menuName = "Themes/One")]
public class Theme : ScriptableObject
{
    public new string name;
    public int id;
    public Sprite xIcons;
    public Sprite oIcons;
    public Sprite backgroundImage;

}
