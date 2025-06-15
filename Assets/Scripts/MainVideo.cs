using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainVideo : MonoBehaviour
{
    private static MainVideo _instance;

    private static Material _material;

    private static List<GameObject> _channels = new List<GameObject>();

    [SerializeField]
    private Image Prev;

    private void Awake()
    {
        _instance = this;
        _material = new Material(Shader.Find("VinegarShader/MixShader"));

        Prev.material = _material;
    }

    public static void Set_Video(int id)
    {
        _material.SetTexture($"_Tex{id + 1}", _channels[id].GetComponent<ChannelScript>().GetTexture());
        _material.SetFloat($"_mix_Tex{id + 1}", _channels[id].GetComponent<ChannelScript>().GetFade());
    }

    public static int SetChannel(GameObject obj)
    {
        _channels.Add(obj);
        _material.SetTexture($"_Tex{_channels.Count}", _channels[_channels.Count - 1].GetComponent<ChannelScript>().GetTexture());
        _material.SetFloat($"_mix_Tex{_channels.Count}", _channels[_channels.Count - 1].GetComponent<ChannelScript>().GetFade());
        return _channels.Count - 1;
    }

    public static void SetFade(int id)
    {
        _material.SetFloat($"_mix_Tex{id + 1}", _channels[id].GetComponent<ChannelScript>().GetFade());
    }
}
