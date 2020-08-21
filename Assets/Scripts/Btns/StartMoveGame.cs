using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMoveGame : MonoBehaviour
{
    public GameObject[] Balles;

    public void OnClickStartMoveGameBtn()
    {
        for (int i = 0; i < Balles.Length; i++)
        {
            Balles[i].GetComponent<Rigidbody2D>().isKinematic = false; 
        }
    }
}
