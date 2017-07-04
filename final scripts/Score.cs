using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    static int highscore;
    public static int score;
    Text scoreText;

    
    public Text highscoreText;

    void Awake()
    {
        scoreText = GetComponent<Text>();
        highscore = PlayerPrefs.GetInt("highscore");
    }

    void Update()
    {
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("highscore", highscore);
            highscoreText.text = "Highscore: " + highscore;
        }
        scoreText.text = " " + score;
        highscoreText.text = " " + highscore;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            score++;
        }
    }
    
}