using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpPotion : MonoBehaviour
{
    public int increaseHp;
    public Text TextHp;

    private void Update()
    {
        GetCoinStatic.hpPotion = int.Parse(TextHp.text);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetCoinStatic.hpPotion += increaseHp;
            TextHp.text = GetCoinStatic.hpPotion.ToString();
            Destroy(gameObject);
        }
    }
}
