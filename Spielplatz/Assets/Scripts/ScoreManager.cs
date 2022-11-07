using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    public PointManager pointmanager;

    private int highscore = 0;
    private int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "SampleScene")
        pointmanager.score = 0;       
        /*score = pointmanager.score;
        highscore = pointmanager.highscore;
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();*/
    }
    private void Update()
    {
        score = pointmanager.score;
        highscore = pointmanager.highscore;
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }
}
