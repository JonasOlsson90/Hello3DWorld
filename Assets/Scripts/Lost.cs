using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lost : MonoBehaviour
{
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Skriv logik för vinst och någon form av poängsystem Time.time för tid

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BallTing"))
        {
            //gameOverUI.SetActive(true);
            GameOver();
        }

        if (other.gameObject.CompareTag("Target1") || other.gameObject.CompareTag("Target2"))
        {
            CylinderTing cylinderTing = other.gameObject.GetComponent<CylinderTing>();
            if (!cylinderTing.isHit)
            {
                //gameOverUI.SetActive(true);
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
