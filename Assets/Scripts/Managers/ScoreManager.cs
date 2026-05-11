using System.Globalization;
using TMPro;
using UnityEngine;

namespace Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public float Score { get; private set; }

        private float _scoreMultiplier = 100f;
        [SerializeField] private TextMeshProUGUI scoreText;
        
        [SerializeField] private TextMeshProUGUI highScoreText;
        [SerializeField] private TextMeshProUGUI gameOverScoreText;

        private void OnEnable()
        {
            EventManager.Instance.gameEvents.OnGameOver += SaveScore;
            EventManager.Instance.gameEvents.OnCoinCollected += IncreaseScoreMultiplier;

        }
    
    
        private void OnDisable()
        {
            EventManager.Instance.gameEvents.OnGameOver -= SaveScore;
            EventManager.Instance.gameEvents.OnCoinCollected -= IncreaseScoreMultiplier;
        }

        
        private void Update()
        {
            if (GameManager.Instance.isGameOver)
                return;

            if (GameManager.Instance.isGameStarted)
            {
                
                Score += Time.deltaTime * _scoreMultiplier;
            
                scoreText.SetText(Mathf.Floor(Score).ToString());
            }
        }
    
    
        private void IncreaseScoreMultiplier()  
        {
            _scoreMultiplier += 120f;
        }

        private void SaveScore()
        {
            gameOverScoreText.SetText("Current Score: "+ Mathf.Floor(Score));
            if (PlayerPrefs.HasKey("HighScore"))
            {
                if (Score > PlayerPrefs.GetFloat("HighScore"))
                {
                    PlayerPrefs.SetFloat("HighScore", Mathf.Floor(Score));
                    PlayerPrefs.Save();
                }    
                highScoreText.SetText("High Score: " + PlayerPrefs.GetFloat("HighScore"));
            }
            else
            {
                PlayerPrefs.GetFloat("HighScore");
                highScoreText.SetText("High Score: " + Mathf.Floor(Score));

                PlayerPrefs.Save();
            }
        }
    }
}