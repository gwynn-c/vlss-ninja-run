using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int totalCoinCount;
    public float HighestScore;

    public PlayerData(Player player)
    {
        this.totalCoinCount = player.coinsCollected;
        this.HighestScore = player.highestScore;
        
    }
}

[System.Serializable]
public class Player
{
    public int coinsCollected;
    public int highestScore;

    public Player(int coinsCollected, int highestScore)
    {
        this.coinsCollected = coinsCollected;
        this.highestScore = highestScore;
    }
    
}