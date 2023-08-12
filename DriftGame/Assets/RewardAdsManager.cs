using UnityEngine;
using UnityEngine.UI;
using YG;

public class RewardAdsManager : MonoBehaviour
{
    [SerializeField] int AdID;
    [SerializeField] public Text textMoney;

    public int moneyCount;

    public void Load() => YandexGame.LoadProgress();

    void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad(); 
    }
    private void OnEnable() => YandexGame.CloseVideoEvent += Rewarded;
    private void OnDisable() => YandexGame.CloseVideoEvent -= Rewarded;

    void Rewarded(int id)
    {
        if (id == AdID)
            AdMoney(100);
    }

    void AdMoney(int count)
    {

        moneyCount += count;
        textMoney.text = "" + moneyCount;
        UpdateMoney();
    }

    public void UpdateMoney()
    {
        textMoney.text = "" + moneyCount;
        YandexGame.savesData.money = moneyCount;
        YandexGame.SaveProgress();
    }

    public void GetLoad()
    {
        moneyCount = YandexGame.savesData.money;
        textMoney.text = YandexGame.savesData.money.ToString();
    }
}