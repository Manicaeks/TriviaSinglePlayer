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
	private float totalscore, totalasked, totalcorrect;
	public UIButton menu;
	private int correctper;
	
	// Use this for initialization
	void Start () {
		correctper = (Trivia.correctAnswers / Trivia.questions) * 100;
		GetKeys();
		totalscore += Trivia.score;
		totalasked += Trivia.questions;
		totalcorrect += Trivia.correctAnswers;

		PlayerPrefs.SetFloat("Score", totalscore);
		PlayerPrefs.SetFloat("QuestionsAsked", totalasked);
		PlayerPrefs.SetFloat("CorrectAnswers", totalcorrect);
		PlayerPrefs.Save();


		GetScores();
	}

	void GetScores(){
		lblscore.text = "Score: " + Trivia.score;
		lbltScore.text = "Lifetime Total Score: " + PlayerPrefs.GetFloat("Score");
		lblcorrect.text = "Correct Answers: " + Trivia.correctAnswers;
		lbltCorrect.text = "Lifetime Correct Answers: " + PlayerPrefs.GetFloat("CorrectAnswers");
		lbltotal.text = "Questions Answered: " + Trivia.questions;
		lbltTotal.text = "Lifetime Questions Answered:" + PlayerPrefs.GetFloat("QuestionsAsked");
		lblerror.text = "Correct %: " + correctper;
		lbltError.text = "Lifetime Correct %: " + (PlayerPrefs.GetFloat("CorrectAnswers")/PlayerPrefs.GetFloat("QuestionsAsked")*100).ToString("F2");
	}
	public void MainMenu(){
		Application.LoadLevel(0);
	}

	void GetKeys(){
		totalscore = PlayerPrefs.GetFloat("Score", 0);

		totalasked = PlayerPrefs.GetFloat("QuestionsAsked", 0);

		totalcorrect = PlayerPrefs.GetFloat("CorrectAnswers", 0);
	}
}
