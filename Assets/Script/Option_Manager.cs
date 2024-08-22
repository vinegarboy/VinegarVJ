using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Option_Manager : MonoBehaviour
{
    //設定ファイルを読み込む
    public VideoMaterial[] Load_OptionFile(string pass){
        StreamReader sr = new StreamReader(pass+"/option.json");
        VideoData[] vd = JsonUtility.FromJson<VideoData[]>(sr.ReadToEnd());
        sr.Close();
        VideoMaterial[] materials = new VideoMaterial[vd.Length];
        for(int i = 0;i < vd.Length;i++){
            materials[i] = vd[i].ChangeMat();
        }
        return materials;
    }

    //動画に関するデータをjsonに保存する。
    public void Save_OptionFile(string pass,VideoMaterial[] materials){
        StreamWriter sw = new StreamWriter(pass+"/option.json");
        VideoData[] vd = new VideoData[materials.Length];
        int i = 0;
        foreach(VideoMaterial material in materials){
            vd[i] = new VideoData(material.GetFileObject().GetPath(),material.GetFileObject().GetBPM());
        }
        sw.WriteLine(JsonUtility.ToJson(vd));
        sw.Close();
    }

    private class VideoData{
        public string path;
        public int bpm;

        public VideoData(string path,int bpm){
            this.path = path;
            this.bpm = bpm;
        }

        public VideoMaterial ChangeMat(){
            return new VideoMaterial(new FileObject(path,bpm));
        }
    }
}
