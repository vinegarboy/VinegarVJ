using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class CreatetFileList : MonoBehaviour
{
    private string path;

    [SerializeField]
    private GameObject Child;

    [SerializeField]
    private RectTransform viewPanel;

    [SerializeField]
    private ToggleGroup group;

    readonly string[] extensions = new string[] {
        ".asf", ".avi", ".dv", ".m4v", ".mov",
        ".mp4", ".mpg", ".mpeg", ".ogv", ".vp8",
        ".webm", ".wmv"
    };

    void Awake()
    {
        path = Application.persistentDataPath + "/Videos";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
            Debug.Log("Directory created at: " + path);
            return;
        }
        string[] files = extensions.SelectMany(ext => Directory.GetFiles(path, "*" + ext, SearchOption.AllDirectories)).ToArray();
        if (files.Length == 0)
        {
            Debug.Log("No files found in: " + path);
            return;
        }
        foreach (string file in files)
        {
            string filename = Path.GetFileName(file);
            GameObject child = Instantiate(Child, transform);
            child.GetComponent<FileObject>().SetData(filename, file);
            child.GetComponent<Toggle>().group = group;
            child.name = filename;
        }
        viewPanel.sizeDelta = new Vector2(viewPanel.sizeDelta.x, files.Length * 50f);
    }
}
