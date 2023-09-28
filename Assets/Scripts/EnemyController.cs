using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Spawn range from (0,2)
    [SerializeField] private int heightRange = 2;
    [SerializeField] private int widthRange = 7;
    
    [SerializeField] private float spawnDelay = 2f;
    
    [SerializeField] private int maxEnemyCount = 10;
    private int _enemyCount = 0;
    
    [SerializeField] private GameObject enemy;
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void SpawnEnemy()
    {
        // Spawn Enemy at random coords
        var position = new Vector2(Random.Range(-widthRange, widthRange),
            Random.Range(-heightRange + 2, heightRange + 2));
        Instantiate(enemy, position, Quaternion.identity);
        _enemyCount++;
        
        // TODO Give enemy random speed in random direction
    }

    private IEnumerator SpawnEnemies()
    {
        while (maxEnemyCount < 0 || _enemyCount < maxEnemyCount)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

}
