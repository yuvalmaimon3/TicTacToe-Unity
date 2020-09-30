using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SaveTheme : MonoBehaviour
{

    public GameManager gameManager;
    public Image xIcons;
    public Image oIcons;
    public Image backgroundImage;
    public Theme[] themes;
    public static int themeIndex;
    public Image backgroundPanel;

    public GameObject editorWindow;
    public InputField themeNameInput;

    public void CreateTheme()
    {
        themes[themeIndex].name = themeNameInput.text;
        themes[themeIndex].xIcons = xIcons.sprite;
        themes[themeIndex].oIcons = oIcons.sprite;
        themes[themeIndex].backgroundImage = backgroundImage.sprite;
#if UNITY_EDITOR
        EditorUtility.SetDirty(themes[themeIndex]);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
#endif
        ApplyTheme();
    }

    private void ApplyTheme()
    {

        gameManager.xoImages[0] = themes[themeIndex].xIcons;
        gameManager.xoImages[1] = themes[themeIndex].oIcons;
        backgroundPanel.sprite = backgroundImage.sprite;
        editorWindow.SetActive(false);
        gameManager.Reset();

    }
}
