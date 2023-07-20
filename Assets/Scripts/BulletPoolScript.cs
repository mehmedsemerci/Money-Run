using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Queue<GameObject> pooledbullets;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize;

    private void Awake()
    {
        pooledbullets = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
            obj.SetActive(false);
            pooledbullets.Enqueue(obj);

        }

    }

    public GameObject GetPooledBullet()
    {
        GameObject obj = pooledbullets.Dequeue();
        obj.SetActive(false);
        obj.SetActive(true);
        pooledbullets.Enqueue(obj);
        return obj;
    }

}
