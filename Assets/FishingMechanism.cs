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
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "fish")
        {
            _collectedFish++;
            _fishText.text = "Fish : " + _collectedFish.ToString();
            Destroy(other.gameObject, 0.0f);
            _spawnManager.FishCollected();

        }
    }

}
