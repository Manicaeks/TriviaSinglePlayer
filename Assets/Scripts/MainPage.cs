using UnityEngine;
using System.Collections;

public class MainPage : MonoBehaviour {

 public void LoadOffline(){
		Application.LoadLevel(1);
	}

	public void LoadScores(){
		Application.LoadLevel(3);
	}

	public void LoadSettings(){
		Application.LoadLevel(4);
	}
	void Start(){
	if (UICamera.mainCamera && Screen.height > 0){
		var orgRatio = 1280f / 720f;
		var ratio = (float)Screen.width / (float)Screen.height;
		if (ratio > 0)
		{
			UICamera.mainCamera.backgroundColor = Color.black;
			UICamera.mainCamera.orthographicSize = orgRatio / ratio;
		}
	}
	}

}
