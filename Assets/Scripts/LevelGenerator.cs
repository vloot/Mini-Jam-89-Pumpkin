using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Platform[] platforms;
    private List<Platform> spawnedPlatforms;
    public List<Platform> GetPlatforms => spawnedPlatforms;

    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform generationParent;


    public int numOfPlatforms = 10;
    public float positionsOffset = 5;

    private void Awake()
    {
        spawnedPlatforms = new List<Platform>();
        float offsetY = 0;

        for (int i = 0; i < numOfPlatforms; i++)
        {
            var platformToSpawn = platforms[Random.Range(0, platforms.Length)];
            var pos = startPoint.position;
            pos.y -= offsetY;
            var platform = Instantiate(platformToSpawn, pos, Quaternion.identity, generationParent);
            platform.gameObject.name = i.ToString();
            offsetY += positionsOffset;

            spawnedPlatforms.Add(platform);
        }
    }
}
