using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    private WeaponSwitching switcher;
    [SerializeField] private int pistolAmmoAmount= 10;
    [SerializeField] private int shellAmmoAmount = 0;
    [SerializeField] private int rifleAmmoAmount = 0;

    public int PistolAmmoAmount { get => pistolAmmoAmount; set => pistolAmmoAmount = value; }
    public int ShellAmmoAmount { get => shellAmmoAmount; set => shellAmmoAmount = value; }
    public int RifleAmmoAmount { get => rifleAmmoAmount; set => rifleAmmoAmount = value; }

    private void Start()
    {
        switcher = GetComponent<WeaponSwitching>();
    }

    private void Update()
    {
        switch (switcher.CurrentlyEquipedGun.Ammo1)
        {
            case ammoType.pistol:
                uiManager.AmmoAmountText.text = "Ammo: " + pistolAmmoAmount.ToString();
                break;
            case ammoType.shells:
                uiManager.AmmoAmountText.text = "Ammo: " + shellAmmoAmount.ToString();
                break;
            case ammoType.rifle:
                uiManager.AmmoAmountText.text = "Ammo: " + rifleAmmoAmount.ToString();
                break;
            default:
                break;
        }
    }

    public void BuyPistolAmmo(int amountOfAmmo)
    {
        int ammoCost = 10;
        if (EconomyManager.Money > ammoCost)
        {
            EconomyManager.Money -= ammoCost;
            pistolAmmoAmount += amountOfAmmo;
        }
    }
    public void BuyShotgunAmmo(int amountOfAmmo)
    {
        int ammoCost = 20;
        if (EconomyManager.Money > ammoCost)
        {
            EconomyManager.Money -= ammoCost;
            shellAmmoAmount += amountOfAmmo;
        }
    }
    public void BuyRifleAmmo(int amountOfAmmo)
    {
        int ammoCost = 250;
        if (EconomyManager.Money > ammoCost)
        {
            EconomyManager.Money -= ammoCost;
            rifleAmmoAmount += amountOfAmmo;
        }
    }
}
