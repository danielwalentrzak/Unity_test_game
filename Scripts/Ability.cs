using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    private Vector2 player;
    private GameObject[] targets;
    [SerializeField] private float mvs;
    public int dmg;
    [SerializeField] private float lifetime;
    private bool turned=false;
    private bool autoaim;
    private GameObject target;
    float dist;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
        target = null;
        float dist = 8f;
        autoaim = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().hasautoaim;   
       targets = GameObject.FindGameObjectsWithTag("Enemy");
       dmg = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_attack>().ability;
       player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        Physics2D.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        if (gameObject.transform.position.x < player.x)
        {
            turned = true;
            Vector3 x = transform.localScale;
            x.x *= -1;
            transform.localScale = x;
        }
   
        if (autoaim)
        {
            foreach (GameObject e in targets)
            {
                if (e.GetComponent<IEnemy>()!=null) {
                    float temp = Vector2.Distance(e.GetComponent<Transform>().position, player);
                    if (temp < dist)
                    {
                        dist = temp;
                        target = e;
                    }
                }
            }
            if (target != null && dist <= 7)
            {
               if (gameObject.transform.position.x < player.x)
                {
                    turned = true;
                    Vector3 x = transform.localScale;
                    x.x *= -1;
                    transform.localScale = x;
                }
                angle = Mathf.Atan2(target.GetComponent<Transform>().position.y - transform.position.y, target.GetComponent<Transform>().position.x - transform.position.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            }
        }  
        Destroy(gameObject, lifetime); 
    }

    // Update is called once per frame
   void Update()
    {
        StartCoroutine(Life());
        if (lifetime <= 0)
        {
            gameObject.GetComponent<Animator>().SetBool("hit", true);
        }
        if (autoaim)
        {
            Debug.Log("here");
            if (target == null || dist > 9)
            {
                Normalcast();
            }
            else if (target != null && dist<=9)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.GetComponent<Transform>().position,mvs*Time.deltaTime);
            }
        }
        else
        Normalcast();
    }
    private void Normalcast()
    {
        if (turned == true)
        {

            transform.Translate(-mvs * Time.deltaTime, 0, 0);
        }

        if (turned == false)
        {
            transform.Translate(mvs * Time.deltaTime, 0, 0);
        }
    }
    IEnumerator Life()
    {
        lifetime -= Time.deltaTime;
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IEnemy>() != null)
        {
           collision.GetComponent<IEnemy>().TakeDamage(dmg);
        }
        gameObject.GetComponent<Animator>().SetBool("hit", true);
    }
    private void Destroyer()
    {
        Destroy(gameObject);
    }

}

