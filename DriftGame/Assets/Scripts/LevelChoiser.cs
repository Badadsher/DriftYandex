using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChoiser : MonoBehaviour
{
    [SerializeField] private GameObject levelChoiseUI;
    private Animator animator;
    private void Start()
    {
        animator = levelChoiseUI.GetComponent<Animator>();
    }
    public void StartChoise()
    {
        levelChoiseUI.SetActive(true);     
    }

    public void CloseChoise()
    {
        animator.Play("closeChoiselevel");
    }
}

