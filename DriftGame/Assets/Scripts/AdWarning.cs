using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdWarning : MonoBehaviour
{
    [SerializeField] private GameObject warningAD;
    [SerializeField] private GameObject choisepanel;

    public void TakeMoney()
    {
        warningAD.SetActive(true);
        Animator anim = choisepanel.GetComponent<Animator>();
        anim.Play("warningadOPEN");
    }

    public void NoMoney()
    {
        Animator anim = choisepanel.GetComponent<Animator>();
        anim.Play("closeWarning");
    }

}
