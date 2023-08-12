using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppsCollider : MonoBehaviour
{
    public GameObject unitybt5;
    public GameObject appsmobile;
    private void Update()
    {
        if (unitybt5.activeSelf == true)
        {
            if (Input.GetKeyDown("return"))
            {
                Application.OpenURL("http://team500.top/5");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Application.isMobilePlatform == true)
            {
                appsmobile.SetActive(true);
            }
            else
            {
                unitybt5.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Application.isMobilePlatform == true)
        {
            appsmobile.SetActive(false);
        }
        else
        {
            unitybt5.gameObject.SetActive(false);
        }
    }
}
