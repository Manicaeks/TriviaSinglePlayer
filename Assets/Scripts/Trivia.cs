using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Trivia : MonoBehaviour {
	public UISlider progressBar;
	public UILabel lblScore;

	public UILabel question;		//labels for the questions
	public UILabel buttonA, buttonB, buttonC, buttonD;		
	public UIButton btnA, btnB, btnC, btnD;
	private UIButton winner;
	private BetterList<UIButton> buttons = new BetterList<UIButton>();		//list of buttons

	public List<List<string>> filedata;		//list of questions
	private string tempString;			//getting
	private int tempNumb;				//the
	private int answer;					//info
	private float countdown = 3f;		//round timers
	private float roundtime = 45f;
	private float progress;
	private bool loaded = false;
	private bool started = false;
	private bool finished = false;
	public GameObject box;
	public static int score = 0;
	public float questions, correctAnswers;
	

	public GameObject correct, wrong;

	// Use this for initialization
	void Start () {
		ReadFile (Application.dataPath + "/Trivia/Questions.txt");

		if(loaded)
		SetRound();

	}

	void SetQuestion(){
		tempNumb = Random.Range (0,filedata.Count - 1);		//pick random number from 0 to end of index
		answer = int.Parse(filedata[tempNumb][5]);			//the answer is in that row, column 6(index5)
		tempString = filedata[tempNumb][0];					//question
		question.text = tempString;							//setting the labels
		buttonA.text = filedata[tempNumb][1];
		buttonB.text = filedata[tempNumb][2];
		buttonC.text = filedata[tempNumb][3];
		buttonD.text = filedata[tempNumb][4];
		while(countdown > 0f){									//pause before starting for load time
			countdown -= Time.deltaTime;
		}
	}
	void SetAnswer(){
		buttons.Add(btnA);							//adding buttons to an array
		buttons.Add(btnB);
		buttons.Add(btnC);
		buttons.Add(btnD);
		winner = buttons[answer];
	}

	void Update(){
		if (started && progressBar.value > 0){										
			roundtime -= Time.deltaTime;
			progress = roundtime * (100/60);
			progressBar.value = (progress) / 45;
		}
		if(progressBar.value <= 0){
			finished = true;
		}

		if(finished){
			SaveData();
			box.SetActive(true);
		}
	}

	void SetRound(){
		SetQuestion();
		SetAnswer();
		questions++;
		started = true;
	}
	public void OnClick(){
		if (started && progressBar.value > 0 && finished == false){
		if(UIButton.current == winner){
			Correct();
		}
		else{
			Wrong();
		}
		lblScore.text = "Score: " + Trivia.score.ToString();
		Reset ();
		}
	}

	public void ReadFile(string filename){
		var sr = File.OpenText(filename);
		filedata = sr.ReadToEnd().Split('\n').Select(s=>s.Split(',').ToList()).ToList();
		sr.Close();
		loaded = true;
	}

	void Correct(){
		Instantiate(correct, transform.position, Quaternion.identity);
		correctAnswers++;
		score += 2;
	}

	void Wrong(){
		Instantiate(wrong, transform.position, Quaternion.identity);
		score--;
	}

	void SaveData(){
		float totalscore = PlayerPrefs.GetFloat("Score", 0);
		float totalasked = PlayerPrefs.GetFloat("QuestionsAsked", 0);
		float totalcorrect = PlayerPrefs.GetFloat("CorrectAnswers", 0);

		totalscore += score;
		totalasked += questions;
		totalcorrect += correctAnswers;


		PlayerPrefs.SetFloat("tScore", score);
		PlayerPrefs.SetFloat("tQuestionsAsked", questions);
		PlayerPrefs.SetFloat("tCorrectAnswers", correctAnswers);
		PlayerPrefs.SetFloat("Score", totalscore);
		PlayerPrefs.SetFloat("QuestionsAsked", totalasked);
		PlayerPrefs.SetFloat("CorrectAnswers", totalcorrect);
	}

	public void Done(){
		Application.LoadLevel(0);
	}

	void Reset(){
		SetRound();
	}
}
