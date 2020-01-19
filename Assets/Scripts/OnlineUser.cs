using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
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
        DetectIndices(ref json, ref fIndex, ref symbols, ':', ',');
        Id = int.Parse(json.Substring(fIndex, symbols));
        json = json.Remove(0, json.IndexOf(',') + 1);
        DetectIndices(ref json, ref fIndex, ref symbols, ':', ',');
        Email = json.Substring(fIndex, symbols);
        json = json.Remove(0, json.IndexOf(',') + 1);
        DetectIndices(ref json, ref fIndex, ref symbols, ':', ',');
        Balance = float.Parse(json.Substring(fIndex, symbols), CultureInfo.InvariantCulture);
        json = json.Remove(0, json.IndexOf(',') + 1);
        DetectIndices(ref json, ref fIndex, ref symbols, ':', ',');
        Blocked = json.Substring(fIndex, symbols) == "0" ? false : true;
        json = json.Remove(0, json.IndexOf(',') + 1);
        DetectIndices(ref json, ref fIndex, ref symbols, ':', ',');
    }

    private void DetectIndices(ref string str, ref int fIndex, ref int symbols, char first, char second)
    {
        fIndex = str.IndexOf(first) + 1;
        symbols = str.IndexOf(second) - fIndex;
    }

    public override string ToString()
    {
        return $"Player {Id}: {Email}, balance: {Balance}";
    }
}