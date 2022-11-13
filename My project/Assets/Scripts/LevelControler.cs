using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelControler : MonoBehaviour
{
    public Text CoinText;

    [SerializeField]
    public int bananas;

    public Movement movement;

    [SerializeField]
    bool win;

    [SerializeField]
    AudioSource deathFX;

    private void Start()
    {
        movement = GameObject.Find("Astronaut").GetComponent<Movement>();
    }

    // Update is called once per frame
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

        if (bananas == 50) 
        {
            win = true;
        }

        if (win) { SceneManager.LoadScene("Victory"); }
    }
}
