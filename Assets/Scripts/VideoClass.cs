using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoObject{
    public string VideoPath;
    public float bpm = -1.0f;
    public bool has_bpm;
    public VideoPlayer Videos;
    public RenderTexture renderTexture;
    public Material Prev_material;
    public Guid guid;

    public VideoObject(string path){
        has_bpm = false;
        VideoPath = path;
        Videos.source = VideoSource.Url;
        this.guid = Guid.NewGuid();
        renderTexture = new RenderTexture(1920, 1080, 24);
        renderTexture.wrapMode = TextureWrapMode.Repeat;
        Videos.targetTexture = renderTexture;
        Videos.url = VideoPath;
        Videos.Play();
        Videos.isLooping = true;
        Prev_material = new Material(Shader.Find("VinegarShader/MixShader"));
        Prev_material.SetTexture("_MainTex", renderTexture);
        VideoManager.videos.Add(this);
    }
}