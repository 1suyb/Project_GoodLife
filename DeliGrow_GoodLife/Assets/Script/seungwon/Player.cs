using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum PlayerMode
    {
        A,
        B,
        C,
        D,
        E
    }

    public float speed;

    void Start()
    {
        speed = 0.2f;
    }
    void Update()
    {
       
    }   

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed);
        }

        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down * speed);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * speed);
        }
    }

    public void changeMode(PlayerMode mode)
    {
        Sprite nextSprite = Resources.Load<Sprite>("seungwon/" + (int)mode);
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        switch (mode)
        {
            case PlayerMode.A:
                spriteRenderer.sprite = nextSprite;
                break;
            case PlayerMode.B:
                spriteRenderer.sprite = nextSprite;         
                break;
            case PlayerMode.C:
                spriteRenderer.sprite = nextSprite;
                break;
            case PlayerMode.D:
                spriteRenderer.sprite = nextSprite;
                break;
            case PlayerMode.E:
                spriteRenderer.sprite = nextSprite;
                break;
        }
    }
}
