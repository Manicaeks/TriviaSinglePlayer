using UnityEngine;
using System.Collections;

public class ScoreUpdate : MonoBehaviour {
	public UILabel lblscore;
	public UILabel lbltScore;
	public UILabel lblcorrect;
	public UILabel lbltCorrect;
	public UILabel lblerror;
	public UILabel lbltError;
	public UILabel lbltotal;
	public UILabel lbltTotal;

	public UIButton share;
	public UIButton menu;

	private float score, correct, error, asked, tscore, tcorrect, terror, tasked;
	// Use this for initialization
	void Start () {
		lblscore.text = PlayerPrefs.GetFloat("tScore").ToString();
		lbltScore.text = PlayerPrefs.GetFloat("Score").ToString();
		lblcorrect.text = PlayerPrefs.GetFloat("tCorrectAnswers").ToString();
		lbltCorrect.text = PlayerPrefs.GetFloat("CorrectAnswers").ToString();
		lbltotal.text = PlayerPrefs.GetFloat("tQuestionsAsked").ToString();
		lbltTotal.text = PlayerPrefs.GetFloat("QuestionsAsked").ToString();
		lblerror.text = (PlayerPrefs.GetFloat("tCorrectAnswers")/PlayerPrefs.GetFloat("tQuestionsAsked")*100).ToString();
		lbltError.text = (PlayerPrefs.GetFloat("CorrectAnswers")/PlayerPrefs.GetFloat("QuestionsAsked")*100).ToString();
	}

	public void MainMenu(){
		Application.LoadLevel(0);
	}
}
