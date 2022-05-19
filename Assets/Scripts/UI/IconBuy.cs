using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IconBuy : MonoBehaviour
{
    public int TotalPrice => _totalPrice;
    public PoliceMan PoliceMan => _policeMan;
    [SerializeField] private Money _money;
    private Shop _shop;
    private Image _image;
    private Button _buyButton;
    private PoliceMan _policeMan;
    private TMP_Text _priceText;
    private SquadCell _squadCell;
    private int _totalPrice;

    private void Awake()
    {
        _shop = GetComponentInParent<Shop>();
        _image = GetComponent<Image>();
        _buyButton = GetComponentInChildren<Button>();
        _priceText = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _shop.ChangeMan += ShowIcon;
        EnableBuyButton();
    }

    private void OnDisable()
    {
        _shop.ChangeMan -= ShowIcon;
    }

    private void ShowIcon(PoliceMan policeMan)
    {
        _policeMan = policeMan;
        _totalPrice = SetEndPrice();
        _image.sprite = _policeMan.Icon;
        _priceText.text = _totalPrice.ToString() + "$";
        _priceText.color = SetColor();
        EnableBuyButton();
    }

    private void EnableBuyButton()
    {
        if (_policeMan != null && _money.MoneyCount >= _totalPrice)
            _buyButton.gameObject.SetActive(true);
        else
            _buyButton.gameObject.SetActive(false);
    }

    private int SetEndPrice()
    {
        if (_squadCell.PoliceMan != null)
            return _policeMan.Price - _squadCell.PoliceMan.Price;
        else
            return _policeMan.Price;
    }

    private Color SetColor()
    {
        Color color = new Color();
        if (_totalPrice <= _money.MoneyCount)
            color = Color.green;
        else
            color = Color.red;
        return color;
    }

    public void AppointBuyCell(SquadCell squadCell)
    {
        _squadCell = squadCell;
    }

    public void BuySoldier()
    {
        _squadCell.AssignCharacter(PoliceMan);
    }
}
