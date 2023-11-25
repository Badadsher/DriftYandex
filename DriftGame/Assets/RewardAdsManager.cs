using UnityEngine;
using UnityEngine.UI;

using YG;

public class RewardAdsManager : MonoBehaviour
{
    [SerializeField] int AdID;
    [SerializeField] public Text textMoney;
    [SerializeField] private Button adButton;

    public int moneyCount;

    public void Load() => YandexGame.LoadProgress();

    void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();

        adButton.onClick.AddListener(delegate { clickReward(0); });
    }
    private void OnEnable() {
        YandexGame.RewardVideoEvent += Rewarded;    
    }
   
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

    void clickReward(int id)
    {
        YandexGame.RewVideoShow(id);
    }

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

        if(YandexGame.savesData.money != null || YandexGame.savesData.money != 0)
        {
            textMoney.text = YandexGame.savesData.money.ToString();
        }
        else
        {

            textMoney.text = "0";
        }
    }
}