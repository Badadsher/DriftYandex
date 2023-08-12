using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordViewer : MonoBehaviour
{
    [SerializeField] private Text recordViewer;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("record"))
        {
            recordViewer.text = "У вас нет рекорда";
        }
        else
        {
            recordViewer.text = PlayerPrefs.GetInt("record").ToString();
        }
    }
}
