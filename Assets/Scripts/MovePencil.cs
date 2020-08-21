using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePencil : MonoBehaviour
{
    //private float m_speed = 5f;
    public Transform[] Points;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (transform.position == Points[0].position)
        {
            transform.Translate(Points[1].position);
        }
        else if (transform.position == Points[1].position)
        {
            transform.Translate(Points[2].position);
        }
        else if (transform.position == Points[2].position)
        {
            transform.Translate(Points[3].position);
        }
        else if (transform.position == Points[3].position)
        {
            transform.Translate(Points[4].position);
        }
        else if (transform.position == Points[4].position)
        {
            transform.Translate(Points[5].position);
        }


    }
}
