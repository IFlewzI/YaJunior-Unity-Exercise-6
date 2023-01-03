using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemySpawnpoint : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Spawn(GameObject enemyPrefab)
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        _audioSource.Play();
    }
}
