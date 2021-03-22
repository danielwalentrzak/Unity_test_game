using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    private Vector2 target;
    [SerializeField]private float mvs;
    private float angle;
    public float dmg;
 
    // Start is called before the first frame update
    void Start()
    {
       
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
    
        angle = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg;
       transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); 
     }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, mvs * Time.deltaTime);
      
     
        if((Vector2)transform.position==target)
        {
            gameObject.GetComponent<Animator>().SetBool("vanish", true);
            Destroy(gameObject.GetComponent<CircleCollider2D>());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {

            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().Takedmg(dmg);
            Destroy(gameObject.GetComponent<CircleCollider2D>());
            gameObject.GetComponent<Animator>().SetBool("hit", true);
           


        }
    }
    private void Destroyer() {
        Destroy(gameObject);
    }
}
