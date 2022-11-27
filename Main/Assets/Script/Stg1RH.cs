using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stg1RH : MonoBehaviour
{
    public GameObject Player;
    [SerializeField]
    private Image E;
private bool warp = false;
    void start()
    {
         E.gameObject.SetActive(false);
    }
    private void Update() {
        
          Player = GameObject.Find("Player");
          if(warp && Input.GetKeyDown(KeyCode.E)){
            Player.transform.position = new Vector2(13,-10);
            GameManager.Stg2 = true;
            SceneManager.LoadScene("Base");
          }
     }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("Player")){
            E.gameObject.SetActive(true);
            warp = true;
    }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        E.gameObject.SetActive(false);
        warp = false;
        
    }
    
    
    }
