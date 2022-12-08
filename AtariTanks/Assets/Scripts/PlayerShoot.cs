using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;

    private bool canShoot = true;

    public string fire = "Fire1";

    public Sprite bulletSprite;


    public GameObject bulletInstance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw(fire) > 0 && canShoot)
        {
            bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);

            bulletInstance.GetComponent<Bullet>().direction = transform.up;
            canShoot = false;
            bulletInstance.GetComponent<Bullet>().parent = gameObject;
            StartCoroutine("shootCoolDown");
            bulletInstance.GetComponent<SpriteRenderer>().sprite = bulletSprite;
        }
    }

    public IEnumerator shootCoolDown()
    {
        yield return new WaitForSeconds(5);
        canShoot = true;
    }

    public void onPlayerhit(GameObject sender)
    {
        Debug.Log("I hit the other player");
        StopCoroutine("shootCoolDown");
        canShoot = true;
    }
}
