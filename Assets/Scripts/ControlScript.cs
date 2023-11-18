using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;


public class ControlScript : MonoBehaviour
{
    public DataScript data;
    public Toggle mainToggle;
    SortedSet<int> checkedItems;
    Button hRButton;
    Transform togglePanel;
    Text hText;


    void Start()
    {
        // handle train type
        togglePanel = GameObject.Find("TogglePanel").transform;
        togglePanel.GetChild(data.TestType).GetComponent<Toggle>().isOn = true;
        for (int i = 0; i < 3; i++)
            SetToggleHandler(togglePanel.GetChild(i).GetComponent<Toggle>(), i);

        // create list of topics
        checkedItems = data.TestTopics;
        hRButton = GameObject.Find("HRButton").GetComponent<Button>();
        for (int i = 0; i < data.TopicCount; i++)
        {
            var t = Instantiate(mainToggle);
            t.GetComponentInChildren<Text>().text = data.Topic(i);
            t.transform.SetParent(gameObject.transform);
            t.transform.localScale = Vector2.one;
            if (checkedItems.Contains(i))
                t.GetComponent<Toggle>().isOn = true;
            SetItemHandler(t, i);
        }

        // handle state saving 
        var es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(transform.GetChild(data.S2ItemIndex).gameObject);
        var scrollbar = GameObject.Find("Scrollbar Vertical").GetComponent<Scrollbar>();
        scrollbar.value = data.S2ScrollbarValue;
        scrollbar.onValueChanged.AddListener(v => data.S2ScrollbarValue = v);

        // handle nav through buttons
        var child0 = transform.GetChild(0).GetComponent<Toggle>();
        for (int i = 0; i < 3; i++) data.SetNavigationDown(togglePanel.GetChild(i).GetComponent<Toggle>(), child0);

        // handle header info
        hText = GameObject.Find("HText").GetComponent<Text>();
        SetHeader();

    }

    // handle nav through key 1, 2, 3..
    void Update()
    {
        if (Input.inputString.Length > 0)
        {
            int i = Input.inputString[0] - '1';
            if (i >= 0 && i <= 2)
                togglePanel.GetChild(i).GetComponent<Toggle>().isOn = true;
        }
    }

    // handle train data
    void SetItemHandler(Toggle t, int i)
    {
        t.onValueChanged.AddListener(b =>
        {
            if (b)
                checkedItems.Add(i);
            else
                checkedItems.Remove(i);
            data.TestTopics = checkedItems;
            hRButton.interactable = checkedItems.Count > 0;
            SetHeader();
        });
    }

    // handle toggle check
    void SetToggleHandler(Toggle t, int i)
    {
        t.onValueChanged.AddListener(b =>
        {
            if (b) data.TestType = i;
        });
    }

    // handle header info
    void SetHeader()
    {
        var s = $"Контроль\n{data.Level + 1}:{data.TestTopicsToString()}";
        if (s.Length > 25)
            s = s.Substring(0, 25) + "...";
        hText.text = s;
    }


}
