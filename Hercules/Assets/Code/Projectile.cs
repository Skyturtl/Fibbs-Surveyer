using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float maxRange;
    public float ProjectileSpeed;
    public float adjustedDamage;
    private Upgrade upgrade;
    private Vector3 startPosition;
    public float damage;
    public float bulletVelocity = 15f;
    //Outlets
    Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _rigidbody2D.velocity = transform.right * ProjectileSpeed;
        startPosition = transform.position;
        upgrade = GameObject.FindWithTag("Player").GetComponent<Upgrade>();
    }

    private void Update()
    {
        float traveledDistance = Vector3.Distance(startPosition, transform.position); 

        if (traveledDistance >= maxRange) 
        {
            Destroy(gameObject); 
        }
        _rigidbody2D.velocity = transform.right * (bulletVelocity + upgrade.bulletSpeedAdded);
        adjustedDamage = damage + upgrade.bulletDamageAdded;
        
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")){
            collision.gameObject.GetComponent<Enemy>().TakeDamage(adjustedDamage, this.gameObject);
            Rigidbody2D enemyRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            enemyRigidbody.velocity = Vector2.zero;
            SoundManager.instance.PlayMagicKill();
        }
        else if(collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Boss>().takeDamage(adjustedDamage);
            SoundManager.instance.PlayMagicKill();
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy")){
            collision.gameObject.GetComponent<Enemy>().TakeDamage(adjustedDamage, this.gameObject);
            Rigidbody2D enemyRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            enemyRigidbody.velocity = Vector2.zero;
            SoundManager.instance.PlayMagicKill();
        }
        else if(collision.gameObject.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<Boss>().takeDamage(adjustedDamage);
            SoundManager.instance.PlayMagicKill();
        }
    }
}
