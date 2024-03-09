using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    [Header("Gun Configuration")]
    public ProjectileBase amunition;
    public Transform shootPoint;
    public Transform playerSide;
    public KeyCode keyToShoot = KeyCode.C;

    public AudioSource shootSound;

    public SOInt energyAmount;

    private void Update()
    {
        if (PlayerPrefs.GetInt("PlayerCanShoot") == 1)
        {
            if (Input.GetKeyDown(keyToShoot) && energyAmount.value > 0)
            {
                Shoot();
            }
        }
            
    }

    public void Shoot()
    {
        var projectile = Instantiate(amunition);
        projectile.transform.position = shootPoint.position;
        projectile.side = playerSide.transform.localScale.x;

        if (shootSound  != null ) { shootSound.Play(); }

    }        
    
}
