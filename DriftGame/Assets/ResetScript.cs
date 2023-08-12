using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class ResetScript : MonoBehaviour
{
    public void ClickReset()
    {
        YandexGame.ResetSaveProgress();
    }
}
