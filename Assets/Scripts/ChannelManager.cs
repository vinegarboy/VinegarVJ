

using System.Collections.Generic;
using UnityEngine;

public static class ChannelManager{
    public static List<Channel> channels = new List<Channel>();
    public static Material material = new Material(Shader.Find("VinegarShader/MixShader"));

    public static void SetVideo(){
        for(int i = 0;i<channels.Count;i++){
            if(channels[i].video==null){
                continue;
            }
            material.SetTexture($"_Tex{i+1}",channels[i].video.renderTexture);
        }
    }

    public static void FadeSet(){
        for(int i = 0;i<channels.Count;i++){
            material.SetFloat($"_mix_Tex{i+1}", channels[i].fade);
        }
    }
}