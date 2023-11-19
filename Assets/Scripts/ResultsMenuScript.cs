using UnityEngine;

public class ResultsMenuScript : MenuScript
{
    public Canvas dialogCanvas;
    DialogScript dialog;
    public DataScript data;

    protected new void Start()
    {
        InitMenu(new string[] { "������� ������ ���������", "������� ��� ����������" }, MenuHandler);
        dialog = dialogCanvas.GetComponent<DialogScript>();
        base.Start();
    }

    void DisableAll()
    {
        es.SetSelectedGameObject(GameObject.Find("HLButton"));
        DisableMenuItem(0);
        DisableMenuItem(1);
    }
    void MenuHandler(int n)
    {
        if (n == 0)
        {
            var content = GameObject.Find("Content").transform;
            if (content.childCount > 0)
            {
                Destroy(content.GetChild(0).gameObject);
                data.DeleteFirstResult();
            }
                   
            if (content.childCount > 1)
                es.SetSelectedGameObject(content.GetChild(1).gameObject);
            else
                DisableAll();
        }
        else if (n == 1)
            dialog.ShowDialog("�������������",
            "������� ��� ����������\n� ����������� ������������?",
            new string[] { "��", "���" }, DeleteAllHandler, 1, 1);
    }

    void DeleteAllHandler(int n)
    {
        if (n == 1)
            return;
        var content = GameObject.Find("Content").transform;
        for (int i = 0; i < content.childCount; i++)
        {
            Destroy(content.GetChild(i).gameObject);
            data.DeleteAllResults();
        }
            
        DisableAll();
    }
}
