using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HubUIController : MonoBehaviour
{
    [SerializeField] private TMP_Text softCurrencyText;
    [SerializeField] private TMP_Text hardCurrencyText;

    private void OnEnable()
    {
        EconomyManager.Instance.OnCurrencyChanged.AddListener(RefreshUI);
        RefreshUI();
    }

    private void OnDisable()
    {
        if (EconomyManager.Instance != null)
            EconomyManager.Instance.OnCurrencyChanged.RemoveListener(RefreshUI);
    }

    private void RefreshUI()
    {
        softCurrencyText.text = "Soft: " + EconomyManager.Instance.SoftCurrency;
        hardCurrencyText.text = "Hard: " + EconomyManager.Instance.HardCurrency;
    }

    public void OnPlayDummyMiniGame()
    {
        SceneManager.LoadScene("DummyMiniGame");
    }

    public void OnResetSave()
    {
        SaveManager.Instance.ResetSave();
        RefreshUI();
    }
}
