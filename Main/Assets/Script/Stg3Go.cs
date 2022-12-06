using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stg3Go : MonoBehaviour
{
    public GameObject Player;
    [SerializeField]
    private Image E;
    void start()
    {
         E.gameObject.SetActive(false);
    }
    private void Update() {
          Player = GameObject.FindWithTag("Player");
          if(GameManager.Cango3 && Input.GetKeyDown(KeyCode.E)){
            Player.transform.position = new Vector2(0,0);
            SceneManager.LoadScene("Stg3");
          }
     }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("Player")){
            E.gameObject.SetActive(true);
         }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        E.gameObject.SetActive(false);
    }
}
