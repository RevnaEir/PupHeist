using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSystem : MonoBehaviour
{
    public GameObject correctForm;
    private bool moving;
    private bool finish;

    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;

    [SerializeField] private Vector2 offset;
    [SerializeField] private GameAction callback;
   
    void Start()
    {
        resetPosition = transform.position;
    }

   
    void Update()
    {
        if (finish == false)
        {
            if (moving)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);

                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
            }
        }
        
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if(correctForm != null)
        {
            CheckObjectPosition();
        }
        else
        {
            this.transform.position = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }

    private void CheckObjectPosition()
    {
        
        if (Mathf.Abs(this.transform.localPosition.x - correctForm.transform.localPosition.x) <= offset.x &&
        Mathf.Abs(this.transform.localPosition.y - correctForm.transform.localPosition.y) <= offset.y)
        {
            transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);
            finish = true;
            callback?.Raise();
        }
        else
        {
            transform.position = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
    }

}
