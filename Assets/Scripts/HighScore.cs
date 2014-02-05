using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {
	public UILabel one, two, three, four, five;
	int i;
	void Start(){
		UpdateScores();
	}

	public void Menu(){
		Application.LoadLevel(0);
	}

	public void ClearScores(){
		for(i=0; i<6;i++){
		PlayerPrefs.DeleteKey("highscorePos"+i);
		}
		UpdateScores();
	}



	void UpdateScores(){
		i=0;
		one.text = "1. " + PlayerPrefs.GetFloat("highscorePos" + i);
		i++;
		two.text = "2. " + PlayerPrefs.GetFloat("highscorePos" + i);
		i++;
		three.text = "3. " + PlayerPrefs.GetFloat("highscorePos" + i);
		i++;
		four.text = "4. " + PlayerPrefs.GetFloat("highscorePos" + i);
		i++;
		five.text = "5. " + PlayerPrefs.GetFloat("highscorePos" + i);
	}
}
