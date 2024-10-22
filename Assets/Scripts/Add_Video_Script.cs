using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Add_Video_Script : MonoBehaviour
{
    [SerializeField]
    public TMP_InputField bpm_text;

    [SerializeField]
    public TMP_InputField path_text;
    public Toggle has_bpm;

    [SerializeField]
    public GameObject FilePrefab;

    [SerializeField]
    public GameObject FileMother;

    [SerializeField]
    private GameObject window;

    public void SaveFiles(){
        Debug.Log("SaveFiles");
        int bpm = -1;
        if(has_bpm.isOn){
            bpm = int.Parse(bpm_text.text);
        }
        if(((has_bpm.isOn && bpm > 0) || !has_bpm.isOn)&&File.Exists(path_text.text)){
            GameObject fileObj = Instantiate(FilePrefab,FileMother.transform);
            fileObj.transform.localPosition += new Vector3(0, -(FileMother.transform.childCount-1)*100f,0);
            fileObj.GetComponent<FileScript>().path = path_text.text;
            fileObj.GetComponent<FileScript>().bpm = bpm;
            fileObj.GetComponent<FileScript>().has_bpm = has_bpm.isOn;
            fileObj.GetComponent<FileScript>().Initialize();
            window.SetActive(false);
        }else{
            Debug.Log("Error");
        }
    }
}
