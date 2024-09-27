
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class VideoManager{
    public static VideoObject selectObj;
    public static bool selected = false;
    public static List<VideoObject> videos = new List<VideoObject>();

    public static void ResetSelectedManager(){
        selected = false;
        selectObj = null;
    }

    public static void SaveVideosData(){
        VideoObject[] video_array = videos.ToArray();
        string json = JsonUtility.ToJson(video_array);
        StreamWriter sw = new StreamWriter(Application.dataPath + "/Resources/option.json",false);
        sw.Write(json);
        sw.Close();
    }
}