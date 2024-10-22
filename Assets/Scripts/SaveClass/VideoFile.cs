[System.Serializable]
public class VideoFile{
    public string VideoPath;
    public float bpm = -1.0f;

    public float now_bpm = -1.0f;

    public float speed = 1.0f;
    public bool has_bpm;

    public VideoFile(string path,float bpm,float speed,bool has_bpm){
        VideoPath = path;
        this.bpm = bpm;
        this.speed = speed;
        this.has_bpm = has_bpm;
    }
}

[System.Serializable]
public class VideosData{
    public VideoFile[] videos;
    public VideosData(VideoFile[] videos){
        this.videos = videos;
    }

    public VideoFile[] GetVideos(){
        return videos;
    }
}   