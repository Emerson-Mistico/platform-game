using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("Moviment")]
    public float speed; // = 20;
    public float speedRun; // 33;
    public float forceJump; // 60;

    [Header("Animation Config")]
    public string triggerRun; // = "Run";
    public float swipeDuration; //  = 0.1f;
    public Ease ease; // = Ease.Unset;

    [Header("Jump Landing Setup")]
    public float jumpScaleY; // = 1.2f;
    public float jumpScaleX; // = 0.9f;
    public float jumpScaleDutarion; // = 0.2f;
    public float landingScaleY; // = 0.8f;
    public float landingScaleX; // = 1.2f;
    public float landingScaleDutarion; // = 0.08f;

}
