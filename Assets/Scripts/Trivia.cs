using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class Trivia : MonoBehaviour {
	public UISlider progressBar;
	public UILabel lblScore;

	public string highscorePos;
	public float highScore;
	public float temp;

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
	private bool scoreDone = false;
	
	public GameObject box;

	public static int score, questions, correctAnswers = 0;

	public float totalscore, totalasked, totalcorrect = 0f;
	

	public GameObject correct, wrong;

	// Use this for initialization
	void Start () {
		ReadFile (Application.dataPath + "/StreamingAssets/Questions.txt");

		if(loaded)
		SetRound();
		score = 0;

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
		lblScore.text = "Score: " + score;
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
		questions++;
	}

	void Wrong(){
		Instantiate(wrong, transform.position, Quaternion.identity);
		score--;
		questions++;
	}

	void SaveData(){

		for(int i=0; i<5; i++){
			if((PlayerPrefs.GetFloat("highscorePos"+i) < score && (scoreDone == false))){
				temp = PlayerPrefs.GetFloat("highscorePos"+i);
				PlayerPrefs.SetFloat("highscorePos"+i, score);
				scoreDone = true;


				if(i<5){
					int j=i+1;
					PlayerPrefs.SetFloat("highscorePos"+j, temp);
					scoreDone = true;
				}
			}
		}

		PlayerPrefs.Save();
	}

	public void Done(){
		PlayerPrefs.Save();
		Application.LoadLevel(2);
	}

	void Reset(){
		SetRound();
	}
}
