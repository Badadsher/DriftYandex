using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeCollider : MonoBehaviour
{
    public GameObject unitybt4;
    public GameObject threemobile;
    private void Update()
    {
        if (unitybt4.activeSelf == true)
        {
            if (Input.GetKeyDown("return"))
            {
                Application.OpenURL("http://team500.top/4");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Application.isMobilePlatform == true)
            {
                threemobile.SetActive(true);
            }
            else
            {
                unitybt4.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Application.isMobilePlatform == true)
        {
            threemobile.SetActive(false);
        }
        else
        {
            unitybt4.gameObject.SetActive(false);
        }
    }
}
