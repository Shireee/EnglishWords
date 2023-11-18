using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingScript : MonoBehaviour
{
    public DataScript data;
    void Start()
    {
        // option 1
        var toggle = GameObject.Find("1Toggle").GetComponent<Toggle>();
        toggle.isOn = data.OptAudioEnRu;
        toggle.onValueChanged.AddListener(b => data.OptAudioEnRu = b);

        // option 2
        var dropdown = GameObject.Find("2Dropdown").GetComponent<Dropdown>();
        dropdown.value = data.OptTopicName;
        dropdown.onValueChanged.AddListener(v => data.OptTopicName = v);

    }

    void Update()
    {
        
    }
}
