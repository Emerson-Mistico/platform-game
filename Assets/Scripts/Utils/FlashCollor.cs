using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

public class FlashCollor : MonoBehaviour
{
    #region Setup
    [Header("Flash Setup")]
    public List<SpriteRenderer> spriteRenderers;
    public Color colorToFlash = Color.red;
    public int flashLoops = 2;
    public float flashDuration = 0.08f;
    #endregion

    private Tween _currentTween;

    private void OnValidate()
    {
        spriteRenderers = new List<SpriteRenderer>();

        foreach (var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderers.Add(child);
        }
    }

    public void Flash()
    {
        if (_currentTween != null)
        {
            // reset all to original sprite collor
            _currentTween.Kill();
            spriteRenderers.ForEach(i => i.color = Color.white);
        }

        foreach (var sprite in spriteRenderers)
        {
            _currentTween = sprite.DOColor(colorToFlash, flashDuration).SetLoops(flashLoops, LoopType.Yoyo);
        }

    }

}
