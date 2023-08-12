using UnityEngine;
using UnityEngine.UI;
using YG;

public class RewardAdsManager : MonoBehaviour
{
    [SerializeField] int AdID;
    [SerializeField] Text textMoney;

    public int moneyCount = 0;

    
    void Start()
    {
        if(PlayerPrefs.HasKey("Money"))
        {
            textMoney.text = "" + PlayerPrefs.GetInt("Money");
        }
        else
        {
            AdMoney(0);
        }
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
        PlayerPrefs.SetInt("Money", moneyCount);
        PlayerPrefs.Save();
    }
}