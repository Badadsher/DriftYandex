using UnityEngine;
using UnityEngine.UI;
using YG;

public class RewardAdsManager : MonoBehaviour
{
    [SerializeField] int AdID;
    [SerializeField] public Text textMoney;

    public int moneyCount;


    public void Load() => YandexGame.LoadProgress();

    private void Update()
    {
      
        moneyCount = YandexGame.savesData.money;
        textMoney.text = moneyCount.ToString();
    }

    void Start()
    {
      
        if (YandexGame.SDKEnabled)
        {
            GetLoad();
        }

        else
        {
            Debug.Log("error");
        }

       
    }
    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;
    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;

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
        Debug.Log("countdone");
       

        if( YandexGame.savesData.money != 0)
        {
            textMoney.text = YandexGame.savesData.money.ToString();
        }
        else
        {

            textMoney.text = "0";
        }
    }
}