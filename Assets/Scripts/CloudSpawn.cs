using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    [Header("Cloud Prefab")]
    public GameObject cloudPrefab;

    [Header("Spawn Settings")]
    public int cloudCount = 5;
    public Vector2 yRange = new Vector2(2f, 6f);
    public Vector2 speedRange = new Vector2(0.2f, 0.8f);
    public Vector2 xRange = new Vector2(-10f, 10f);

    void Start()
    {
        SpawnClouds();
    }

    void SpawnClouds()
    {
        for (int i = 0; i < cloudCount; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(xRange.x, xRange.y),
                Random.Range(yRange.x, yRange.y),
                transform.position.z
            );

            GameObject cloud = Instantiate(cloudPrefab, pos, Quaternion.identity, transform);

            CloudMove move = cloud.GetComponent<CloudMove>();
            if (move != null)
            {
                move.speed = Random.Range(speedRange.x, speedRange.y);
            }
        }
    }
}