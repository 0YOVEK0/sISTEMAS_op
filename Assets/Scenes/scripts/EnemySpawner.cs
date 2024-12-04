using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Settings")]
    public GameObject enemyPrefab; // Prefab del enemigo que se generará
    public int maxEnemies = 10;    // Máximo de enemigos activos a la vez

    [Header("Spawn Settings")]
    public float spawnInterval = 2f; // Tiempo entre spawns
    public Transform[] spawnPoints;  // Puntos específicos para el spawn
    public bool randomSpawn = true;  // ¿Spawnear en puntos aleatorios?

    private int currentEnemyCount = 0; // Número actual de enemigos en la escena

    void Start()
    {
        // Inicia el proceso de generación de enemigos
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        // Verifica si no hemos alcanzado el máximo de enemigos
        if (currentEnemyCount >= maxEnemies) return;

        // Selecciona un punto de spawn aleatorio si está habilitado
        Transform spawnPoint = randomSpawn 
            ? spawnPoints[Random.Range(0, spawnPoints.Length)] 
            : spawnPoints[0];

        // Instancia el enemigo en el punto seleccionado
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Incrementa el conteo de enemigos actuales
        currentEnemyCount++;
    }

    // Método para reducir el contador de enemigos
    public void EnemyDestroyed()
    {
        currentEnemyCount--;
    }
}
