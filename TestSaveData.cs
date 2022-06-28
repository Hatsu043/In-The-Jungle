using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class TestSaveData : MonoBehaviour
{
    public testGameData data;
    string dataFilePath;
    BinaryFormatter bf;

    private void Awake()
    {
        bf = new BinaryFormatter();
        dataFilePath = Application.persistentDataPath + "/game.dat";
    }

    void UpdateData()
    {
        data.coin = GetCoinStatic.coin;   //เพิ่มตัวแปลตามลักษณะเกมของเรา
        data.coin2 = GetCoinStatic.coin2;
        data.coin3 = GetCoinStatic.coin3;
        data.poison = GetCoinStatic.poison;
        data.poison2 = GetCoinStatic.poison2;
        data.hpPotion = GetCoinStatic.hpPotion;
    }

    void SaveData()
    {
        UpdateData();
        FileStream fs = new FileStream(dataFilePath, FileMode.Create);
        bf.Serialize(fs, data);
        fs.Close();
    }

    void LoadData()
    {
        if(File.Exists(dataFilePath))
        {
            FileStream fs = new FileStream(dataFilePath, FileMode.Open);
            data = (testGameData)bf.Deserialize(fs);
            fs.Close();
            DisplayData();
        }
    }

    void DisplayData()
    {
        //แก้ไขตามตัวแปรในเกม
        GameObject.FindGameObjectWithTag("TextCoin").GetComponent<Text>().text = data.coin.ToString();
        GameObject.FindGameObjectWithTag("TextCoin").GetComponent<Text>().text = data.coin2.ToString();
        GameObject.FindGameObjectWithTag("TextCoin").GetComponent<Text>().text = data.coin3.ToString();
        GameObject.FindGameObjectWithTag("TextHp").GetComponent<Text>().text = data.poison.ToString();
        GameObject.FindGameObjectWithTag("TextHp").GetComponent<Text>().text = data.poison2.ToString();
        GameObject.FindGameObjectWithTag("TextHp").GetComponent<Text>().text = data.hpPotion.ToString();
        GetCoinStatic.coin = data.coin;
        GetCoinStatic.coin2 = data.coin2;
        GetCoinStatic.coin3 = data.coin3;
        GetCoinStatic.poison = data.poison;
        GetCoinStatic.poison2 = data.poison2;
        GetCoinStatic.hpPotion = data.hpPotion;
    }

    private void OnEnable()
    {
        LoadData();
    }

    private void OnDisable()
    {
        SaveData();
    }

}
