using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public bool spawned = false;
    private Rooms temp;
    public int direction;
    void Start()
    {
        temp = GameObject.FindGameObjectWithTag("Rooms").GetComponent<Rooms>();
        Invoke("Spawn", 0.1f);
        StartCoroutine(WaitAndDestroy());
    }
    void Spawn()
    {
        if (spawned == false)
        {
            if (direction == 1)
            {
                Instantiate(temp.bottomRooms[Random.Range(0, temp.bottomRooms.Length)], transform.position, Quaternion.identity);
            }
            else if (direction == 2)
            {
                Instantiate(temp.rightRooms[Random.Range(0, temp.rightRooms.Length)], transform.position, Quaternion.identity);
            }
            else if (direction == 3)
            {
                Instantiate(temp.topRooms[Random.Range(0, temp.topRooms.Length)], transform.position, Quaternion.identity);
            }
            else if (direction == 4)
            {
                Instantiate(temp.leftRooms[Random.Range(0, temp.leftRooms.Length)], transform.position, Quaternion.identity);
            }
            spawned = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnPoint"))
        {
            if(collision.GetComponent<RoomSpawner>().spawned==false && spawned == false)
            {
                Instantiate(temp.closed[0], transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
        
    }
    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(gameObject);
    }
}
