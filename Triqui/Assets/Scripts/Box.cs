using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public int index;
    public Mark mark;
    public bool marcado;

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        index = transform.GetSiblingIndex();
        mark = Mark.none;
        marcado = false;
    }

    public void SetAsMarked(Sprite sprite, Mark mark/*, Color color*/)
    {
        marcado = true;
        this.mark = mark;

        //spriteRenderer.color = color;
        spriteRenderer.sprite = sprite;

        GetComponent<CircleCollider2D>().enabled = false;
    }

}
