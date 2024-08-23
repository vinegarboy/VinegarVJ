

public class Channel{
    public VideoObject video;
    public int channel_id;

    public Channel(int id){
        channel_id = id;
    }

    public void setVideo(){
        if(VideoManager.selectObj == null){
            return;
        }
        video = VideoManager.selectObj;
    }
}