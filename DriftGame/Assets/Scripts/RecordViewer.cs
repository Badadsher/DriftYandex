using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class RecordViewer : MonoBehaviour
{
    [SerializeField] private Text recordViewer;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();


        if (Convert.ToInt32(recordViewer.text) == 0)
        {
            recordViewer.text = "У вас нет рекорда";
        }
        else
        {
            recordViewer.text = YandexGame.savesData.record.ToString();
        }
    }

    public void Load() => YandexGame.LoadProgress();

    public void GetLoad()
    {
        recordViewer.text = YandexGame.savesData.record.ToString();
    }
}
