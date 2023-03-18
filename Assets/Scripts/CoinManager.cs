using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    [SerializeField] private int _coins = 0;
    [SerializeField] private FishingMechanism _fishingMechanism;
    [SerializeField] private UIManager _UIManager;
    [SerializeField] private bool _canSell =false;
    [SerializeField] private bool _isSelling=false;


    // Start is called before the first frame update
    void Start()
    {

        if ( _fishingMechanism == null )
        {
            Debug.LogError("FishingMechanism NULL");
        }

       

        if ( _UIManager == null )
        {
            Debug.LogError("UIManager NULL");
        }

        StartCoroutine(FishSellRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "shop" )
        {
            _isSelling = true;    
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "shop")
        {
            _isSelling = false;
        }
    }

    IEnumerator FishSellRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            if (_canSell && _isSelling == true)
            {

                _coins += 2;
                _fishingMechanism.SellFish();
                _UIManager.AddCoins(_coins);
            }
        }
    }

    public void ChangeCanSell(bool canSell)
    { 
        _canSell = canSell; 
    }
}
