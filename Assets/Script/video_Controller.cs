using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class video_Controller : MonoBehaviour
{

    //現在のパスを収納する場所
    string pass = "C:";

    //親マテリアル
    Material parent;

    //BPM
    public int now_BPM = 128;

    //表示に含まれているマテリアル
    VideoMaterial[] materials = new VideoMaterial[6];

    [SerializeField]
    Option_Manager option_Manager;

    [SerializeField]
    Image parentImage;

    //全ての動画ファイルのマテリアル
    public List<VideoMaterial> all_Videos;

    void Start(){
        parent = new Material(Shader.Find("VinegarShader/MixShader"));
        parentImage.material = parent;
    }

    //初期化処理
    public void Initialize(){
        //実行ファイル直下のVideosに収納する
        pass = Application.dataPath + "/Videos";

        //設定ファイルを読み込む
        all_Videos = new List<VideoMaterial>();
        all_Videos.AddRange(option_Manager.Load_OptionFile(pass));

        //UnityのVideoPlayerで読み込める動画ファイルのフィルターを作る
        string[] filters = {"*.mp4","*.mov","*.avi"};

        //フィルターの拡張子を持つ動画ファイルのパスを取得
        foreach(string filter in filters){
            //取得後にリストに追加
            foreach(string path in Directory.GetFiles(pass,filter)){
                all_Videos.Add(new VideoMaterial(new FileObject(path,0)));
            }
        }
    }

    //メインのマテリアルにサブのマテリアルのテクスチャを付加していく
    public void Set_MainTex(){
        int i = 1;
        foreach(VideoMaterial material in materials){
            parent.SetTexture($"_Tex{i}",material.GetRenderTexture());
            i++;
        }
    }

    //特定の位置に特定のテクスチャを設定する
    public void Set_Tex(int num,VideoMaterial material){
        parent.SetTexture($"_Tex{num}",material.GetRenderTexture());
    }

    public void Change_touka(int num){

    }

    public void Change_speed(int num){

    }
}
