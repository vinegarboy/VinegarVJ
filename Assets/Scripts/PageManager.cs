using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageManager : MonoBehaviour{
	//ページングするPrefabを指定
	[SerializeField]
	private GameObject[] pagePrefabs;

	//現在のページ番号
	private int currentPageIndex = 0;

	void Awake(){
		(this.transform as RectTransform).sizeDelta = new Vector2(Screen.width * 2, Screen.height);
		currentPageIndex = 0;
	}

	void ToRight(){
		currentPageIndex++;
	}

	void ToLeft(){
		currentPageIndex--;
	}

	void SetPagePosition(){
		pagePrefabs[currentPageIndex].transform.localPosition = new Vector3(0, 0, 0);
	}
}
