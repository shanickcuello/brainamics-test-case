using Coins;
using UnityEngine;

public class ScoreManager
{
    public int Score = 0;

    public void OnCoinCollectedSignalReceived(CoinCollectedSignal signal)
    {
        Score++;
        Debug.Log($"Score {Score}");
    }
}