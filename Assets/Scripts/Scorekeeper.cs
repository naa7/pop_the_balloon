using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField] int score = 0;
    const int DEFAULT_POINTS = 1000;
    [SerializeField] Text scoreText;
    [SerializeField] Text levelText;
    [SerializeField] int levelNum;


    // Start is called before the first frame update
    void Start()
    {
        levelNum = SceneManager.GetActiveScene().buildIndex;
        //score = PersistentData.Instance.GetScore();
        DisplayLevel();
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayScore()
    {
        scoreText.text = "Score: " + PersistentData.Instance.GetScore();
    }

    public void DisplayLevel()
    {
        levelText.text = "Level: " + (levelNum);
    }
    public void AdvanceLevel()
    {
        levelNum += levelNum + 1;
    }
    public void UpdateScore(int balloonSize)
    {

        score += DEFAULT_POINTS - (balloonSize);
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

