using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetBt : MonoBehaviour
{
    [SerializeField] private GameObject loadermenuUI;
    public void ResetScene()
    {
        SceneManager.LoadScene(1);
    }

    public void StartMenuON()
    {
        loadermenuUI.SetActive(true);
    }

    public void MenuON()
    {
        SceneManager.LoadScene(0);
    }
}
