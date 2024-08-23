using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoObject{
    public string VideoPath;
    public float bpm = -1.0f;
    public bool has_bpm;
    public VideoPlayer Videos;
    public RenderTexture renderTexture;

    public VideoObject(string path){
        has_bpm = false;
        VideoPath = path;
        Videos.source = VideoSource.Url;
    }
}