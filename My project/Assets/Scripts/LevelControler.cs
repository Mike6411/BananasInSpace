using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelControler : MonoBehaviour
{
    public Text CoinText;
    public PlayerMovement movement;

    private string playerGameobjectName = "New Astronaut";

    [SerializeField]
    public int bananas;

    [SerializeField]
    public bool win;

    [SerializeField]
    AudioSource deathFX;

    private void Start()
    {
        movement = GameObject.Find(playerGameobjectName).GetComponent<PlayerMovement>();
    }

    void Update()
    {
        CoinText.text = "Bananas : " + bananas;

        if (movement.respawn)
        {
            deathFX.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            movement.respawn = false;
            bananas = 0;
        }

        if (win) { SceneManager.LoadScene("Victory"); }
    }
}
