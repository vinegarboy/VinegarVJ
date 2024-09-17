using System.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeScript : MonoBehaviour
{

    /*Initialize順

    1.ファイルを読み込む
    2.ファイルを読み込んだら、そのファイルの情報を取得する
    3.ファイル情報をファイルオブジェクトの列挙
    4.チャンネルの生成
    */
    void Start(){
        String data_path = Application.dataPath + "/Resources/";
        if(File.Exists(data_path+"option.json")){
            
        }
        this.gameObject.SetActive(false);
    }
}
