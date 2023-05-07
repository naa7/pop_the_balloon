using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score;
    const int DEFAULT_POINTS = 1000;
    [SerializeField] Text nameText;
    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;
    [SerializeField] int level;


    // Start is called before the first frame update
    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        score = PersistentData.Instance.GetScore();
        name = PersistentData.Instance.GetName();
        DisplayName();
        DisplayLevel();
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayName()
    {
        nameText.text = "Name: " + name;
    }

    public void DisplayScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void DisplayLevel()
    {
        levelText.text = "Level: " + level;
    }
    public void AdvanceLevel()
    {
        if (level == 1) {
            SceneManager.LoadScene("sceneTransition1");
        }
        else if (level == 2) {
            SceneManager.LoadScene("sceneTransition2");
        }
        else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void UpdateScore(int balloonSize)
    {

        score += DEFAULT_POINTS - Mathf.Abs(balloonSize);
        PersistentData.Instance.SetScore(score);
        DisplayScore();
        
    }

    public void UpdateScoreNegative(int penality)
    {

        score -=  penality;
        PersistentData.Instance.SetScore(score);
        DisplayScore();
        
    }

    public void UpdateScore()
    {
        UpdateScore(DEFAULT_POINTS);
    }

    public void ZeroScore()
    {
        score = 0;
    }

}

