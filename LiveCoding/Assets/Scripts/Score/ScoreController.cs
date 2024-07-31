using Coins;
using Zenject;

public class ScoreController
{
    private int Score = 0;
    private readonly ScoreText _scoreText;

    [Inject]
    public ScoreController(ScoreText scoreText)
    {
        _scoreText = scoreText;
    }
    
    public void OnCoinCollectedSignalReceived(CoinCollectedSignal signal)
    {
       Score++;
       _scoreText.SetScore(Score);
    }
}