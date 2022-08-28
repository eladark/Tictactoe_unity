using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    [SerializeField] private GameObject uiCanvas;
    [SerializeField] private TextMeshProUGUI textWin;
    [SerializeField] private Button uiRestart;
    [SerializeField] private Tablero tablero;
    void Start()
    {
        uiRestart.onClick.AddListener(() => SceneManager.LoadScene(0));
        tablero.OnWinAction += OnWinEvent;

        uiCanvas.SetActive(false);
    }

    private void OnWinEvent(Mark mark)
    {
        textWin.text = mark.ToString() + "Wins.";

        uiCanvas.SetActive(true);
    }

    private void OnDestroy()
    {
        uiRestart.onClick.RemoveAllListeners();
        tablero.OnWinAction -= OnWinEvent;
    }
}
