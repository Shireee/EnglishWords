using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeaderScript : MonoBehaviour
{
    Button lBut, rBut;
    int curInd;
    public DataScript data;
    public Canvas menuCanvas;
    MenuScript menu;
    CanvasGroup canvasGroup;


    void Start()
    {
        lBut = transform.GetChild(0).GetComponent<Button>();
        rBut = transform.GetChild(1).GetComponent<Button>(); // getting first child !guide error
        curInd = SceneManager.GetActiveScene().buildIndex;
        canvasGroup = GameObject.Find("Canvas").GetComponent<CanvasGroup>();

        if (menuCanvas != null)
            menu = menuCanvas.GetComponent<MenuScript>();
    }

    // saving preferences
    void OnDestroy()
    {
        if (data != null)
        {
            data.SavePrefs();
        }
    }

    void Update()
    {
        // do not nav if we a in the context menu
        if (!Input.anyKeyDown || canvasGroup != null && !canvasGroup.interactable)
            return;

        if (!Input.anyKeyDown)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
            OnClickHandler(-1);
        else if (Input.GetKeyDown(KeyCode.F5)) // move to learing
            OnClickHandler(1);
        else if (Input.GetKeyDown(KeyCode.F6)) // move to contol
            OnClickHandler(2);
        else if (Input.GetKeyDown(KeyCode.F7)) // move to result
            OnClickHandler(3);
        else if (Input.GetKeyDown(KeyCode.F2)) // move to settings
            OnClickHandler(4);
        else if (Input.GetKeyDown(KeyCode.F1)) // move to help
            OnClickHandler(5);
        else if (Input.GetKeyDown(KeyCode.F3)
        && lBut.IsActive() && lBut.interactable) // header left button
            lBut.onClick.Invoke();
        else if (Input.GetKeyDown(KeyCode.F4) // header right button
        && rBut.IsActive() && rBut.interactable)
            rBut.onClick.Invoke();
    }
    public void OnClickHandler(int index)
    {
        if (index >= 0)
        {
            if (index != curInd)
                SceneManager.LoadScene(index);
        }
        else if (index == -1)
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        else if (index == -2)
        {
            if (menu != null)
                menu.ShowMenu();
        }
    }
}
