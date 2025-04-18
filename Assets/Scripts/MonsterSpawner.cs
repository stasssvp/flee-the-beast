using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monster_reference;

    private GameObject spawned_monster;

    [SerializeField]
    private Transform left_position, right_position;

    private int random_index;
    private int random_side;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true) // Creates multiple monsters
        {
            yield return new WaitForSeconds(Random.Range(1, 5)); // Iterate through this (random) many seconds 

            random_index = Random.Range(0, monster_reference.Length);
            random_side = Random.Range(0, 2);

            spawned_monster = Instantiate(monster_reference[random_index]);

            // The left side
            if (random_side == 0)
            {
                spawned_monster.transform.position = left_position.position;
                spawned_monster.GetComponent<Monster>().speed = Random.Range(4, 10); // Goes from left to right
            }
            // The right side
            else
            {
                spawned_monster.transform.position = right_position.position;
                spawned_monster.GetComponent<Monster>().speed = -Random.Range(4, 10); // Goes from right to left
                spawned_monster.transform.localScale = new Vector3(-1f, 1f, 1f); // Flips the monster
            }
        }
    }
}