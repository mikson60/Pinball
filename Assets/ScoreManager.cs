using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager Instance;

    [SerializeField] GameObject ballPrefab;

    [SerializeField] TextMesh m_textMeshP1;
    [SerializeField] TextMesh m_textMeshP2;

    int m_scoreP1;
    int m_scoreP2;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }
    }

    void Start()
    {
        ResetScore();
    }

    void ResetScore()
    {
        m_scoreP1 = 0;
        m_scoreP2 = 0;
        UpdateScoreTextP1(m_scoreP1);
        UpdateScoreTextP2(m_scoreP2);
    }

    public void AddScoreP1()
    {
        m_scoreP1++;
        UpdateScoreTextP1(m_scoreP1);
        CheckScore(m_scoreP1);
    }
    public void AddScoreP2()
    {
        m_scoreP2++;
        UpdateScoreTextP2(m_scoreP2);
        CheckScore(m_scoreP2);
    }

    void UpdateScoreTextP1(int newScore)
    {
        m_textMeshP1.text = newScore.ToString();
    }
    void UpdateScoreTextP2(int newScore)
    {
        m_textMeshP2.text = newScore.ToString();
    }

    void CheckScore(int score)
    {
        if (score % 10 == 0)
        {
            SpawnBall();
        }
    }

    void SpawnBall()
    {
        Ball ball = Instantiate(ballPrefab).GetComponent<Ball>();
        if (ball != null)
        {
            ball.ResetBall();
        }
    }
}
