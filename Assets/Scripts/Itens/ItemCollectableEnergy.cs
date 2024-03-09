using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableEnergy : ItemCollectableBase
{
    protected override void OnCollected()
    {
        base.OnCollected();
        ItemManager.Instance.AddItemEnergy(itemValue);
    }
}
