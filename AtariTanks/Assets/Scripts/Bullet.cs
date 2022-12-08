using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector3 direction;

    private Camera cam;

    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        StartCoroutine("decay");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * 0.02f);
    }

    private void OnBecameInvisible()
    {

        //find what side of the screen we have gone out of
        if (cam.WorldToScreenPoint(transform.position).y >= cam.pixelHeight)
        {
            //top
            direction = Vector3.Reflect(direction, Vector3.down);
        }
        if (cam.WorldToScreenPoint(transform.position).y <= 0)
        {
            //bottom
            direction = Vector3.Reflect(direction, Vector3.down);
        }
        if (cam.WorldToScreenPoint(transform.position).x >= cam.pixelWidth)
        {
            //right
            direction = Vector3.Reflect(direction, Vector3.left);
        }
        if (cam.WorldToScreenPoint(transform.position).x <= 0)
        {
            //left
            direction = Vector3.Reflect(direction, Vector3.left);
        }
    }

    public IEnumerator decay()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == parent)
        {
            return;
        }

        GameObject.Find("ExplosionPlayer").GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
