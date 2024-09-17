
using System.Collections.Generic;

public static class VideoManager{
    public static VideoObject selectObj;
    public static bool selected = false;
    public static List<VideoObject> videos = new List<VideoObject>();

    public static void ResetSelectedManager(){
        selected = false;
        selectObj = null;
    }
}