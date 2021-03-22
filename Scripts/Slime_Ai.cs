using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Ai : MonoBehaviour, IEnemy
{
    public Transform target;
    [SerializeField] private float range;
    [SerializeField] private float mv;
    private bool right = true;
    public Transform attackpoint;
    [SerializeField] private float attackRange = 0.88f;
    public int currenthp;
    private int maxhp = 100;
    private bool stop = false;
    public GameObject[] drops;
    [SerializeField] private float dmg;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currenthp = maxhp;
        dmg = 10f;
        LevelUp();
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= range && stop == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, mv * Time.deltaTime);
            if (target.position.x > transform.position.x)
            {
                if (right == false)
                {
                    right = true;
                     Vector3 x = transform.localScale;
                    x.x *= -1;
                    transform.localScale = x;
                }
            }
            if (target.position.x < transform.position.x)
            {
                if (right == true)
                {
                    right = false;
                    Vector3 x = transform.localScale;
                    x.x *= -1;
                    transform.localScale = x;
                }
            }
        }
        if ((Vector2.Distance(attackpoint.position, target.position) <= attackRange))
        {
            gameObject.GetComponentInChildren<Animator>().SetBool("Att", true);
            stop = true;
        }
        if ((Vector2.Distance(attackpoint.position, target.position) > attackRange))
        {
            gameObject.GetComponentInChildren<Animator>().SetBool("Att", false);
            stop = false;
        }

        if (Vector2.Distance(transform.position, target.position) > range)
        {
        }
    }
    public void Att()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackpoint.position, attackRange);
        foreach (Collider2D player in hits)
        {
            if (player != null && player.CompareTag("Player"))
                player.GetComponent<PlayerMovment>().Takedmg(dmg);
        }
    }
    private void OnDrawGizmos()
    {  Gizmos.DrawWireSphere(attackpoint.position, attackRange);    }

    public void TakeDamage(int damage)
    { currenthp -= damage;
        if (currenthp <= 0)
        {   stop = true;
            Kill();
        }
    }
    public void Kill()
    {    int chance = Random.Range(1, 101);
        if (chance > 45)
            Drop(drops[Random.Range(0, drops.Length)]);
        gameObject.GetComponentInChildren<Animator>().Play("slime_death");
        Destroy(transform.gameObject, gameObject.GetComponentInChildren<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }
     public void LevelUp()
    {    int f = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().maxfloor;
        if (f % 2 == 0)
        {   int a = f / 2;
            maxhp += 20*a;
            currenthp = maxhp;        }
            dmg += 7 * f;    }
    public void Drop(GameObject drop)
    {        Instantiate(drop, gameObject.transform.position, Quaternion.identity);    }
}
