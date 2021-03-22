using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player_attack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public Transform attackPoint2;
    public Transform attackPoint3;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public int dmg;
    public GameObject hiteffect;
    public GameObject firePoint;
    public bool hasabilility;
    public GameObject fireBall;
    public int ability = 60;
    public bool hasautoaim;
    public float cooldown=0;
    public float cooldownmax;
    // Update is called once per frame
    private void Start()
    {
        hasautoaim = false;
        hasabilility = false;
        cooldownmax = 3;
        dmg = 40;
        ability = 30;
    }
    void Update()
    {
        if (gameObject.GetComponent<PlayerMovment>().alive == true)
        {
            if (cooldown > 0)
            {
               
                cooldown -= Time.deltaTime;
            }
            if (hasabilility == true && Input.GetKeyDown(KeyCode.C) && cooldown <= 0)
            {
                cooldown = cooldownmax;
                Cast();
            }
            if (Input.GetKeyDown(KeyCode.Space) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Player_attack"))
            {
                animator.SetTrigger("Attack");
            }
        }
    }
    public void Attack()
    {
      
        List<Collider2D> hitEnemies = new List<Collider2D>();
        hitEnemies.AddRange(Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer));
        hitEnemies.AddRange(Physics2D.OverlapCircleAll(attackPoint2.position, attackRange, enemyLayer));
        hitEnemies.AddRange(Physics2D.OverlapCircleAll(attackPoint3.position, attackRange, enemyLayer));
        hitEnemies = hitEnemies.Distinct().ToList();
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<IEnemy>() != null)
            {
                Instantiate(hiteffect, enemy.GetComponent<Transform>().position, Quaternion.identity);
                enemy.GetComponent<IEnemy>().TakeDamage(dmg);
            }
        }
    }

 private void Cast()
    {
        Instantiate(fireBall, firePoint.GetComponent<Transform>().position, Quaternion.identity);
      
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange);
        Gizmos.DrawWireSphere(attackPoint3.position, attackRange);
    }
}
