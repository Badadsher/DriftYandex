using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetBt : MonoBehaviour
{
    [SerializeField] private GameObject loadermenuUI;
    private int level;
    private void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(level);
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
