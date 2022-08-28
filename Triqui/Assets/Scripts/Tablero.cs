using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Tablero : MonoBehaviour
{
    [SerializeField] private LayerMask BoxLMask;
    [SerializeField] private float radio;

    [SerializeField] private Sprite sX;
    [SerializeField] private Sprite sO;

    //[SerializeField] private Color cX;
    //[SerializeField] private Color cO;

    public UnityAction<Mark> OnWinAction;

    public Mark[] marks;
    private Camera cam;
    private Mark actual;
    private void Start()
    {
        cam = Camera.main;
        actual = Mark.x;
        marks = new Mark[9];

    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 touchPos = cam.ScreenToWorldPoint(Input.mousePosition);
            Collider2D hit = Physics2D.OverlapCircle(touchPos, radio, BoxLMask);

            if (hit)
            {
                HitBox(hit.GetComponent<Box>());
            }
        }
    }

    private void HitBox(Box box)
    {
        if (!box.marcado)
        {
            marks[box.index] = actual;

            box.SetAsMarked(GetSprite(), actual/*, GetColor()*/);
            bool ganador = CheckingW();
            if (ganador)
            {
                Debug.Log(actual.ToString() + "Wins");
                return;
            }
            Chance();
        }
    }

    private bool CheckingW()
    {
        return
        EqualBoxes(0, 1, 2) || EqualBoxes(3, 4, 5) ||
        EqualBoxes(6, 7, 8) || EqualBoxes(0, 3, 6) ||
        EqualBoxes(1, 4, 7) || EqualBoxes(2, 5, 8) ||
        EqualBoxes(6, 4, 2) || EqualBoxes(0, 4, 8);
    }

    private bool EqualBoxes(int i, int j, int k)
    {
        Mark act = actual;
        bool iguales = marks[i] == act && marks[j] == act && marks[k] == act;
        return iguales;
    }

    private void Chance()
    {
        actual = (actual == Mark.x) ? Mark.o : Mark.x;
    }

    /*private Color GetColor()
    {
        return (actual == Mark.x) ? cX : cO;
    }*/

    private Sprite GetSprite()
    {
        return (actual == Mark.x) ? sX : sO;
    }
}
