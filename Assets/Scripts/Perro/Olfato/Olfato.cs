using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Olfato : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void IniciarOler()
    {
        if (anim != null)
        {
            anim.SetBool("Caminando", false);
            anim.SetTrigger("Oler");
        }
    }

    public void TerminarOler()
    {
        if (anim != null)
            anim.SetBool("Caminando", true);
    }
}
