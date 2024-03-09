using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [Header("Amunition Setup")]
    public Vector3 direction;
    public float timeToDestroy = 1f;
    public float side = 1;
    public int amountDamage = 1;
    public int amountCost = 5;

    private void Awake()
    {
        ItemManager.Instance.RemoveItemEnergy(amountCost);
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.transform.GetComponent<EnemyBase>();

        if (enemy != null)
        {
            enemy.TakeDamage(amountDamage);
            Destroy(gameObject, 0);
        }
    }
}
