using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;


public class ControlScript : MonoBehaviour
{
    public DataScript data;
    public Toggle mainToggle;
 
    void Start()
    {
        var togglePanel = GameObject.Find("TogglePanel").transform;
        togglePanel.GetChild(data.TestType).GetComponent<Toggle>().isOn = true;
        for (int i = 0; i < 3; i++)
            SetToggleHandler(togglePanel.GetChild(i).GetComponent<Toggle>(), i);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetToggleHandler(Toggle t, int i)
    {
        t.onValueChanged.AddListener(b =>
        {
            if (b) data.TestType = i;
        });
    }

}
