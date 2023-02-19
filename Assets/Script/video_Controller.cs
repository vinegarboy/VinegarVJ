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

    [SerializeField]
    VideoPlayer[] vp = new VideoPlayer[6];

    void Start(){
        for(int i = 0;i<vp.Length;i++){
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
