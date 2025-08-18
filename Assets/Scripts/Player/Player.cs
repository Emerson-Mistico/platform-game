using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    #region Setups
    [Header("Player")]
    public Rigidbody2D playerRigidBody;    
    public Animator animator;

    public AudioSource jumpUpSound;
    public AudioSource landingSound;

    [Header("SO Player Setup")]
    public SOPlayerSetup soPlayerSetup;

    [Header("Jump Collision Check")]
    public float landingTolerance = 0.5f;
    public float spaceToGround = 0.1f;
    public float distanceToGround;

    public Collider2D collider2D;

    private float _currentSpeed;
    private int _currentDirection = 1;
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            // Check the tolerance of the landing to determine if it reached the ground.
            if (contact.normal.y > landingTolerance)
            {
                LandingEffect();
            }
        }

    }

    private void Awake()
    {
        if(collider2D != null)
        {
           distanceToGround = collider2D.bounds.extents.y;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (PlayerPrefs.GetInt("PlayerCanMove") == 1)
        {
            CheckIsGrounded();
            HandleJump();
            HandleMoviment();            
        }
    }

    #region Auxiliar area

    // public for use in soud random steps
    public bool CheckIsGrounded() 
    {
        // Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, distanceToGround + spaceToGround);
        return Physics2D.Raycast(transform.position, -Vector2.up, 
            distanceToGround + spaceToGround);
    }    
    #endregion

    #region Moviment Area
    private void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl) && CheckIsGrounded()) {
            _currentSpeed = soPlayerSetup.speedRun;
            animator.speed = 1.5f;
        } else
        {
            _currentSpeed = soPlayerSetup.speed;
            animator.speed = 1;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _currentDirection = -1;

            if (playerRigidBody.transform.localScale.x != -1)
            {
                playerRigidBody.transform.DOScaleX(-1, soPlayerSetup.swipeDuration);
            }
            
            playerRigidBody.linearVelocity = new Vector2(-_currentSpeed, playerRigidBody.linearVelocity.y);

            animator.SetBool(soPlayerSetup.triggerRun, true);
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {

            _currentDirection = 1;

            if (playerRigidBody.transform.localScale.x != 1)
            {
                playerRigidBody.transform.DOScaleX(1, soPlayerSetup.swipeDuration);
            }
            
            playerRigidBody.linearVelocity = new Vector2(_currentSpeed, playerRigidBody.linearVelocity.y);

            animator.SetBool(soPlayerSetup.triggerRun, true);
        }
        else
        {
            // Remove slide effect
            playerRigidBody.linearVelocity = new Vector2(0, playerRigidBody.linearVelocity.y);

            animator.SetBool(soPlayerSetup.triggerRun, false);
        }

    }

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CheckIsGrounded()) {

            playerRigidBody.linearVelocity = Vector2.up * soPlayerSetup.forceJump;

            // if two jumps are pressed starts animation from scratch            
            playerRigidBody.transform.localScale = new Vector3(_currentDirection, 1, 1);

            DOTween.Kill(playerRigidBody.transform);           

            JumpEffect();
            jumpUpSound.Play();
            PlayJumpVFX();

        }

    }
    #endregion

    #region VFX
    private void PlayJumpVFX()
    {
        VFXmanager.Instance.PlayVFXbyType(VFXmanager.VFXType.JUMP, transform.position);
    }
    #endregion

    #region Manual Effects
    private void JumpEffect()
    {
        
        playerRigidBody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.jumpScaleDutarion)
            .SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        
        if (_currentDirection == -1)
        {
            playerRigidBody.transform.DOScaleX(-soPlayerSetup.jumpScaleX, soPlayerSetup.jumpScaleDutarion).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        } else {
            playerRigidBody.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.jumpScaleDutarion).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        }
        

    }

    private void LandingEffect()
    {
        
        landingSound.Play();

        playerRigidBody.transform.DOScaleY(soPlayerSetup.landingScaleY, soPlayerSetup.landingScaleDutarion)
            .SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);

        float _finalScaleX;

        if (_currentDirection == -1)
        {
            _finalScaleX = -soPlayerSetup.landingScaleX;
        }
        else
        {
            _finalScaleX = soPlayerSetup.landingScaleX;
        }

        playerRigidBody.transform.DOScaleX(_finalScaleX, soPlayerSetup.landingScaleDutarion)
            .SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease)
            .OnComplete(() => {
                // Adjusts the scale to the original state and corrects the direction.
                playerRigidBody.transform.localScale = new Vector3(_currentDirection, 1, 1);
            });
    }
    #endregion

}
