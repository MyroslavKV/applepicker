using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] GameObject applePrefab;
    [SerializeField] Terrain terrain;

    [SerializeField] int maxApples = 10;

    [SerializeField] float spawnDelay = 2f;

    int currentApples;

    void Start()
    {
        InvokeRepeating(nameof(SpawnApple), 0f, spawnDelay);
    }

    void SpawnApple()
    {
        if (currentApples >= maxApples)
            return;

        Vector3 terrainPosition = terrain.transform.position;

        float randomX = Random.Range(
            terrainPosition.x,
            terrainPosition.x + terrain.terrainData.size.x
        );

        float randomZ = Random.Range(
            terrainPosition.z,
            terrainPosition.z + terrain.terrainData.size.z
        );

        Vector3 spawnPosition = new Vector3(
            randomX,
            -194f,
            randomZ
        );

        Instantiate(applePrefab, spawnPosition, Quaternion.identity);

        currentApples++;
    }

    public void AppleDestroyed()
    {
        currentApples--;
    }
}
