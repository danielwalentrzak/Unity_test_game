using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{  // public string[] level;
    public GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.GetComponent<PlayerMovment>().maxfloor++;
            if (player.GetComponent<PlayerMovment>().floors == 2)
            {
                player.GetComponent<PlayerMovment>().floors = 0;
                SceneManager.LoadScene("map_002",LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene("generator", LoadSceneMode.Single);
                player.GetComponent<PlayerMovment>().floors++;
            }
        }
    }
}
