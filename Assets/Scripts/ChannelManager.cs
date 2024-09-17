

using System.Collections.Generic;
using UnityEngine;

public static class ChannelManager{
    public static List<Channel> channels = new List<Channel>();
    public static Material material = new Material(Shader.Find("VinegarShader/MixShader"));
}