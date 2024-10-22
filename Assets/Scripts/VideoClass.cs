using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoObject{
    public string VideoPath;
    public float bpm = -1.0f;

    public float now_bpm = -1.0f;

    public float speed = 1.0f;
    public bool has_bpm;
    public VideoPlayer Videos;
    public RenderTexture renderTexture;
    public Material Prev_material;
    public Guid guid;

    public VideoObject(string path){
        has_bpm = false;
        GameObject camera = GameObject.Find("Main Camera");
        Videos = camera.AddComponent<UnityEngine.Video.VideoPlayer>();
        VideoPath = path;
        Videos.renderMode = VideoRenderMode.RenderTexture;
        Videos.url = VideoPath;
        this.guid = Guid.NewGuid();
        renderTexture = new RenderTexture(1920, 1080, 24);
        renderTexture.wrapMode = TextureWrapMode.Repeat;
        Videos.targetTexture = renderTexture;
        Videos.Play();
        Videos.isLooping = true;
        Prev_material = new Material(Shader.Find("VinegarShader/FadeShader"));
        Prev_material.SetTexture("_MainTex", renderTexture);
        VideoManager.videos.Add(this);
    }

    public void SetBPM(float bpm){
        if(bpm <= 0){
            return;
        }
        this.bpm = bpm;
        has_bpm = true;
        now_bpm = bpm*speed;
    }

    public void ChangeSpeed(float speed = -1.0f){
        if(speed < 0){
            return;
        }
        Videos.playbackSpeed = speed;
        if(has_bpm){
            now_bpm = bpm*speed;
        }
    }

    public void ChangeBPM(float bpm = -1.0f){
        if(bpm < 0 || !has_bpm){
            return;
        }
        now_bpm = bpm;
        speed = now_bpm /bpm;
        Videos.playbackSpeed = speed;
    }
}