
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public static class VideoManager{
    public static List<VideoObject> videos = new List<VideoObject>();

    public static void SaveVideosData(){
        VideoFile[] save_data = new VideoFile[videos.Count];
        for(int i = 0; i < videos.Count; i++){
            save_data[i] = new VideoFile(videos[i].VideoPath,videos[i].bpm,videos[i].speed,videos[i].has_bpm);
        }
        VideosData videos_data = new VideosData(save_data);

        string json = JsonUtility.ToJson(videos_data);
        Debug.Log(json);
        
        StreamWriter sw = new StreamWriter(Application.dataPath + "/Resources/option.json",false);
        sw.Write(json);

        sw.Close();
    }

    public static void LoadVideosData(){
        
    }
}