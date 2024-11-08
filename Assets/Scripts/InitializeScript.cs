using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitializeScript : MonoBehaviour
{

    [SerializeField]
    private GameObject FilePrefab;

    [SerializeField]
    private GameObject FileMother;

    [SerializeField]
    private GameObject[] Channels;

    [SerializeField]
    private Image MainImage;

    /*Initialize順

    1.ファイルを読み込む
    2.ファイルを読み込んだら、そのファイルの情報を取得する
    3.ファイル情報をファイルオブジェクトの列挙
    4.チャンネルの生成
    */
    void Start(){
        String data_path = Application.dataPath + "/Resources/";
        if(!Directory.Exists(Application.dataPath + "/Resources")){
            Directory.CreateDirectory(data_path);
        }
        Debug.Log("Initialize Start");
        Debug.Log(data_path+"option.json");
        VideosData JsonData;
        if(File.Exists(data_path+"option.json")){
            Debug.Log("option.json exists");
            JsonData = JsonUtility.FromJson<VideosData>(File.ReadAllText(data_path+"option.json"));
            VideoFile[] files = JsonData.GetVideos();
            for(int i = 0;i<files.Length;i++){
                GameObject fileObj = Instantiate(FilePrefab,FileMother.transform);
                fileObj.transform.localPosition = new Vector3(0, -(FileMother.transform.childCount-1)*100f,0);
                Debug.Log($"{files[i].VideoPath} is ADD");
                fileObj.GetComponent<FileScript>().path = files[i].VideoPath;
                Debug.Log($"BPM:{files[i].bpm} is Add");
                fileObj.GetComponent<FileScript>().bpm = files[i].bpm;
                fileObj.GetComponent<FileScript>().has_bpm = files[i].has_bpm;
                fileObj.GetComponent<FileScript>().Initialize();
            }
        }else{
            Debug.Log("No option.json");
            if(!File.Exists(data_path+"option.json")){
                File.WriteAllText(data_path+"option.json","");
            }
        }
        for(int i = 0;i < Channels.Length;i++){
            Channels[i].GetComponent<ChannelScript>().SetChannel(new Channel(i));
            ChannelManager.channels.Add(Channels[i].GetComponent<ChannelScript>().channel);
        }
        MainImage.material = ChannelManager.material;
        Debug.Log("Initialize Complete");
        this.gameObject.SetActive(false);
    }
}
