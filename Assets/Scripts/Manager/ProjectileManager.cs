using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] List<GameObject> _weaponPrefabs;
    [SerializeField] List<Rect> _spawnPoint;
    [SerializeField] Color gizmoColor = new Color(1, 0, 0, 0.3f);
    [Range(1,20)] public int Speed = 5;

    ProjectileController projectileController;
    UIManager uiManager;

    public void ArrowSpawn()
    {
        if (GameManager.IsMiniGameStart)
        {
            int projectileNumber = Random.Range(1, 8);
            GameManager.ProjectileCount = projectileNumber;
            uiManager = FindAnyObjectByType<UIManager>();
            uiManager.SetPlayGame();

            GameObject randomPrefab = _weaponPrefabs[Random.Range(0, _weaponPrefabs.Count)];
            Rect randomSpawnArea = _spawnPoint[Random.Range(0, _spawnPoint.Count)];

            for (int i = 0; i < projectileNumber; i++)
            {
                Vector2 randomSpawnPoint = new Vector2(
                    Random.Range(randomSpawnArea.xMin, randomSpawnArea.xMax),
                    Random.Range(randomSpawnArea.yMin, randomSpawnArea.yMax)
                );

                if (randomSpawnArea == _spawnPoint[0])
                {
                    GameObject _spawnProjectile = Instantiate(randomPrefab, new Vector3(randomSpawnPoint.x, randomSpawnPoint.y), Quaternion.Euler(0, 0, -90));
                    projectileController = _spawnProjectile.GetComponent<ProjectileController>();
                    projectileController.SetDirection(Vector3.right, Speed);
                }
                if (randomSpawnArea == _spawnPoint[1])
                {
                    GameObject _spawnProjectile = Instantiate(randomPrefab, new Vector3(randomSpawnPoint.x, randomSpawnPoint.y), Quaternion.Euler(0, 0, 90));
                    projectileController = _spawnProjectile.GetComponent<ProjectileController>();
                    projectileController.SetDirection(Vector3.left, Speed);
                }
                if (randomSpawnArea == _spawnPoint[2])
                {
                    GameObject _spawnProjectile = Instantiate(randomPrefab, new Vector3(randomSpawnPoint.x, randomSpawnPoint.y), Quaternion.Euler(0, 0, 0));
                    projectileController = _spawnProjectile.GetComponent<ProjectileController>();
                    projectileController.SetDirection(Vector3.up, Speed);
                }
                if (randomSpawnArea == _spawnPoint[3])
                {
                    GameObject _spawnProjectile = Instantiate(randomPrefab, new Vector3(randomSpawnPoint.x, randomSpawnPoint.y), Quaternion.Euler(0, 0, 180));
                    projectileController = _spawnProjectile.GetComponent<ProjectileController>();
                    projectileController.SetDirection(Vector3.down, Speed);
                }
            }
        }


    }

    private void OnDrawGizmosSelected()
    {
        if (_spawnPoint == null) return;

        Gizmos.color = gizmoColor;
        foreach (var area in _spawnPoint)
        {
            Vector3 center = new Vector3(area.x + area.width / 2, area.y + area.height / 2);
            Vector3 size = new Vector3(area.width, area.height);
            Gizmos.DrawCube(center, size);
        }
    }
}
