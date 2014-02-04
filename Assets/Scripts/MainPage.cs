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

}
