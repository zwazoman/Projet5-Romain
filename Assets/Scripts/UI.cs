using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] TMP_Text _clicksText;
    [SerializeField] TMP_InputField _nameInputField;
    [SerializeField] TMP_Text _timeText;

    //singleton
    private static UI instance;

    public static UI Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject go = new GameObject("UI");
                instance = go.AddComponent<UI>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public void UpdateClicks(int clicks)
    {
        _clicksText.text = "Clicks : " + clicks.ToString();
    }

    public void UpdateTime(float time)
    {
        _timeText.text = "Time : " + time.ToString();
    }

    public void UpdateNameField(string name)
    {
        _nameInputField.text = name;
    }

    public string GetNameField()
    {
        return _nameInputField.text;
    }
}
