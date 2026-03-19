using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    int score = -1;
    public static GameManager instance;
    [SerializeField] GameObject ScoreObj;
    [SerializeField] GameObject StartScreen;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] Rigidbody2D playerRigid;
    [SerializeField] TextMeshProUGUI EndScore;
    [SerializeField] TextMeshProUGUI HighScore;
    int Int_HighScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 0;
    }

    void Update()
    {
        if (score == -1 && Input.GetMouseButtonDown(0))
        {
            GameStart();
        }
    }

    public void Die()
    {
        playerRigid.bodyType = RigidbodyType2D.Kinematic;
        Invoke("GameOver", 1f);
    }

    void GameOver()
    {
        Time.timeScale = 0;
        EndScore.text = "Score : " + score.ToString();
        GetScore();
        SaveScore();
        HighScore.text = "High Score : " + Int_HighScore.ToString();
        GameOverPanel.SetActive(true);
    }

    public void ScoreUp()
    {
        score++;
        ScoreText.text = score.ToString();
    }

    public void GameStart()
    {
        score = 0;
        ScoreObj.SetActive(true);
        StartScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReStart()
    {
        SceneManager.LoadScene("Game");
    }

    void SaveScore()
    {
        if (Int_HighScore < score)
        {
            Int_HighScore = score;
        }
        PlayerPrefs.SetInt("HighScore", Int_HighScore);
        PlayerPrefs.Save();
    }

    void GetScore()
    {
        Int_HighScore = PlayerPrefs.GetInt("HighScore");
    }
}
