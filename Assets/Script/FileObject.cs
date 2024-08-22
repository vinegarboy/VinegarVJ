using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileObject : MonoBehaviour{
    private string FilePath;
    private int video_bpm;

    public FileObject(string FilePath,int video_bpm){
        this.FilePath = FilePath;
        this.video_bpm = video_bpm;
    }

    public String GetPath(){
        return FilePath;
    }

    public int GetBPM(){
        return video_bpm;
    }

    public void SetBPM(int video_bpm){
        this.video_bpm = video_bpm;
    }
}
