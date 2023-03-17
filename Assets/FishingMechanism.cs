using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishingMechanism : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _fishText;
    [SerializeField] private int _collectedFish=0;
    [SerializeField] private SpawnManager _spawnManager;
    [SerializeField] private int _maxFishStorage = 5;
    [SerializeField] private bool _isFishing;
    [SerializeField] private bool _isFishStorageFull = false;

    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (_spawnManager == null )
        {
            Debug.LogError("SpawnManager NULL");
        }

        if (_fishText == null)
        {
            Debug.LogError("Fish Text UI NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_collectedFish < _maxFishStorage)
        {
            _isFishStorageFull=false;
        }
        else
        {
            _isFishStorageFull=true;
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (_isFishStorageFull == false)
        {
            if (other.tag == "fish")
            {
                _collectedFish++;
                _fishText.text = "Fish : " + _collectedFish.ToString() + '/' + _maxFishStorage.ToString();
                Destroy(other.gameObject, 0.0f);
                _spawnManager.FishCollected();

            }
        }
    }

}
