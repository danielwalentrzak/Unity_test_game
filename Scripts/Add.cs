using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Add : MonoBehaviour
{
    private Rooms temp;
    void Start()
    {
        temp = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Rooms>();
        temp.rooms.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
