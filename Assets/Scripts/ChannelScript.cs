using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class ChannelScript : MonoBehaviour,IPointerClickHandler
{
    [SerializeField]
    private Image Prev;

    [NonSerialized]
    public Material material;

    private RenderTexture tex;

    private VideoPlayer vp;

    [SerializeField]
    private ToggleGroup group;

    private int id;

    private void Awake()
    {
        material = new Material(Shader.Find("VinegarShader/FadeShader"));
        tex = new RenderTexture(1920, 1080, 24);
        tex.name = $"{gameObject.name}_RenderTexture";
        tex.Create();
        vp = Camera.main.gameObject.AddComponent<VideoPlayer>();
        vp.playOnAwake = true;
        vp.renderMode = VideoRenderMode.RenderTexture;
        vp.audioOutputMode = VideoAudioOutputMode.None;
        vp.isLooping = true;
        vp.targetTexture = tex;

        Prev.material = material;
        material.SetTexture("_MainTex", tex);
        material.SetFloat("_mix", 0f);

        id = MainVideo.SetChannel(gameObject);
    }

    public void SetVideo(string path)
    {
        vp.url = path;
        vp.Play();
    }

    public void SetVideo(VideoClip clip)
    {
        vp.clip = clip;
        vp.Play();
    }

    public void SetFade(float value)
    {
        material.SetFloat("_mix", value);
        MainVideo.SetFade(id);
    }

    public void SetSpeed(float value)
    {
        vp.playbackSpeed = value;
    }

    public RenderTexture GetTexture()
    {
        return tex;
    }

    public float GetFade()
    {
        return material.GetFloat("_mix");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (FileObject.IsSelected())
        {
            var obj = FileObject.GetSelectedObject();
            SetVideo(obj.GetComponent<FileObject>()._filePath);
            FileObject.ResetSelection();

            MainVideo.Set_Video(id);
        }
    }
}