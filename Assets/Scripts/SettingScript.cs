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

        // option 3
        data.GetWords(0);
        var text3 = GameObject.Find("3Text").GetComponent<Text>();
        var slider = GameObject.Find("3Slider").GetComponent<Slider>();
        slider.onValueChanged.AddListener(v => {
            data.OptVolume = (int)v;
            text3.text = $" Уровень громкости ({(int)v}):";
        });
        slider.value = data.OptVolume;
        GameObject.Find("3Button").GetComponent<Button>().onClick.AddListener(() => data.PlayAudio(0));
    }

    void Update()
    {
        
    }
}
