using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class FileScript : MonoBehaviour{
    public string path;
    public int bpm;
    public bool has_bpm = true;
    [SerializeField] private Image image;
    [SerializeField] private GameObject BackImagePanel;
    [SerializeField] private TextMeshProUGUI FileName;
    [SerializeField] private TextMeshProUGUI BPM;

    private VideoObject video;

    public void Initialize(){
        if(path == null){
            Debug.Log("Path is null");
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
    }

    void Update(){
        if(VideoManager.selected){
            if(VideoManager.selectObj.guid != video.guid){
                BackImagePanel.SetActive(false);
            }
        }
    }

    public void OnClick(){
        if(VideoManager.selected && VideoManager.selectObj.guid == video.guid){
            VideoManager.ResetSelectedManager();
            BackImagePanel.SetActive(false);
            return;
        }
        BackImagePanel.SetActive(true);
        VideoManager.selectObj = video;
        VideoManager.selected = true;
    }
}
