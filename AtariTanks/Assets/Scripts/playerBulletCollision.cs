using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBulletCollision : MonoBehaviour
{

    public delegate void OnBulletHit(GameObject sender);

    public event OnBulletHit bulletHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject == collision.GetComponent<Bullet>().parent)
        {
            return;
        }
        bulletHit?.Invoke(gameObject);
        gameObject.GetComponent<ParticleSystem>().Play();
    }
}
