using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerCard : MonoBehaviour
{
    [SerializeField] private Image towerImage;
    [SerializeField] private TMP_Text constText;

    private TowerData _towerData;

    public static event Action<TowerData> OnTowerSelected; 
    
    public void Initialize(TowerData data)
    {
        _towerData = data;
        towerImage.sprite = data.sprite;
        constText.text = data.cost.ToString();
    }

    public void PlaceTower()
    {
        OnTowerSelected?.Invoke(_towerData);
    }
}
