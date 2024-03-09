using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonsManager : MonoBehaviour
{
    #region Buttons Setup
    [Header("Buttons Setup")]
    public List<GameObject> listButtons;
    public float durationScale = .02f;
    public float delay = .05f;
    public Ease ease = Ease.OutBack;
    #endregion

    public void OnEnable()
    {
        HideButtons();
        ShowButtonsDelay();
    }

    #region On/Off Area
    public void HideButtons()
    {
        foreach (var button in listButtons)
        {
            button.transform.localScale = Vector3.zero;
            button.SetActive(false);
        }
    }

    private void ShowButtonsDelay()
    {
        for (int i = 0; i < listButtons.Count; i++)
        {
            var button = listButtons[i];
            button.SetActive(true);
            button.transform.DOScale(1, durationScale).SetDelay(i * delay).SetEase(ease);
        }
    }
    #endregion
}
