using UnityEngine;
using UnityEngine.Events;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance { get; private set; }

    public UnityEvent OnCurrencyChanged = new UnityEvent();

    public int SoftCurrency => SaveManager.Instance.CurrentSave.softCurrency;
    public int HardCurrency => SaveManager.Instance.CurrentSave.hardCurrency;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddSoftCurrency(int amount)
    {
        SaveManager.Instance.CurrentSave.softCurrency += amount;
        SaveManager.Instance.Save();
        OnCurrencyChanged.Invoke();
    }

    public void AddHardCurrency(int amount)
    {
        SaveManager.Instance.CurrentSave.hardCurrency += amount;
        SaveManager.Instance.Save();
        OnCurrencyChanged.Invoke();
    }

    public bool TrySpendSoftCurrency(int amount)
    {
        if (SaveManager.Instance.CurrentSave.softCurrency < amount)
            return false;

        SaveManager.Instance.CurrentSave.softCurrency -= amount;
        SaveManager.Instance.Save();
        OnCurrencyChanged.Invoke();
        return true;
    }
}
