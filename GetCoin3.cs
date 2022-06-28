using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCoin3 : MonoBehaviour
{
    public int increaseCoin;
    //int coin;
    public Text TextCoin;
    public new Vector2 pos;

    private void Update()
    {
        //GetCoinStatic.coin = int.Parse(GameObject.FindGameObjectWithTag("TextCoin").GetComponent<Text>().text);
        GetCoinStatic.coin3 = int.Parse(TextCoin.text);
        transform.Rotate(pos);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetCoinStatic.coin3 += increaseCoin;
            TextCoin.text = GetCoinStatic.coin3.ToString();
            Destroy(gameObject);
            Debug.Log("coin =" + GetCoinStatic.coin3);
        }
    }
}
