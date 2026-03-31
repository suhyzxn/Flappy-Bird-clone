using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public int score = -1;
    public static GameManager instance;
    [SerializeField] GameObject ScoreObj;
    [SerializeField] GameObject StartScreen;
    [SerializeField] GameObject GameOverPanel;
    [SerializeField] Rigidbody2D playerRigid;
    [SerializeField] TextMeshProUGUI EndScore;
    [SerializeField] TextMeshProUGUI HighScore;
    [SerializeField] GameObject levelupObj;
    [SerializeField] TextMeshProUGUI levelupText;
    int Int_HighScore;
    AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
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
        levelupObj.SetActive(false);
        audioSource.Play();
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

        if (score % 10 == 0 && score <= 50)
        {
            if (score == 50)
            {
                levelupText.color = new Color32(240, 0, 255, 255);
                levelupText.text = "Max Level!";
            }
                
            LevelUp();
            Invoke("LevelUp", 1f);
        }
    }

    void LevelUp()
    {
        levelupObj.SetActive(!levelupObj.activeSelf);
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
