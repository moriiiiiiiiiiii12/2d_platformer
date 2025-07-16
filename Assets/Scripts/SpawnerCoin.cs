using System.Collections;
using UnityEngine;
using UnityEngine.Lumin;

class SpawnerCoin : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform _pointSpawn;
    [SerializeField] private float _intervalSpawn;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds intervalSpawn = new WaitForSeconds(_intervalSpawn);

        while (true)
        {
            Instantiate(_coin);

            yield return intervalSpawn;
        }   
    }
}