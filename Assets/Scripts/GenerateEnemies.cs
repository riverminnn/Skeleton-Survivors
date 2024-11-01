using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    private float y = 7.8f, z = 1074.7f;
    private float x;
    [SerializeField] int enemyCount;
    
    void Start()
    {
        enemyCount = 0;
        StartCoroutine(DropEnemy());
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    IEnumerator DropEnemy()
    {
        while (enemyCount < 1000)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 3.5f));
            x = Random.Range(989.72f, 1215.5f);
            Instantiate(Enemy, new Vector3(x, y, z), Quaternion.identity);
            enemyCount++;
        }   
    }
}
