using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnpointController: MonoBehaviour
{
    [SerializeField] private Transform _spawnpointsParent;
    [SerializeField] private GameObject _prefabForSpawning;
    [SerializeField] private float _nextSpawnPause;

    private EnemySpawnpoint[] _spawnpoints;
    private Coroutine _spawnpointActivatorInJob;
    private bool _isControllerWorking;

    private void Start()
    {
        _spawnpoints = new EnemySpawnpoint[_spawnpointsParent.childCount];

        for (int i = 0; i < _spawnpointsParent.childCount; i++)
            _spawnpoints[i] = _spawnpointsParent.GetChild(i).gameObject.GetComponent<EnemySpawnpoint>();
    }

    private void Update()
    {
        if (!_isControllerWorking)
            StartSpawning();
    }

    private void StartSpawning()
    {
        if (_spawnpointActivatorInJob != null)
            StopCoroutine(_spawnpointActivatorInJob);

        _isControllerWorking = true;
        _spawnpointActivatorInJob = StartCoroutine(SpawnpointActivator());
    }

    private IEnumerator SpawnpointActivator()
    {
        while (_isControllerWorking)
        {
            foreach (var spawnpoint in _spawnpoints)
            {
                yield return new WaitForSeconds(_nextSpawnPause);

                spawnpoint.Spawn(_prefabForSpawning);
            }
        }
    }
}
