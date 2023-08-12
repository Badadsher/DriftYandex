using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnrealCollider : MonoBehaviour
{
    public GameObject unitybt2;
    public GameObject unrealmobile;
    private void Update()
    {
        if (unitybt2.activeSelf == true)
        {
            if (Input.GetKeyDown("return"))
            {
                Application.OpenURL("http://team500.top/2");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Application.isMobilePlatform == true)
            {
                unrealmobile.SetActive(true);
            }
            else
            {
                unitybt2.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Application.isMobilePlatform == true)
        {
            unrealmobile.SetActive(false);
        }
        else
        {
            unitybt2.gameObject.SetActive(false);
        }
    }
}
