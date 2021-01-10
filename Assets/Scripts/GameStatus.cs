using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] TMP_Text scoreText;

    [Header("Debug")]
    [SerializeField] int currentScore = 0;
    [SerializeField] bool isAutoPlayOn;

    // Singleton to keep game status in all level
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        //Invoke in Brique.cs
        GameEvent.addScore.AddListener(addToScore);
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }

    // addToScore : count and add score to text
    public void addToScore(int gain)
    {
        currentScore += gain;
        scoreText.text = currentScore.ToString();
    }

    // ResetGame : for replay game -> reset score
    public void ResetGame()
    {
        Destroy(gameObject);
    }

    // IsAutoPlayOn : verify bool autoplay
    public bool IsAutoPlayOn()
    {
        return isAutoPlayOn;
    }
}
