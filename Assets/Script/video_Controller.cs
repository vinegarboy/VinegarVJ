using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class video_Controller : MonoBehaviour
{
    [SerializeField]
    Slider[] touka = new Slider[6];
    
    [SerializeField]
    Slider[] speed = new Slider[6];
    
    [SerializeField]
    Material main;

    [SerializeField]
    Material[] prev_mat = new Material[6];

    RenderTexture[] prev_rt = new RenderTexture[6];

    RenderTexture[] rt;

    VideoPlayer[] vp;

    public void Initialize(List<String> files){
        vp = new VideoPlayer[files.Count];
        rt = new RenderTexture[files.Count];
        for(int i = 0;i<files.Count;i++){
            vp[i].url = files[i];
            vp[i].targetTexture = rt[i];
            rt[i].width = 3840;
            rt[i].height = 2160;
        }
        for(int i = 0;i<6;i++){
            prev_mat[i].mainTexture = prev_rt[i];
            main.SetTexture($"_Tex{i+1}",rt[i]);
            Change_speed(i);
            Change_touka(i);
        }
    }

    public void Change_touka(int num){
        main.SetFloat($"_mix_Tex{num+1}", 1-touka[num].value);
        prev_mat[num].SetFloat("_mix", 1-touka[num].value);
    }

    public void Change_speed(int num){
        vp[num].playbackSpeed = (int) speed[num].value;
    }
}
