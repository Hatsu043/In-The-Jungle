using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poison : MonoBehaviour
{
    public int decreaseHp;
    public Text TextHp;

    private void Update()
    {
        GetCoinStatic.poison = int.Parse(TextHp.text);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetCoinStatic.poison -= decreaseHp;
            TextHp.text = GetCoinStatic.poison.ToString();
            Destroy(gameObject);
        }
    }
}
