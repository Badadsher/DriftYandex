using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class RecordViewer : MonoBehaviour
{
    [SerializeField] private Text recordViewer;

    private void Start()
    {
        if(YandexGame.savesData.record == 0)
        {
            recordViewer.text = "У вас нет рекорда";
        }
        else
        {
            recordViewer.text = YandexGame.savesData.record.ToString();
        }
    }
}
