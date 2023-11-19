using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResultsScript : MonoBehaviour
{
    public DataScript data;
    public DialogScript dialog;
    void Start()
    {
        // If there is no data, we cannot show results
        if (data.ResultCount == 0)
            return;

        // Bug fix: i < data.WordCount -> i < data.ResultCount
        for (int i = 0; i < data.ResultCount; i++)
        {
            var b = Instantiate(data.mainButton);
            b.GetComponentInChildren<Text>().text = data.Result(i);
            b.transform.SetParent(transform);
            b.transform.localScale = Vector2.one;
            SetItemHandler(b, i);
        }
        var es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        es.SetSelectedGameObject(transform.GetChild(0).gameObject);

        // nav
        var child0 = transform.GetChild(0).GetComponent<Button>();
        data.SetNavigationDown(GameObject.Find("HRButton").GetComponent<Button>(), child0);
        data.SetNavigationDown(GameObject.Find("HLButton").GetComponent<Button>(), child0);
    }

    void SetItemHandler(Button b, int i)
    {
        b.onClick.AddListener(() => dialog.ShowDialog("���������� � �����",
        data.CompleteResultInfo(i)));
    }

}