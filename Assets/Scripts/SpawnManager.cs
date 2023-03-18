using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{


    [SerializeField] private int _spawnCount = 0;
    [SerializeField] private int _maxSpawnCount = 5;
    [SerializeField] private GameObject _fishPrefab;
    [SerializeField] private bool _canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
     if (_fishPrefab == null)
        {
            Debug.LogError("Fish Prefab NULL");
        }

      StartCoroutine(SpawnFishRoutine());

    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

  IEnumerator SpawnFishRoutine()
    { 
      while (true)
      {
           yield return new WaitForSeconds(3.0f);
           if (_spawnCount < _maxSpawnCount)
           {
             Instantiate(_fishPrefab, new Vector3(Random.Range(-10f, -8f), 1.05f, Random.Range(-10f, -8f)), Quaternion.AngleAxis(90f, Vector3.left));
                _spawnCount += 1;
           }

      }
        
    }

    public void FishCollected()
    {
        _spawnCount -= 1;
    }

    public void ChangeSpawnState()
    {
        _canSpawn = !_canSpawn;
    }

}
