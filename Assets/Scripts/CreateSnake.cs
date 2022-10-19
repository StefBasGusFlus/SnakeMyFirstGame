using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreateSnake : CreateGoal
{
    int index;
    private Vector3 positionV;
    private List<Transform> segments;
    public Transform segmentPrefab;

    private string vect;

    private int score;
    public Text scoreText;

    public Text hiScoreText;
    private int hiScore;

    private int levelUp = 5;
    public Text levelUpText;
    private int lev = 0;

    public AudioSource eat;
    public AudioSource levelUpMusic;

    void Start()
    {
        Time.timeScale = 1f;
        segments = new List<Transform>();
        segments.Add(this.transform);

        index = Random.Range(0, Occupancy._dublicate.GetLength(0) * Occupancy._dublicate.GetLength(1));
        this.transform.position = new Vector2(Occupancy._arrayPos[0, index], Occupancy._arrayPos[1, index]);

        hiScore = PlayerPrefs.GetInt("HiScore");
    }
    
    public void OnButtonDown()
    {
        if(vect != "Up")
        { 
            positionV = new Vector3(0, -0.34f);
            vect = "Down";
        }
        
    }

    public void OnButtonUp()
    {
        if(vect != "Down")
        {
            positionV = new Vector3(0, 0.34f);
            vect = "Up";
        }
        
    }

    public void OnButtonLeft()
    {
        if(vect != "Right")
        {
            positionV = new Vector3(-0.34f, 0);
            vect = "Left";
        }
        
    }

    public void OnButtonRight()
    {
        if(vect != "Left")
        {
            positionV = new Vector3(0.34f, 0);
            vect = "Right";
        }
        
    }

    private void Grow()
    {
        segmentPrefab.position = segments[segments.Count - 1].position;
        Transform sigment = Instantiate(segmentPrefab);
        
        segments.Add(sigment);

        if (segments.Count > levelUp)
        {
            levelUp += 5;
            lev++;
            Time.timeScale += 0.1f;
            levelUpMusic.Play();
        }
        else
            eat.Play();
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        hiScoreText.text = hiScore.ToString();
        levelUpText.text = lev.ToString();
    }

    private void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
        this.transform.Translate(positionV);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            Grow();
            score++;
        }
        else if (collision.tag == "Finish")
        {
            if (hiScore < score)
            {
                hiScore = score;
                PlayerPrefs.SetInt("HiScore", hiScore);
                // запись данных в реестр под именем "HiScore" для использования в другой сцене
                SceneManager.LoadScene(2);
            }
            else
                SceneManager.LoadScene(3);
        }
    }
}
