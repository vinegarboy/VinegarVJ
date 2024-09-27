

using System;

public class Channel{
    public VideoObject video;
    public int channel_id;
    private Guid video_id;

    public float fade = 1.0f;

    public Channel(int id){
        channel_id = id;
    }

    public void setVideo(){
        if(VideoManager.selectObj == null){
            return;
        }
        video = VideoManager.selectObj;
        video_id = video.guid;
        VideoManager.ResetSelectedManager();
        ChangeParentMaterial();
    }

    public void setVideo(VideoObject video){
        this.video = video;
        video_id = video.guid;
        VideoManager.ResetSelectedManager();
        ChangeParentMaterial();
    }

    private void ChangeParentMaterial(){
        if(video == null){
            return;
        }
        ChannelManager.material.SetTexture("_Tex" + channel_id+1, video.renderTexture);
    }
}