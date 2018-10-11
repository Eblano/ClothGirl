using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    RaycastHit2D hit;
    Vector2[] touches = new Vector2[5];
    Rigidbody2D rb;
    CircleCollider2D circleCol;
    bool mouseDown = false;
    bool touchInteractable = false;
    float bah = 0;
    bool touch = false;
    float timer = .5f;
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // Use this for initialization
    void Start()
    {
        //PlayerSettings.defaultCursor = cursorTexture;
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);

        rb = GetComponent<Rigidbody2D>();
        circleCol = GetComponent<CircleCollider2D>();
    }
    private IEnumerator MoveWaitTime(float waitTime)
    {
        Vector3 temp2;
        temp2 = Camera.main.ScreenToWorldPoint(new Vector2(Input.GetTouch(0).position.x, PlayerManager.Instance.transform.position.y));
        temp2.z = 0f;
        temp2.y = PlayerManager.Instance.transform.position.y;
        yield return new WaitForSeconds(waitTime);
        PlayerManager.Instance.transform.position = temp2;

    }
    // Update is called once per frame
    void MovePlayer()
    {

        IEnumerator coroutine = MoveWaitTime(.2f);
        StartCoroutine(coroutine);
    }
    void FixedUpdate()
    {
        if (Input.touchCount > 0 && timer <= 0)
        {
            foreach (Touch t in Input.touches)
            {
                if(timer >= 0)
                {
                    hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint((Input.GetTouch(t.fingerId).position)), Vector2.zero);
                    Vector3 temp = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(t.fingerId).position.x, Input.GetTouch(t.fingerId).position.y, 0));
                    temp.z = .5f;
                    rb.transform.position = temp;
                    circleCol.enabled = true;
                }

            }
        }
        else
        {
            circleCol.enabled = false;
            mouseDown = false;
            timer = .5f;

        }
        if (Input.GetMouseButton(0))
        {
            if(timer >= 0)
            {
                UpdateCut();
                mouseDown = true;
                circleCol.enabled = true;
                timer -= Time.deltaTime;
            }

        }
        else
        {
            timer = .5f;
            circleCol.enabled = false;
            mouseDown = false;
        }
        touch = false;

    }
    void UpdateCut()
    {
        rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.GetComponent<ICharacterButtonPress>() != null)
        //{
        //    ICharacterButtonPress temp = collision.GetComponent<ICharacterButtonPress>();
        //    if (temp.isInteractable && !temp.mouseTriggered)
        //    {
        //        temp.OnButtonPressed();
        //    }
        //}

        if (collision.gameObject.tag == "interactable" && PlayerManager.Instance.swordEquipped)
        {
            touch = true;
            collision.gameObject.GetComponent<IBladeInteractable>().BladeInteract();
        }
        else if (collision.gameObject.tag == "enemy")
        {
            touch = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "interactable" && PlayerManager.Instance.swordEquipped)
        {
            touch = true;
            collision.gameObject.GetComponent<IBladeInteractable>().BladeInteract();
        }
        else if(collision.gameObject.tag == "enemy")
        {
            touch = true;
        }
        else
        {
        }
    }
}
