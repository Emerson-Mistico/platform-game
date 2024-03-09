using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class UIInGameManager : Singleton<UIInGameManager>
{
    public TextMeshProUGUI uiTextCrystals;
    public TextMeshProUGUI uiTextEnergy;

    public static void UpDateTextCrystals(string amountCristals)
    {
        Instance.uiTextCrystals.text = amountCristals;
    }

    public static void UpDateTextEnergy(string amountEnergy)
    {
        Instance.uiTextEnergy.text = amountEnergy;
    }
}
