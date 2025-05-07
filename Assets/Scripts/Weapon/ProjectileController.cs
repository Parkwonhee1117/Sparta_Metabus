using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [Range(1,10)][SerializeField] private int _damage = 10;
    private Vector3 moveDirection;
    private float moveSpeed;

    ProjectileManager projectileManager;
    StatHandler statHandler;

    void Awake()
    {
        projectileManager = FindAnyObjectByType<ProjectileManager>();
        statHandler = FindAnyObjectByType<StatHandler>();
    }

    public void SetDirection(Vector3 direction, float speed)
    {
        moveDirection = direction.normalized;
        moveSpeed = speed;
    }

    void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        if(transform.position. x <= 20 || transform.position.x > 55 || transform.position.y > 8 || transform.position.y < -8)
        {
            DestotyProjectile();
            GameManager.ProjectileCount--;
        }
        
        if(GameManager.ProjectileCount <= 0)
        {
            GameManager.Wave++;
            projectileManager.Speed++;
            projectileManager.ArrowSpawn();
        }
        
    }

    private void DestotyProjectile()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            statHandler.Health -= _damage;
            Destroy(this.gameObject);
            GameManager.ProjectileCount--;

            if (GameManager.ProjectileCount <= 0)
            {
                GameManager.Wave++;
                projectileManager.Speed++;
                projectileManager.ArrowSpawn();
            }
        }

    }
}
