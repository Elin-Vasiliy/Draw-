using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject PrefEffect;
    public GameManager gameManager;

    private bool isWin;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isWin)
        {
            //Invoke($"{gameManager.GameWin()}", 0,5f);

            StartCoroutine(OpenWinGamePanel());

            isWin = true;
            GameObject newEffect = Instantiate(PrefEffect, transform.position, Quaternion.identity);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();

            Destroy(gameObject);
        }
    }

    private IEnumerator OpenWinGamePanel()
    {
        yield return new WaitForSeconds(1.1f);
        gameManager.GameWin();
    }
}
