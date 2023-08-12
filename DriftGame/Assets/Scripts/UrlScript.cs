using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UrlScript : MonoBehaviour
{
    [SerializeField] private string telegram;
    [SerializeField] private string vk;
    public void TelegramOpen()
    {
        Application.OpenURL(telegram);
    }
    public void VkOpen()
    {
        Application.OpenURL(vk);
    }
}
