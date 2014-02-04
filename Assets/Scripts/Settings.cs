using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

	public void ClearData(){
		PlayerPrefs.DeleteAll();
	}

	public void Menu(){
		Application.LoadLevel(0);
	}
}
