using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public int speed = 8;
    private float angle;
    private float turnSpeed = 1.0f;

    public string Vertical = "Vertical";

    public string Horizontal = "Horizontal";

    public int movementNullifyer = 1;

    void Movement()
    {
        transform.Translate(new Vector3(0.0f, movementNullifyer*  speed * Input.GetAxisRaw(Vertical), 0f) * Time.deltaTime);

        transform.Rotate(new Vector3(0, 0,movementNullifyer * -0.3f * Input.GetAxisRaw(Horizontal)), Space.Self);

        if(Input.GetAxisRaw(Vertical) == 1 && GameObject.Find("MovementPlayer").GetComponent<AudioSource>().isPlaying == false)
        {
            GameObject.Find("MovementPlayer").GetComponent<AudioSource>().Play();
        }

    }
        // Start is called before the first frame update
        void Start()
        {
        FindObjectOfType<GameManager>().onGameOver += onGameOver;
        }

        // Update is called once per frame
        void Update()
        {
            Movement();
        }

    private void onGameOver()
    {
        movementNullifyer = 0;
    }
}
