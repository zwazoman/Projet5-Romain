using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class SaveXML : MonoBehaviour
{
    int _clicksCount;
    string _name;
    float _time;

    string Path = "Assets/SaveFile.xml";
    private void Start()
    {
        XmlDocument save = new XmlDocument();
        if (!System.IO.File.Exists(Path))
        {
            print("La con de tes morts il est où le fichier cagole");
            return;
        }
        save.Load(Path);

        foreach (XmlNode node in save.ChildNodes[1])
        {
            string key = node.Name;
            string value = node.InnerText;
            switch (key)
            {
                case "Clicks":
                    _clicksCount = int.Parse(value);
                    UI.Instance.UpdateClicks(_clicksCount);
                    break;
                case "Name":
                    _name = value;
                    UI.Instance.UpdateNameField(_name);
                    break;
                case "Time":
                    _time = float.Parse(value);
                    UI.Instance.UpdateTime(_time);
                    break;
            }
        }
    }
    private void Update()
    {
        _time += Time.deltaTime;
    }

    public void SaveGame()
    {
        UI.Instance.UpdateTime(_time);

        _clicksCount++;
        UI.Instance.UpdateClicks(_clicksCount);

        _name = UI.Instance.GetNameField();

        XmlWriterSettings settings = new XmlWriterSettings
        {
            NewLineOnAttributes = true,
            Indent = true,
        };

        XmlWriter writer = XmlWriter.Create(Path, settings);

        writer.WriteStartDocument();
        writer.WriteStartElement("Data");
        AddData(writer, "Clicks", _clicksCount.ToString());
        AddData(writer, "Name", _name);
        AddData(writer, "Time", _time.ToString());
        writer.WriteEndElement();
        writer.WriteEndDocument();
        writer.Close();
    }

    void AddData(XmlWriter writer, string key, string value)
    {
        writer.WriteStartElement(key);
        writer.WriteString(value);
        writer.WriteEndElement();
    }
}
