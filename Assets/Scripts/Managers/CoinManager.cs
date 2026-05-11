using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance { get; private set; }
    
    private int _coinCount;
    public TextMeshProUGUI coinText;

    private int _totalCoins;
    public TextMeshProUGUI totalCoinText;
    
    private void OnEnable()
    {
        EventManager.Instance.gameEvents.OnGameOver += SetCoinCount;
        EventManager.Instance.gameEvents.OnCoinCollected += IncreaseCoinCount;

    }

    private void OnDisable()
    {
        EventManager.Instance.gameEvents.OnGameOver -= SetCoinCount;
        EventManager.Instance.gameEvents.OnCoinCollected -= IncreaseCoinCount;

    }
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        _totalCoins = PlayerPrefs.GetInt("CoinCount");
        totalCoinText.SetText(_totalCoins.ToString());
    }

    private void Update()
    {
        coinText.SetText(_coinCount.ToString());
    }

    private void IncreaseCoinCount()
    {
        _coinCount++;
    }
    private void SetCoinCount()
    {
        PlayerPrefs.SetInt("CoinCount", PlayerPrefs.GetInt("CoinCount") + _coinCount);
        PlayerPrefs.Save();
    }
}
