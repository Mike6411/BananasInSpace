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

        //Se que esto es raro pero si hago lo del Loadscene dentro del check de 50 bananas pues no me funciona
        if (bananas == 50) 
        {
            win = true;
        }

        if (win) { SceneManager.LoadScene("Victory"); }
    }
}
