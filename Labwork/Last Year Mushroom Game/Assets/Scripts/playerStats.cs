using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class playerStats : MonoBehaviour
{
    public int health;
    public int score;

    public bool is_dead;
    public bool is_damage;

    private Rigidbody2D player_rb;

    [SerializeField]
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = 100;
        score = 0;
        is_dead = false;
        is_damage = false;

        player_rb = GetComponent<Rigidbody2D>(); //Getting player's rigidbody2D
    }

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

    void Death() //player dying
    {
        is_dead = true;
        Destroy(player_rb); //disabling player movement and physics
        animator.SetBool("is_dead", is_dead);
        StartCoroutine(WaitForDeath());
        SceneManager.LoadScene("gameOverScreen");
    }

    void Damage() //player taking damage
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
        Damage(); //check for damage

        if (health <= 0  //no health means dead
            || transform.position.y < -9.5f ) // falling in gap means death
        {
            Death();
        }

        scoreMaintain.totalScore = score;
    }
}
