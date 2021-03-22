using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Red : MonoBehaviour
{
    [SerializeField] private Slime_Ai attak;
    // Start is called before the first frame update
void Doit()
    {
        attak.Att();
    }
}
