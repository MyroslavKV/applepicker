using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timerText;

    [SerializeField] float gameTime = 30f;

    int score = 0;
    float currentTime;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentTime = gameTime;

        UpdateScoreUI();
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        timerText.text = "Time: " + Mathf.Ceil(currentTime);

        if (currentTime <= 0)
        {
            EndGame();
        }
    }

    public void AddPoint()
    {
        score++;

        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }

    void EndGame()
    {
        if (score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        SceneManager.LoadScene("Menu");
    }
}
