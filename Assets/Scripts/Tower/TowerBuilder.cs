using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _levelCount;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform spawnPlatform;
    [SerializeField] private Platform[] platforms;
    [SerializeField] private FinishPlatform finishPlatform;

    private float aditionalScale = 3;

    private float beamScaleY; 
    private void Awake()
    {
        beamScaleY = _levelCount / 1.5f + 0.5f + aditionalScale / 1.5f;
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, beamScaleY, 1);
        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - aditionalScale;

        SpawnPlatform(spawnPlatform, ref spawnPosition, beam.transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(platforms[Random.Range(0, platforms.Length)], ref spawnPosition, beam.transform);
        }

        SpawnPlatform(finishPlatform, ref spawnPosition, beam.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -=1.5f;
    }
}
