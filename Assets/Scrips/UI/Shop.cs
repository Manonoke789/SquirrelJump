using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Button _closeShopButton;
    [SerializeField] private Button _buyButton;

    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _noManeuPanel;
    [SerializeField] private GameObject _confirmationPanel;
    [SerializeField] private GameObject _cointForButton;
    [SerializeField] private GameObject _haveThisPanel;

    [SerializeField] private TMP_Text _gold;
    [SerializeField] private TMP_Text _needForBuyGold;

    private int needForBuyGold;

    private SaveData saveData;

    private void Awake()
    {
        saveData = SavesService.Instance.Load<SaveData>();
    }
    private void Start()
    {
        _gold.text = saveData.Gold.ToString();
        needForBuyGold = Convert.ToInt32(_needForBuyGold.text);
        if (saveData.JumpCount > 1)
        {
            _cointForButton.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _closeShopButton.onClick.AddListener(CloseShopButtonDown);
        _buyButton.onClick.AddListener(BuyButtonDown);
    }

    private void OnDisable()
    {
        _closeShopButton.onClick?.RemoveListener(CloseShopButtonDown);
        _buyButton.onClick.RemoveListener(BuyButtonDown);
    }
    private void CloseShopButtonDown()
    {
        _shop.SetActive(false);
    }
    private void BuyButtonDown()
    {
        if(saveData.Gold < needForBuyGold && saveData.JumpCount == 1)
        {
            _noManeuPanel.SetActive(true);
        }
        if(saveData.Gold >= needForBuyGold && saveData.JumpCount == 1)
        {
            _confirmationPanel.SetActive(true);
        }
        if(saveData.JumpCount == 2)
        {
            _haveThisPanel.SetActive(true);
        }
    }

    public void Buy()
    {
        saveData.Gold -= needForBuyGold;
        saveData.JumpCount = 2;
        SavesService.Instance.Save(saveData);

        _cointForButton.SetActive(false);
        _gold.text = saveData.Gold.ToString();
        _confirmationPanel.SetActive(false);
    }
}
