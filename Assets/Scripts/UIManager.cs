using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _fishText;
    [SerializeField] private TextMeshProUGUI _coinsText;

    // Start is called before the first frame update
    void Start()
    {

        if (_fishText == null)
        {
            Debug.LogError("FishText NULL");
        }

        if (_coinsText == null)
        {
            Debug.LogError("CoinsText NULL");
        }

    }

    public void AddFishCount(int fishCount, int maxFishStorage)
    {
        _fishText.text = "Fish : " + fishCount.ToString() + '/' + maxFishStorage.ToString();

    }

    public void AddCoins(int coinCount)
    {
        _coinsText.text = "Coins : " + coinCount.ToString();
    }

    


}
