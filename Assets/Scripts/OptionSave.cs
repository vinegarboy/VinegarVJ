using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSave : MonoBehaviour
{
    public void FilesSave(){
        VideoManager.SaveVideosData();
    }
}
