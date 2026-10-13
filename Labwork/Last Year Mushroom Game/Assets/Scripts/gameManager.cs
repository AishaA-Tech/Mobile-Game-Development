using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    private Scene current_scene; //current scene
    private string scene_name; // name of scene

    [SerializeField]
    private int enemy_number;
    private bool is_dead;

    [SerializeField]
    private int enemy_count;

    public GameObject enemy;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        is_dead = false;
        current_scene = SceneManager.GetActiveScene();
        scene_name = current_scene.name;
        is_dead = enemy.GetComponent<enemyGeneral>().is_dead;


        // finding which level
        if (scene_name == "levelOne")
        {
            enemy_number = 10;
        }
        else if (scene_name == "levelTwo")
        {
            enemy_number = 6;
        }
        else if (scene_name == "levelThree")
        {
            enemy_number = 4;
        }


    }


    IEnumerator NextLevel() //Death anim wait
    {
        enemy_count = 0;

        while (enemy_count < enemy_number)
        {
            if (is_dead)
            {
                enemy_count++;
            }
            yield return null;


        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next scene in que

    }
}
