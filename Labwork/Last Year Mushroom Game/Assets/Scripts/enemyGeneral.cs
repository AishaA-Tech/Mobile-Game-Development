using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemyGeneral : MonoBehaviour
{
    public int health; //Enemy health

    public bool is_attacking; //to be used in animation and other
    public bool is_damage;
    public bool is_dead;

    [SerializeField]
    private enemyData data; //Enemy Data uses

    [SerializeField]
    private Animator animator; //animation
    private GameObject current_enemy;

    //Enemy Attack
    private GameObject EnemyAttack = default;
    private float attack_time = 0.5f;
    private float timer = 0f;

    IEnumerator WaitForDeath() //Death anim wait
    {
        int moment_wait = 1;
        while (moment_wait == 1)
        {
            while (moment_wait != 0)
            {
                moment_wait = 0;
                yield return new WaitForSeconds(1.5f);
            }
        }
        Destroy(this.gameObject);
    }

    IEnumerator WaitForDamage() //Damage anim wait
    {
        int moment_wait = 1;
        while (moment_wait == 1)
        {
            while (moment_wait != 0)
            {
                moment_wait = 0;
                yield return new WaitForSeconds(1.0f);
            }
        }
        animator.SetBool("is_damage", is_damage);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = data.health;

        is_attacking = false;
        is_damage = false;
        is_dead = false;

        current_enemy = this.gameObject;

        EnemyAttack = transform.GetChild(0).gameObject; //child of enemy object
        EnemyAttack.SetActive(false);

    }


    void Attack() //Enemy attcking
    {
        if (is_attacking == true)
        {
            EnemyAttack.SetActive(is_attacking);
            animator.SetBool("is_attacking", is_attacking);
        }
        
    }

    void Die()
    {
        is_dead = true;
        animator.SetBool("is_dead", is_dead);
        StartCoroutine(WaitForDeath());
    }

    void Damage() //player takes damage
    {
        if (is_damage == true)
        {
            animator.SetBool("is_damage", is_damage); //set to false from player scripts
            is_damage = false;
            StartCoroutine(WaitForDamage());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ATTACK
        Attack();
        if (is_attacking) //if the player is attacking, a timer goes off
        {
            timer += Time.deltaTime;
            if (timer >= attack_time) //if timer over, player no longer attacking
            {
                timer = 0f;
                is_attacking = false;
                EnemyAttack.SetActive(is_attacking);
                animator.SetBool("is_attacking", is_attacking);
            }

        }

        //DYING
        if (health <= 0)
        {
            Die();
        }

        Damage();//check for damage

    }
}
