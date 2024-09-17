using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChannelScript : MonoBehaviour
{
    public Channel channel;

    public float speed = 1.0f;
    public float fade = 1.0f;

    [SerializeField]
    private Slider speedSlider;

    [SerializeField]
    private Slider fadeSlider;

    [SerializeField]
    private Image image;

    void Update(){
        if(channel == null){
            return;
        }
        if(channel.video != null){
            if(channel.video.Prev_material == image.material){
                return;
            }
            image.material = channel.video.Prev_material;
        }
    }

    public void SetChannel(Channel channel){
        this.channel = channel;
    }

    public void ChangeFade(){
        fade = fadeSlider.value;
    }

    public void ChangeSpeed(){
        speed = speedSlider.value;
    }

    public void OnClick(){
        if(VideoManager.selected){
            channel.setVideo(VideoManager.selectObj);
        }else{
            return;
        }
    }
}
