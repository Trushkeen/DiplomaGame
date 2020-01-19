using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//{"id":10001,"Email":"test@gmail.com","Amount":6.90,"Blocked":0,"RegDate":"2019-12-17T09:32:51.05"}

public class OnlineUser
{
    public int Id { get; private set; }
    public string Email { get; private set; }
    public float Balance { get; set; }
    public bool Blocked { get; private set; }
    public DateTime RegDate { get; private set; }

    public void ParseJsonUserString(string json)
    {
        int fIndex = 0, symbols = 0;
        json = json.Trim('{').Trim('}').Trim('"').Trim(':') + ',';
        DetectIndices(json, ref fIndex, ref symbols, ':', ',');
        Id = int.Parse(json.Substring(fIndex, symbols));
        DetectIndices(json, ref fIndex, ref symbols, ':', ',');
        Email = json.Substring(fIndex, symbols);
        DetectIndices(json, ref fIndex, ref symbols, ':', ',');
        Balance = float.Parse(json.Substring(fIndex, symbols));
        DetectIndices(json, ref fIndex, ref symbols, ':', ',');
        Blocked = json.Substring(fIndex, symbols) == "0" ? false : true;
        DetectIndices(json, ref fIndex, ref symbols, ':', ',');
        RegDate = DateTime.Parse(json.Substring(fIndex, symbols));
    }

    private void DetectIndices(string str, ref int fIndex, ref int symbols, char first, char second)
    {
        fIndex = str.IndexOf(first) + 1;
        symbols = str.IndexOf(second) - fIndex;
    }
}