using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Posion_Potion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int recover = Random.Range(1, 6);
            if (collision.GetComponent<PlayerMovment>().hp < collision.GetComponent<PlayerMovment>().maxhp)
                collision.GetComponent<PlayerMovment>().hp -= recover * 5;
            Destroy(gameObject);
        }
    }
}
