using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poison2 : MonoBehaviour
{
    public int decreaseHp;
    public Text TextHp;

    private void Update()
    {
        GetCoinStatic.poison2 = int.Parse(TextHp.text);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetCoinStatic.poison2 -= decreaseHp;
            TextHp.text = GetCoinStatic.poison2.ToString();
            Destroy(gameObject);
        }
    }
}
