using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class FileScript : MonoBehaviour{
    public string path;
    public float bpm;
    public bool has_bpm = true;
    [SerializeField] private Image image;
    [SerializeField] private GameObject BackImagePanel;
    [SerializeField] private TextMeshProUGUI FileName;
    [SerializeField] private TextMeshProUGUI BPM;

    private FileClass file_data;

    private VideoObject video;

    public void Initialize(){
        Debug.Log("Initialize");
        if(path == null || File.Exists(path) == false){
            Debug.Log("Path is null");
            Destroy(this.gameObject);
            return;
        }
        video = new VideoObject(path);
        if(has_bpm){
            video.bpm = bpm;
            BPM.text = video.bpm.ToString();
        }else{
            BPM.text = "No BPM";
        }
        FileName.text = Path.GetFileName(path);
        image.material = video.Prev_material;
        file_data = new FileClass(path,bpm,has_bpm);
        Debug.Log("Initialize Comp");
    }

    void Update(){
        if(VideoManager.selectObj != video){
            BackImagePanel.SetActive(false);
        }
    }

    public void OnClick(){
        Debug.Log("Clicked");
        if(VideoManager.selected && VideoManager.selectObj == this.video){
            VideoManager.ResetSelectedManager();
            BackImagePanel.SetActive(false);
            Debug.Log("Deselected");
            return;
        }
        BackImagePanel.SetActive(true);
        VideoManager.selectObj = video;
        VideoManager.selected = true;
        Debug.Log("Selected");
    }
}
