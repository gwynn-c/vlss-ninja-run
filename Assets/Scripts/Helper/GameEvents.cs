using System;
using UnityEngine;

public class GameEvents
{
    public Action OnGameOver;
    public Action OnCoinCollected;

    public void CoinCollected()
    {
        OnCoinCollected?.Invoke();
    }
    
    
    public void GameOver(bool isGameOver)
    {
        OnGameOver?.Invoke();
    }
}