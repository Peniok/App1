using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using System;
using TMPro;

public class Calculator : MonoBehaviour
{
    public TextMeshProUGUI res;
    public TextMeshProUGUI shower;
    bool _clearShowText;

    string _expression = "";
    
    public void On_Click_Bttn(string symbol)
    {
        if (_clearShowText)
        {
            _clearShowText = false;
            shower.text = "";
        }
        char symbolByChar = symbol[0];
        if (shower.text.Length == 0)
        {
            if (IsnotOperator(symbolByChar))
            {
                shower.text += symbol;
            }
        }
        else
        {
            char s = shower.text[shower.text.Length - 1];
            if (IsnotOperator(s) != IsnotOperator(symbolByChar) || (IsnotOperator(s) == true && IsnotOperator(symbolByChar) == true))
            {
                shower.text += symbol;
            }
        }
    }
    bool IsnotOperator(char s) => (s != '+' && s != '-' && s != '*' && s != '/' && s!='.');
    public void Clear()
    {
        shower.text = "";
    }
    
    public void Calculate()
    {
        if (shower.text.Length != 0 && IsnotOperator(shower.text[shower.text.Length-1]))
        {
            try
            {
                DataTable dt = new DataTable();
                _expression = dt.Compute(shower.text, "").ToString();
                _expression = Math.Round(Convert.ToDouble(_expression), 3).ToString();
                _expression = _expression.Replace(',', '.');
                shower.text = _expression;

                res.text = _expression;
            }
            catch
            {
                _clearShowText = true;
                shower.text = "ўось п≥шло не по плану";
            }
        }
    }

    public void Delete()
    {
       shower.text= shower.text.Remove(shower.text.Length-1,1);
    }

}
