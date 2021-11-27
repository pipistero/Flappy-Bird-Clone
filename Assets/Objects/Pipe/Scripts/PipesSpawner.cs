using System.Collections;
using UnityEngine;

public class PipesSpawner : ObjectsPool
{
    [Space]
    [Header("Prefab")]
    [SerializeField] private GameObject _template;

    [Space]
    [Header("Spawner parameters")]
    [SerializeField] private float _timeBetweenSpawn;

    [Space]
    [Header("Spawned object parameters")]
    [SerializeField] private float _xOffset;
    [SerializeField] private float _minValueY;
    [SerializeField] private float _maxValueY;

    private void Start()
    {
        Init(_template);

        StartCoroutine(SpawnPipe());
    }

    private IEnumerator SpawnPipe()
    {
        yield return new WaitForSeconds(_timeBetweenSpawn);

        if (TryGetObject(out GameObject pipe))
        {
            pipe.SetActive(true);
            pipe.transform.position = new Vector3(transform.position.x + _xOffset, Random.Range(_minValueY, _maxValueY), 0);
        }

        DisableInvisibleObjects();
        StartCoroutine(SpawnPipe());
    }
}
