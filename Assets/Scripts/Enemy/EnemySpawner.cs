using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform player;
    public GameObject[] enemy;

    int x;
    int y;

    void Start()
    {
        StartCoroutine(EnemySpawn());
    }
    
    IEnumerator EnemySpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);

            if (Random.Range(0,2) == 1)
            {
                x = 1;
            }
            else
            {
                x = -1;
            }
                
            if (Random.Range(0, 2) == 1)
            {
                y = 1;
            }
            else
            {
                y = -1;
            }
                
            transform.position = player.position + new Vector3(x * 1.8f, y * 1.3f, 0);

            if (player.position.x + (x * 1.8f) < 11 && player.position.x + (x * 1.8f) > -11 &&
                player.position.y + (y * 1.3f) < 6 && player.position.y + (y * 1.3f) > -6)
            {
                Instantiate(enemy[Random.Range(0, enemy.Length)], transform.position, Quaternion.identity);
            }                
        }
    }
}
