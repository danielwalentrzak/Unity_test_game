using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Potion : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int recover = Random.Range(1, 5);
            if(collision.GetComponent<PlayerMovment>().hp < collision.GetComponent<PlayerMovment>().maxhp)
            collision.GetComponent<PlayerMovment>().hp += recover*10;
            Destroy(gameObject);
        }
    }
}
