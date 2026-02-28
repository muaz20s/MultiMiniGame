using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DummyMiniGameController : MonoBehaviour, IMiniGame
{
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TMP_Text resultMessageText;

    private void Start()
    {
        StartMiniGame();
    }

    public void StartMiniGame()
    {
        gamePanel.SetActive(true);
        resultPanel.SetActive(false);
    }

    public void EndMiniGame(MiniGameResult result)
    {
        if (result.softCurrencyEarned > 0)
            EconomyManager.Instance.AddSoftCurrency(result.softCurrencyEarned);

        if (result.hardCurrencyEarned > 0)
            EconomyManager.Instance.AddHardCurrency(result.hardCurrencyEarned);

        GameEvents.OnMiniGameCompleted?.Invoke(result);

        gamePanel.SetActive(false);
        resultPanel.SetActive(true);
        resultMessageText.text = "+" + result.softCurrencyEarned + " Soft Currency!";
    }

    public void OnAwardButtonClicked()
    {
        MiniGameResult result = new MiniGameResult
        {
            success = true,
            softCurrencyEarned = 10,
            hardCurrencyEarned = 0,
            message = "+10 Soft Currency!"
        };

        EndMiniGame(result);
    }

    public void OnReturnToHub()
    {
        SceneManager.LoadScene("Hub");
    }
}
