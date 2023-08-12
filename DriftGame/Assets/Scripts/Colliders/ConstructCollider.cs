using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConstructCollider : MonoBehaviour
{
    public GameObject unitybt3;
    public GameObject constructmobile;
    private void Update()
    {
        if (unitybt3.activeSelf == true)
        {
            if (Input.GetKeyDown("return"))
            {
                SceneManager.LoadScene(2);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Application.isMobilePlatform == true)
            {
               constructmobile.SetActive(true);
            }
            else
            {
                unitybt3.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Application.isMobilePlatform == true)
        {
            constructmobile.SetActive(false);
        }
        else
        {
            unitybt3.gameObject.SetActive(false);
        }
    }
}
