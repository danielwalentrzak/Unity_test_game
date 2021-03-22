using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovment.singleton.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
