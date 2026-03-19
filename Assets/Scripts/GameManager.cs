using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    int score = -1;
    public static GameManager instance;
    [SerializeField] GameObject ScoreObj;
    [SerializeField] GameObject StartScreen;

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
        Invoke("GameOver", 2f);
    }

    void GameOver()
    {
        Time.timeScale = 0;
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
}
