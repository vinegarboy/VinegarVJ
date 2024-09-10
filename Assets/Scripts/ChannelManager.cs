

using System.Collections.Generic;
using UnityEngine;

public static class ChannelManager{
    public static List<Channel> channels = new List<Channel>();
    public static Material material = new Material(Shader.Find("VinegarShader/FadeShader"));

    public static void Initialize(){
        if(VideoManager.videos.Count < 8){
            for(int i = 0; i < VideoManager.videos.Count; i++){
                Channel channel = new Channel(i);
                channels.Add(channel);
                channel.setVideo(video: VideoManager.videos[i]);
                material.SetTexture("_Tex" + i+1, channel.video.renderTexture);
            }
        }else{
            for(int i = 0; i < channels.Count; i++){
                Channel channel = new Channel(i);
                channels.Add(channel);
                channel.setVideo(video: VideoManager.videos[i]);
                material.SetTexture("_Tex" + i+1, channel.video.renderTexture);
            }
        }
    }
}