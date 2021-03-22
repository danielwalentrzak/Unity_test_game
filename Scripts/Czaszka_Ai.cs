using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Czaszka_Ai : MonoBehaviour, IEnemy
{
    public int maxhp = 100;
    public int currenthp;
    public Transform wayp1, wayp2;
    private Transform waypt;
    [SerializeField] private float mvs;
    [SerializeField] private float distancdetec;
    private Transform player;
    public GameObject projectile;
    public Transform firepoint;
    private bool turned = false;
    public GameObject[] drops;
    private float cooldown=0, cooldownmax;
    public float dmg;
    void Start()
    {
    cooldownmax = 2;
    currenthp = maxhp;
        dmg = 10f;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        waypt = wayp1;
        LevelUp();
    }
    void Update()
    {
        cooldown -= Time.deltaTime;
        if (Vector2.Distance(transform.position, player.transform.position) >= distancdetec)
        {
            if (turned == true)
            {
                turned = false;
                Vector3 x = transform.localScale;
                x.x *= -1;
                transform.localScale = x;
            }
            Patrol();
        }
        else
        {
            if (cooldown <= 0)
            {
                cooldown = cooldownmax;
                gameObject.GetComponent<Animator>().SetTrigger("IsAtt");
            }
        }
    }
    private void Patrol()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypt.position, mvs * Time.deltaTime);
        if (Vector2.Distance(transform.position, waypt.position) <= 0.0f)
        {
            if (waypt == wayp1)
            {
                waypt = wayp2;
                Vector3 x = transform.localScale;
                x.x *= -1;
                transform.localScale = x;
            }
            else
            {
                waypt = wayp1;
                Vector3 x = transform.localScale;
                x.x *= -1;
                transform.localScale = x;
            }
        }
    }
    private void Attack()
    {
        if (firepoint.position.x < transform.position.x && player.position.x > transform.position.x)
        {
            if (turned == false) turned = true;
            else turned = false;
            Vector3 x = transform.localScale;
            x.x *= -1;
            transform.localScale = x;
        }
        if (firepoint.position.x > transform.position.x && player.position.x < transform.position.x)
        {
            if (turned == false) turned = true;
            else turned = false;
            Vector3 x = transform.localScale;
            x.x *= -1;
            transform.localScale = x;
        }
        GameObject go= Instantiate(projectile, firepoint.position, Quaternion.identity);
        go.GetComponent<Projectiles>().dmg = dmg;
        gameObject.GetComponent<Animator>().SetTrigger("Stop");
    }
    public void TakeDamage(int damage)
    {
        currenthp -= damage;
        if (currenthp <= 0)
        {
            Kill();
        }
    }
    public void Kill()
    {
       int chance = Random.Range(1, 101);
        gameObject.GetComponent<Animator>().Play("Czaszka_death");
        if (chance > 65)
        Drop(drops[Random.Range(0,drops.Length)]);
        Destroy(transform.parent.gameObject, gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
    }

    public void LevelUp()
    {
        int f = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovment>().maxfloor;
        if (f % 2 == 0)
        {
            int a = f / 2;
            maxhp += 20*a;
            currenthp = maxhp;
            if(cooldown>0)
            cooldownmax -= 0.5f;
         }
        dmg += 5 * f;
    }

    public void Drop(GameObject drop)
    {
        Instantiate(drop, gameObject.transform.position, Quaternion.identity);
    }
}
