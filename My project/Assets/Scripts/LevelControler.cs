using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelControler : MonoBehaviour
{
    public Text CoinText;
    public int coins;
    public Movement movement;

    private void Start()
    {
        movement = GameObject.Find("Astronaut").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinText.text = "Bananas : " + coins;

        if (movement.respawn)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
