using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FileList : MonoBehaviour
{
    //表示しているディレクトリを示す変数
    String Now_path = "C:";

    // クローン間の距離
    float spacing = 78.21f;

    // 初期位置の変数
    Vector3 position;

    //TextMeshProの元Prefab
    [SerializeField]
    TextMeshProUGUI tpref;

    //親オブジェ
    [SerializeField]
    GameObject parent;

    //サブディレクトリ類を格納する変数
    List<String> Files = new List<String>();

    void Start(){
        Now_path = Directory.GetCurrentDirectory();
        NowGetDirectory();
        ListSet();
        Debug.Log(Now_path);
    }

    public void ListSet(){
        //Listの内容をリセットする。
        foreach (Transform child in parent.transform){
            if (child.gameObject.name.Contains("(Clone)")){
                Destroy(child.gameObject);
            }
        }

        for(int i = 0;i<Files.Count;i++){
            //テキストをクローン
            TextMeshProUGUI newText = Instantiate(tpref, parent.transform.position-new Vector3(0f,spacing*i,0f), Quaternion.identity,parent.transform);
            
            //テキストの内容を設定
            newText.text = Files[i];
        }
        
    }

    public void SetDef(){
        Now_path = Directory.GetCurrentDirectory();

        ListSet();
    }

    public void Path_Up(){
        DirectoryInfo parentDirectory = Directory.GetParent(Now_path);

        // 親ディレクトリが存在する場合、絶対パスを返す
        if (parentDirectory != null){
            Now_path = parentDirectory.FullName;
        }

        ListSet();
    }

    public void NowGetDirectory(){
        //リストの内容を削除する。
        Delete_ListFiles();

        // ディレクトリに存在するすべてのファイルとフォルダを取得する
        string[] files = Directory.GetFiles(Now_path);
        string[] directories = Directory.GetDirectories(Now_path);
        
        // フォルダの絶対パスをリストに追加する
        foreach (string dir in directories){
            Files.Add(dir.Replace(Now_path,""));
        }

        // ファイルの絶対パスをリストに追加する
        foreach (string file in files){
            Files.Add(file.Replace(Now_path,""));
        }
    }

    private void Delete_ListFiles(){
        //内部の要素をすべて削除する
        for(int i = Files.Count;i>0;i--){
            Files.RemoveAt(i);
        }
    }
}
