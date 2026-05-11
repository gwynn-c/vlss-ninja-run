
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isGameOver;
    public bool isGameStarted;
    
    public GameObject GameOverPanel;
    private GameObject _player;
    private void Awake()
    {
        Instance = this;    
        isGameOver = false;
        isGameStarted = false;
        _player = GameObject.FindGameObjectWithTag("Player");
        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        _player.SetActive(false);
    }
    
    public void StartGame()
    {
        isGameStarted = true;
        _player.SetActive(true);
    }
 
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
        EventManager.Instance.gameEvents.GameOver(true);
        isGameOver = true;
       
    }
}