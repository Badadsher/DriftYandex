using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCollider : MonoBehaviour
{
    public GameObject unitybt1;
    public GameObject unitybtmobile;
    private void Update()
    {
        if (unitybt1.activeSelf == true)
        {
            if (Input.GetKeyDown("return"))
            {
                Application.OpenURL("http://team500.top/1");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Application.isMobilePlatform == true)
            {
                unitybtmobile.SetActive(true);
            }
            else 
            {
             unitybt1.gameObject.SetActive(true);
            }          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (Application.isMobilePlatform == true)
        {
            unitybtmobile.SetActive(false);
        }
        else
        {
            unitybt1.gameObject.SetActive(false);
        }
    }
}
