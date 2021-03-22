using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redirection : MonoBehaviour
{
    
    [SerializeField] private Player_attack attak;
    [SerializeField] private PlayerMovment mov;
    public void Doit()
    {
        attak.Attack();
    }
    public void Die()
    {
        mov.Smierc();
    }
}
