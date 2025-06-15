using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FileObject : MonoBehaviour
{
    private static GameObject _selectedObject;

    private string _fileName;
    public string _filePath;

    [SerializeField]
    private TextMeshProUGUI text;

    public void SetData(string filename, string filepath)
    {
        _fileName = filename;
        _filePath = filepath;
        text.text = _fileName;
    }

    public void ToggleSelection(bool state)
    {
        if (state)
        {
            _selectedObject = gameObject;
        }
        else
        {
            if (_selectedObject == gameObject)
            {
                _selectedObject = null;
            }
        }
        Debug.Log("Selected Object: " + (_selectedObject != null ? _selectedObject.name : "None"));
    }

    public static bool IsSelected()
    {
        return _selectedObject != null;
    }

    public static GameObject GetSelectedObject()
    {
        return _selectedObject;
    }

    public static void ResetSelection()
    {
        _selectedObject.GetComponent<Toggle>().group.SetAllTogglesOff();
        _selectedObject = null;
    }
}
