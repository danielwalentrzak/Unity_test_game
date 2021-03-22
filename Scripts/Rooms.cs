using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rooms : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] closed;
    public List<GameObject> rooms;
    public GameObject exit;
    private bool spawn;
    private float wait=2.0f;




    private void Update()
    {
        if (wait <= 0)
        {
            if(spawn == false)
            {
                Instantiate(exit, rooms[rooms.Count - 1].transform.position, Quaternion.identity);
                spawn = true;
            }

        }
        else
        {
            wait-=Time.deltaTime;
        }
    }








}
