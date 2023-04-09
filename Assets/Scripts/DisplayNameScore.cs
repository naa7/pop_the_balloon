using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayNameScore : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        name = PersistentData.Instance.GetName();
        DisplayName();
        DisplayScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayName()
    {
        nameText.text = "Player:   " + name;
    }

    public void DisplayScore()
    {
        scoreText.text = "Score:    " + PersistentData.Instance.GetScore();
    }
}
