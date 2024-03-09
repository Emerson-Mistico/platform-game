using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCrystal : ItemCollectableBase
{
    protected override void OnCollected()
    {
        base.OnCollected();
        ItemManager.Instance.AddItemCrystal(itemValue);
    }
}
