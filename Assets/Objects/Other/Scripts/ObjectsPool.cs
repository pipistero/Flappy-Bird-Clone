using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{
    [Space]
    [Header("Pool parameters")]
    [SerializeField] private Transform _container;
    [SerializeField] private int _capacity;

    private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    private void Awake()
    {
        _camera = Camera.main;
    }

    protected void Init(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            var spawnedObject = Instantiate(prefab, _container);
            spawnedObject.SetActive(false);

            _pool.Add(spawnedObject);
        }
    }

    protected bool TryGetObject(out GameObject item)
    {
        item = _pool.FirstOrDefault(p => p.activeSelf == false);

        return item != null;
    }

    protected void DisableInvisibleObjects()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(-0.5f, 0f));

        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
                if (item.transform.position.x < disablePoint.x)
                    item.SetActive(false);
        }
    }

    public void Reset()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
