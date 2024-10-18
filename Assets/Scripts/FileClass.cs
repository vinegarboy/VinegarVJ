

public class FileClass{
    public string VideoPath;
    public float bpm;
    public bool has_bpm;

    public FileClass(string path, float bpm, bool has_bpm)
    {
        this.VideoPath = path;
        this.bpm = bpm;
        this.has_bpm = has_bpm;
    }
}