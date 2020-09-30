using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorButton : MonoBehaviour
{
    public GameObject editorwindow;

    public void enableEditorButton()
    {
        editorwindow.SetActive(true);
    }
}
