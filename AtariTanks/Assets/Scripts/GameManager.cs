using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject victoryGui;

    [SerializeField]
    private GameObject player;

    private GameObject[] players;

    [SerializeField]
    private Text[] playerUICounters = new Text[2];

    public delegate void GameOver();

    public event GameOver onGameOver;

    [SerializeField]
    private Sprite[] playerSprites = new Sprite[2];

    [SerializeField]
    private Sprite[] bulletSprites = new Sprite[2];

    // Start is called before the first frame update

    private int[] playerScores = new int[] { 0, 0 };
    void Start()
    {
        players = new GameObject[] {
        Instantiate(player, new Vector3(-6,0,0), Quaternion.identity),
        
        Instantiate(player, new Vector3(6,0,0), Quaternion.identity)};

        players[1].GetComponent<PlayerMove>().Vertical = "Vertical2";
        players[1].GetComponent<PlayerMove>().Horizontal = "Horizontal2";
        players[1].GetComponent<PlayerShoot>().fire = "Fire2";

        players[0].GetComponent<PlayerShoot>().bulletSprite = bulletSprites[0];
        players[1].GetComponent<PlayerShoot>().bulletSprite = bulletSprites[1];

        for (int i = 0; i < 2; i++)
        {
            players[i].GetComponent<playerBulletCollision>().bulletHit += playerHitHandler;
            players[i].GetComponent<playerBulletCollision>().bulletHit += players[(i + 1) % 2].GetComponent<PlayerShoot>().onPlayerhit;
            players[i].GetComponent<SpriteRenderer>().sprite = playerSprites[i];
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playerHitHandler(GameObject sender)
    {
        if (sender == players[0])
        {
            Debug.Log("Player 1 hit");
            playerScores[1]++;
            playerUICounters[1].text = playerScores[1].ToString();
        }
        else if(sender == players[1])
        {
            Debug.Log("Player 2 hit");
            playerScores[0]++;
            playerUICounters[0].text = playerScores[0].ToString();
        }

        if(playerScores[0] >= 10)
        {
            //player 1 victory
            Debug.Log("Player 1 Victory");
            victoryGui.GetComponent<Canvas>().enabled = true;
            victoryGui.transform.GetChild(0).GetComponent<Text>().text = "Player 1 Won!";
            onGameOver?.Invoke();
            GameObject.Find("GameOverPlayer").GetComponent<AudioSource>().Play();
        }
        else if (playerScores[1] >= 10)
        {
            //player 2 victory
            Debug.Log("Player 2 victory");
            victoryGui.GetComponent<Canvas>().enabled = true;
            victoryGui.transform.GetChild(0).GetComponent<Text>().text = "Player 2 Won!";
            onGameOver?.Invoke();
            GameObject.Find("GameOverPlayer").GetComponent<AudioSource>().Play();
        }
    }
}
