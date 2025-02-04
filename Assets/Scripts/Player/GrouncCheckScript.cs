using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrouncCheckScript : MonoBehaviour
{

    public static bool tocosuelo;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            tocosuelo = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            tocosuelo = false;
        }
    }
}
