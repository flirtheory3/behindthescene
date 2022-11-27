using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stg1Go : MonoBehaviour
{
    private GameObject Player;
    SpriteRenderer sr;
    [SerializeField]
    private Image E;
private bool warp1 = false;
    void start()
    {
         Player = GameObject.FindWithTag("Player");
         E.gameObject.SetActive(false);
    }
      private void Update() {
          if(warp1 && Input.GetKeyDown(KeyCode.E))
            SceneManager.LoadScene("Stg1");
     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("Player")){
            E.gameObject.SetActive(true);
            warp1 = true;
         }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        E.gameObject.SetActive(false);
        warp1 = false;
    }
    
    
    }
