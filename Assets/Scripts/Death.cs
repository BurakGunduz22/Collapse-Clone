using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Death : MonoBehaviour
{
    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject){
            SceneManager.LoadScene(0);
        }
        PlayerPrefs.GetInt("BoxHighScore",gameManager.BoxScore);
        PlayerPrefs.SetInt("BoxHighScore",gameManager.highScore);
    }
}
