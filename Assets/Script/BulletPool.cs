using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
public class BulletPool : MonoBehaviour
{
    public Stack<Bullet> waitingBullets= new Stack<Bullet>();
    public List<Bullet> activeBullets = new List<Bullet>();

    public Bullet bulletPrefab = null;
    public GameObject particlePrefab = null;
    [SerializeField] int nbBullets;

    public event UnityAction<Vector3> onDropBullet;

    public AudioSource source;

    private void Awake()
    {
        onDropBullet += PlaySound;
    }

    public void PlaySound(Vector3 pos)
    {
        source.Play();
        GameObject gameobject = Instantiate(particlePrefab, pos, Quaternion.identity);
        Destroy(gameobject, 1.0f);
    }

    private void Start()
    {
        for(int i = 0; i < nbBullets; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab);
            bullet.gameObject.SetActive(false);
            waitingBullets.Push(bullet);
            bullet.pool = this;
        }
    }
    public Bullet GiveBullet(Vector3 pos, Quaternion quat)
    {
        Bullet newBullet = null;

        if (waitingBullets.Count > 0)
        {
            newBullet = waitingBullets.Pop();
            activeBullets.Add(newBullet);
            newBullet.transform.position = pos;
            newBullet.transform.rotation = quat;


            newBullet.gameObject.SetActive(true);
        }
        else
        {
            newBullet = Instantiate(bulletPrefab, pos, quat);
            newBullet.pool = this;
        }

        return newBullet;
    }

    public void CollectBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);

        waitingBullets.Push(bullet);
        activeBullets.Remove(bullet);

        onDropBullet?.Invoke(bullet.transform.position);
    }
}
