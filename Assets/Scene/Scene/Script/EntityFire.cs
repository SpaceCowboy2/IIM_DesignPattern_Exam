using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFire : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    // [SerializeField] Bullet _bulletPrefab;
    [SerializeField] BulletPool pool;

    public bool canFire = true;
    public void FireBullet(int power)
    {
        if(canFire)
        {
            var b = pool.GiveBullet(_spawnPoint.transform.position, Quaternion.identity)
            .Init(_spawnPoint.TransformDirection(Vector3.right), power);
        }
    }
        

}
