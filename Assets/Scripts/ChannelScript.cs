using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChannelScript : MonoBehaviour
{
    public Channel channel;

    public float speed = 1.0f;

    [SerializeField]
    private Slider speedSlider;

    [SerializeField]
    private Slider fadeSlider;

    [SerializeField]
    private Image image;

    [SerializeField]
    int id = 0;

    void Start(){
        channel = new Channel(id);
        speedSlider.value = channel.video.speed;
        fadeSlider.value = channel.fade;
    }

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
        channel.fade = fadeSlider.value;
        channel.video.Prev_material.SetFloat("_mix",channel.fade);
        ChannelManager.FadeSet();
    }

    public void ChangeSpeed(){
        if(speedSlider.value == 0){
            channel.video.speed = 0f;
        }else{
            channel.video.speed = speedSlider.value;
        }
    }

    public void OnClick(){
        if(VideoManager.selected){
            channel.setVideo(VideoManager.selectObj);
        }else{
            return;
        }
    }
}
