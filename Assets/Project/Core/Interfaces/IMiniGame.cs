public interface IMiniGame
{
    void StartMiniGame();
    void EndMiniGame(MiniGameResult result);
}

public class MiniGameResult
{
    public bool success;
    public int softCurrencyEarned;
    public int hardCurrencyEarned;
    public string message;
}
