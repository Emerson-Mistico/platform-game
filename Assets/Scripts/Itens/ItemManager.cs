using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    [Header("Itens Collectable Setup")]
    public SOInt itemCrystal;
    public SOInt itemEnergy;

    [Header("Player Item Init Setup")]
    public int initialCrystals = 0;
    public int initialEnergy = 100;

    private void Start()
    {
        ResetItens();
    }

    private void ResetItens()
    {
        itemCrystal.value = initialCrystals;
        itemEnergy.value = initialEnergy;
    }

    public void AddItemCrystal(int amountCrystal) {

        itemCrystal.value += amountCrystal;
    }

    public void AddItemEnergy(int amountEnergy)
    {

        itemEnergy.value += amountEnergy;
    }

    public void RemoveItemEnergy(int amountEnergy)
    {

        itemEnergy.value -= amountEnergy;
    }

}
