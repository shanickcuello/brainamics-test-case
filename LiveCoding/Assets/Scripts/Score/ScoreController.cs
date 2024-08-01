using Coins;
using Score;
using Zenject;

public class ScoreController
{
    private int _score = 0;
    private readonly ScoreText _scoreText;

    [Inject]
    public ScoreController(ScoreText scoreText)
    {
        _scoreText = scoreText;
    }
    
    public void OnCoinCollectedSignalReceived(CoinCollectedSignal signal)
    {
       _score++;
       _scoreText.SetScore(_score);
    }
}