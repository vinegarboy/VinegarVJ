using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoMaterial : MonoBehaviour{

    [SerializeField]
    private static int width = 1920;
    
    [SerializeField]
    private static int height = 1080;
    private Material material;
    private VideoPlayer videoPlayer;

    private RenderTexture renderTexture;
    public int playBPM = 0;

    private FileObject files;

    public VideoMaterial(FileObject files){
        this.files = files;
        videoPlayer = new VideoPlayer(){
            url = files.GetPath(),
            playOnAwake = false,
            renderMode = VideoRenderMode.RenderTexture
        };
        renderTexture = new RenderTexture (width,height, 24);
        videoPlayer.targetTexture = renderTexture;
        material = new Material(Shader.Find("VinegarShader/FadeShader"));
        material.SetTexture("_MainTex", renderTexture);
    }

    public RenderTexture GetRenderTexture(){
        return renderTexture;
    }

    public FileObject GetFileObject(){
        return files;
    }
}