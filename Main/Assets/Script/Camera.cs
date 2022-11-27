using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Camera : MonoBehaviour
{
    public Transform target; //카메라 인스펙터에서 타겟지정가능하게


    private void Awake()
    {
        var obj = FindObjectsOfType<Camera>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y + 3, -10f); //카메라 위치 조정

        if (SceneManager.GetActiveScene().name == "Stage")
        {
            transform.position = new Vector3(target.position.x, target.position.y, -10f); //카메라 위치 조정

        }
    }

}
