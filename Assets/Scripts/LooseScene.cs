using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LooseScene : MonoBehaviour
{
    private int score;
    public Text scoreText;

    private void Start()
    {
        score = PlayerPrefs.GetInt("HiScore");
        scoreText.text = score.ToString();
    }

    public void ToMenu()
    {
        SceneManager.LoadScene(1);
    }
}
