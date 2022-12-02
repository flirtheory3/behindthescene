using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stg2Go : MonoBehaviour
{
    public GameObject Player;
    [SerializeField]
    private Image E;
    bool Cango2;
    void start()
    {
         E.gameObject.SetActive(false);
    }
      private void Update() {
          Player = GameObject.FindWithTag("Player");
          if(GameManager.Stg2 && Cango2 && Input.GetKeyDown(KeyCode.E)){
            Player.transform.position = new Vector2(0,0);
            SceneManager.LoadScene("Stg2");
          }
     }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("Player") && GameManager.Stg2){
            E.gameObject.SetActive(true);
            Cango2 = true;
         }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        E.gameObject.SetActive(false);
        Cango2 = false;
    }
}
