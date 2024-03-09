using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelthBase : MonoBehaviour
{
    #region Setups
    [Header("Health Setup")]
    public int startLife = 10;
    public bool isKillable = true;  

    [Header("HUD Setup")]
    public TextMeshProUGUI hudLifePoints;

    [Header("Dead Animation Config")]
    public string triggerIsDead = "IsDead";
    public float delayToDestroy = 3f;
    public float deadVelocity = 3.5f;
    public Animator animator;

    [SerializeField] private FlashCollor _flashCollor;
    
    // Public because: need access to enemyBase to not atack when killed
    public int currentLife; 
    #endregion

    private void Awake()
    {
        Init();

        if (_flashCollor == null)
        {
            _flashCollor = GetComponent<FlashCollor>();
        }
    }

    private void Init()
    {
        currentLife = startLife;

        if (this.tag == "Player")
        {
            UpdateHudLife();
        }        
        
    }

    #region Information area
    private void UpdateHudLife()
    {
        hudLifePoints.text = currentLife.ToString();
    }
    #endregion

    #region Damage and Kill
    public void Damage(int damage)
    {
        if (currentLife == 0)
        {
            return;
        }
        else
        {
            if (_flashCollor != null)
            {
                _flashCollor.Flash();
            }

            currentLife -= damage;

            if (this.tag == "Player")
            {
                UpdateHudLife();
            }

            if (currentLife <= 0)
            {
                Kill();
            }
        }        
        
    }

    private void Kill()
    {

        if (isKillable)
        {
            Destroy(gameObject, delayToDestroy);
            animator.SetBool(triggerIsDead, true);
            animator.speed = deadVelocity;

            if (this.tag == "Player")
            {
                PlayerPrefs.SetInt("PlayerIsAlive", 0);
                PlayerPrefs.SetInt("PlayerCanMove", 0);
            }

        }
        
    }
    #endregion

}
