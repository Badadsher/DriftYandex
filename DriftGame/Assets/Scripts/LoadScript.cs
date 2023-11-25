using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour
{
    [SerializeField] private GameObject startlevelUI;
    [SerializeField] private int index;
    public void StartBT()
    {
        startlevelUI.SetActive(true);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(index);
    }
}
