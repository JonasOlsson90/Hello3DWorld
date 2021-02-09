using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lost : MonoBehaviour
{
    public GameObject gameOverUI;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BallTing"))
        {
            GameOver();
        }

        if (other.gameObject.CompareTag("Target1") || other.gameObject.CompareTag("Target2"))
        {
            CylinderTing cylinderTing = other.gameObject.GetComponent<CylinderTing>();
            if (!cylinderTing.isHit)
            {
                GameOver();
            }            
        }
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
        StartCoroutine(Wait(1));
    }

    public static IEnumerator Wait(int temp)
    {
        yield return new WaitForSeconds(temp);
        Time.timeScale = 0;
    }
}