using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class CarChoiseScript : MonoBehaviour
{
    public bool[] carallow;
    public RewardAdsManager moneyinfo;
    [SerializeField] private GameObject[] cars;
    [SerializeField] private GameObject[] carprice;
    private int showingInex;
    [SerializeField] private GameObject choiseUI;
    [SerializeField] private Text buttonText;
    [SerializeField] private GameObject nomoney;
    [SerializeField] private GameObject buybt;
    private bool purchased1;
    private bool purchased2;
    private bool purchased3;
    private bool purchased4;

    private int purchasedint1 = 0;
    private int purchasedint2 = 0;
    private int purchasedint3 = 0;
    private int purchasedint4 = 0;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Awake()
    {
        if (YandexGame.savesData.carChoise >= 1)
        {
            cars[YandexGame.savesData.carChoise].SetActive(true);
            carallow[YandexGame.savesData.carChoise] = true;
            showingInex = YandexGame.savesData.carChoise;   
        }
        else
        {
            cars[0].SetActive(true);
            carallow[0] = true;
            showingInex = 0;
        }
    }


    void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();


        if (YandexGame.savesData.purchased1 > 0)
        {
            purchased1 = true;
        }
        else
        {
            purchased1 = false;
        }
        if (YandexGame.savesData.purchased2 > 0)
        {
            purchased2 = true;
        }
        else
        {
            purchased2 = false;
        }
        if (YandexGame.savesData.purchased3 > 0)
        {
            purchased3 = true;
        }
        else
        {
            purchased3 = false;
        }
        if (YandexGame.savesData.purchased4 > 0)
        {
            purchased4 = true;
        }
        else
        {
            purchased4 = false;
        }


        if (carallow[0] == true)
        {
            buttonText.text = "Выбрано";
        }
        else
        {
            buttonText.text = "Выбрать";
        }
    }

    public void OpenPanel()
    {
        choiseUI.SetActive(true);
        Animator choiseUIe = choiseUI.GetComponent<Animator>();
        choiseUIe.Play("choiseUION");
    }
    public void ClosePanel()
    {
        Animator choiseUIe = choiseUI.GetComponent<Animator>();
        choiseUIe.Play("choiseUIONOFF"); ;
    }
    public void NextCar()
    {
        if (cars[0].activeSelf)
        {
            cars[0].SetActive(false);
            cars[1].SetActive(true);
            showingInex = 1;
            carprice[1].SetActive(true);

            if (carallow[1] == true)
            {
                buttonText.text = "Выбрано";
                buybt.SetActive(false);
                carprice[1].SetActive(false);
            }
            else if(purchased1 ==true && carallow[1] == false)
            {
                buttonText.text = "Выбрать";
                buybt.SetActive(false);
                carprice[1].SetActive(false);
            }
            else 
            {
                buybt.SetActive(true);
            }
            nomoney.SetActive(false);
        }
        else if (cars[1].activeSelf)
        {
            cars[1].SetActive(false);
            cars[2].SetActive(true);
            showingInex = 2;
            carprice[1].SetActive(false);
            carprice[2].SetActive(true);

            if (carallow[2] == true)
            {
                buttonText.text = "Выбрано";
                buybt.SetActive(false);
                carprice[2].SetActive(false);

            }
            else if (purchased2 == true)
            {
                buttonText.text = "Выбрать";
                buybt.SetActive(false);
                carprice[2].SetActive(false);
            }
            else
            {
                 buybt.SetActive(true);
            }
            nomoney.SetActive(false);
        }
        else if (cars[2].activeSelf)
        {
            cars[2].SetActive(false);
            cars[3].SetActive(true);
            showingInex = 3;
            carprice[2].SetActive(false);
            carprice[3].SetActive(true);

            if (carallow[3] == true)
            {
                buttonText.text = "Выбрано";
                buybt.SetActive(false);
                carprice[3].SetActive(false);
            }
            else if (purchased3==true)
            {
                buttonText.text = "Выбрать";
                buybt.SetActive(false);
                carprice[3].SetActive(false);
            }
            else
            {
                buttonText.text = "Купить";
                buybt.SetActive(true);
            }
            nomoney.SetActive(false);
        }
        else if (cars[3].activeSelf)
        {
            cars[3].SetActive(false);
            cars[4].SetActive(true);
            showingInex = 4;
            carprice[3].SetActive(false);
            carprice[4].SetActive(true);

            if (carallow[4] == true)
            {
                buttonText.text = "Выбрано";
                buybt.SetActive(false);
                carprice[4].SetActive(false);

            }
            else if(purchased4==true)
            {
                buttonText.text = "Выбрать";
                buybt.SetActive(false);
                carprice[4].SetActive(false);

            }
            else
            {
                buttonText.text = "Купить";
                buybt.SetActive(true);

            }
            nomoney.SetActive(false);
        }
        else if (cars[4].activeSelf)
        {
            cars[4].SetActive(false);
            cars[0].SetActive(true);
            showingInex = 0;
            carprice[4].SetActive(false);

            if (carallow[0] == true)
            {
                buttonText.text = "Выбрано";
                buybt.SetActive(false);
            }
            else
            {
                buttonText.text = "Выбрать";
                buybt.SetActive(false);
            }
            nomoney.SetActive(false);
        }
    }
    public void BackCar()
    {
        if (cars[0].activeSelf)
        {
            cars[0].SetActive(false);
            cars[4].SetActive(true);
            showingInex = 4;
            carprice[4].SetActive(true);

            if (carallow[4] == true)
            {
                buttonText.text = "Выбрано";
                buybt.SetActive(false);
                carprice[4].SetActive(false);

            }
            else if (purchased4 == true)
            {
                buttonText.text = "Выбрать";
                buybt.SetActive(false);
                carprice[4].SetActive(false);

            }
            else
            {
                buttonText.text = "Купить";
                buybt.SetActive(true);

            }
            nomoney.SetActive(false);
        }
        else if (cars[4].activeSelf)
        {
            cars[4].SetActive(false);
            cars[3].SetActive(true);
            showingInex = 3;
            carprice[4].SetActive(false);
            carprice[3].SetActive(true);

            if (carallow[3] == true)
            {
                buttonText.text = "Выбрано";
                buybt.SetActive(false);
                carprice[3].SetActive(false);
            }
            else if (purchased3 == true)
            {
                buttonText.text = "Выбрать";
                buybt.SetActive(false);
                carprice[3].SetActive(false);
            }
            else
            {
                buttonText.text = "Купить";
                buybt.SetActive(true);
            }
            nomoney.SetActive(false);
        }
        else if (cars[3].activeSelf)
        {
            cars[3].SetActive(false);
            cars[2].SetActive(true);
            showingInex = 2;
            carprice[3].SetActive(false);
            carprice[2].SetActive(true);

            if (carallow[2] == true)
            {
                buttonText.text = "Выбрано";
                buybt.SetActive(false);
                carprice[2].SetActive(false);

            }
            else if (purchased2 == true)
            {
                buttonText.text = "Выбрать";
                buybt.SetActive(false);
                carprice[2].SetActive(false);
            }
            else
            {
                buybt.SetActive(true);
            }
            nomoney.SetActive(false);
        }
        else if (cars[2].activeSelf)
        {
            cars[2].SetActive(false);
            cars[1].SetActive(true);
            showingInex = 1;
            carprice[2].SetActive(false);
            carprice[1].SetActive(true);

            if (carallow[1] == true)
            {
                buttonText.text = "Выбрано";
                buybt.SetActive(false);
                carprice[1].SetActive(false);
            }
            else if (purchased1 == true && carallow[1] == false)
            {
                buttonText.text = "Выбрать";
                buybt.SetActive(false);
                carprice[1].SetActive(false);
            }
            else
            {
                buybt.SetActive(true);
            }
            nomoney.SetActive(false);
        }
        else if (cars[1].activeSelf)
        {
            cars[1].SetActive(false);
            cars[0].SetActive(true);
            showingInex = 0;
            carprice[1].SetActive(false);

            if (carallow[0] == true)
            {
                buttonText.text = "Выбрано";
                buybt.SetActive(false);
            }
            else
            {
                buttonText.text = "Выбрать";
                buybt.SetActive(false);
            }
            nomoney.SetActive(false);
        }
    }

    public void SelectCar()
    {
        if (cars[0].activeSelf)
        {
            carallow[1] = false;
            carallow[2] = false;
            carallow[3] = false;
            carallow[4] = false;
            carallow[0] = true;

            buttonText.text = "Выбрано";
            YandexGame.savesData.carChoise = showingInex;
            YandexGame.SaveProgress();
        }
        else if (cars[1].activeSelf)
        {
            if(purchased1 == true)
            {
                carallow[1] = true;
                carallow[2] = false;
                carallow[3] = false;
                carallow[4] = false;
                carallow[0] = false;

                buttonText.text = "Выбрано";
                YandexGame.savesData.carChoise = showingInex;
                YandexGame.SaveProgress();
            }
        }
        else if (cars[2].activeSelf)
        {
            carallow[1] = false;
            carallow[2] = true;
            carallow[3] = false;
            carallow[4] = false;
            carallow[0] = false;

            buttonText.text = "Выбрано";
            YandexGame.savesData.carChoise = showingInex;
            YandexGame.SaveProgress();
        }
        else if (cars[3].activeSelf)
        {
            carallow[1] = false;
            carallow[2] = false;
            carallow[3] = true;
            carallow[4] = false;
            carallow[0] = false;

            buttonText.text = "Выбрано";
            YandexGame.savesData.carChoise = showingInex;
            YandexGame.SaveProgress();
        }
        else if (cars[4].activeSelf)
        {
            carallow[1] = false;
            carallow[2] = false;
            carallow[3] = false;
            carallow[4] = true;
            carallow[0] = false;

            buttonText.text = "Выбрано";
            YandexGame.savesData.carChoise = showingInex;
            YandexGame.SaveProgress();
        }
        
    }

    public void BuyCar()
    {
        if(cars[1].activeSelf && moneyinfo.moneyCount >= 200 )
        {
            moneyinfo.moneyCount -= 200;
            moneyinfo.UpdateMoney();
            purchased1 = true;
            buybt.SetActive(false);
            buttonText.text = "Выбрать";
            nomoney.SetActive(false);
            purchasedint1 = 1;
            carprice[1].SetActive(false);
            YandexGame.savesData.purchased1 = purchasedint1;
            YandexGame.SaveProgress();
        }
        else if (cars[2].activeSelf && moneyinfo.moneyCount >= 600)
        {
            moneyinfo.moneyCount -= 600;
            moneyinfo.UpdateMoney();
            purchased2 = true;
            buybt.SetActive(false);
            buttonText.text = "Выбрать";
            nomoney.SetActive(false);
            purchasedint2 = 1;
            carprice[2].SetActive(false);
            YandexGame.savesData.purchased2 = purchasedint2;
            YandexGame.SaveProgress();
        }
        else if (cars[3].activeSelf && moneyinfo.moneyCount >= 800)
        {
            moneyinfo.moneyCount -= 800;
            moneyinfo.UpdateMoney();
            purchased3 = true;
            buybt.SetActive(false);
            buttonText.text = "Выбрать";
            nomoney.SetActive(false);
            purchasedint3 = 1;
            carprice[3].SetActive(false);
            YandexGame.savesData.purchased3 = purchasedint3;
            YandexGame.SaveProgress();
        }
        else if (cars[4].activeSelf && moneyinfo.moneyCount >= 1000)
        {
            moneyinfo.moneyCount -= 1000;
            moneyinfo.UpdateMoney();
            purchased4 = true;
            buybt.SetActive(false);
            buttonText.text = "Выбрать";
            nomoney.SetActive(false);
            purchasedint4 = 1;
            carprice[4].SetActive(false);
            YandexGame.savesData.purchased4 = purchasedint4;
            YandexGame.SaveProgress();
        }
        else
        {
            nomoney.SetActive(true);
        }

    }

    public void Save()
    {
        YandexGame.savesData.purchased1 = purchasedint1;
        YandexGame.savesData.purchased2 = purchasedint2;
        YandexGame.savesData.purchased3 = purchasedint3;
        YandexGame.savesData.purchased4 = purchasedint4;

        YandexGame.savesData.carChoise = showingInex;
        YandexGame.SaveProgress();
    }

    public void Load() => YandexGame.LoadProgress();

    public void GetLoad()
    {



        purchasedint1=YandexGame.savesData.purchased1;
        purchasedint2 = YandexGame.savesData.purchased2;
        purchasedint3 = YandexGame.savesData.purchased3;
        purchasedint4 = YandexGame.savesData.purchased4;
        showingInex = YandexGame.savesData.carChoise;
    }

}
