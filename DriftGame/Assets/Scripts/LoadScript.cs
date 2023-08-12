using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScript : MonoBehaviour
{
    [SerializeField] private GameObject startlevelUI;
    public void StartBT()
    {
        startlevelUI.SetActive(true);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
