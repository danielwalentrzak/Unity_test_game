using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWalls : MonoBehaviour
{
    float delay = 0.5f;
    void Start()
    {
        StartCoroutine(WaitAndDestroy());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            
            Destroy(collision.gameObject);

        }

    }
    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
