using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileList : MonoBehaviour
{
    String Now_path = "C:";

    void Start(){
        Now_path = Directory.GetCurrentDirectory();
    }

    public void Path_Up(){

    }
}
