using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChoiser : MonoBehaviour
{
    [SerializeField] private GameObject levelChoiseUI;
    [SerializeField] private GameObject levelChoiseUIMOB;
    private Animator animator;
    private void Start()
    {
        if (Application.isMobilePlatform == true)
        {
            animator = levelChoiseUIMOB.GetComponent<Animator>();
        }
        else
        {
            animator = levelChoiseUI.GetComponent<Animator>();
        }
      
    }
    public void StartChoise()
    {
        if(Application.isMobilePlatform == true)
        {
            levelChoiseUIMOB.SetActive(true);
        }
        else
        {
            levelChoiseUI.SetActive(true);
        }
         
    }

    public void CloseChoise()
    {
 
            animator.Play("closeChoiselevel");
        
        
    }
}

