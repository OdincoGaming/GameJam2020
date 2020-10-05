using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public ButtonClick upBtn;
    public ButtonClick upLeftBtn;
    public ButtonClick upRightBtn;

    public ButtonClick leftBtn;
    public ButtonClick rightBtn;

    public ButtonClick downBtn;
    public ButtonClick downLeftBtn;
    public ButtonClick downRightBtn;

    [SerializeField] private float speed = 0;
    [SerializeField] private float dist = 0;

    Vector3 pos;
    Transform tr;
 
    void Start()
    {
        pos = transform.position;
        tr = transform;
    }

    void FixedUpdate()
    {
        if (upBtn.buttonPressed && tr.position == pos)
        {
            pos += new Vector3(0,dist, 0);
        }
        else if (upLeftBtn.buttonPressed && tr.position == pos)
        {
            pos += new Vector3(-dist,dist, 0);
        }
        else if (upRightBtn.buttonPressed && tr.position == pos)
        {
            pos += new Vector3(dist,dist, 0);
        }
        else if (leftBtn.buttonPressed && tr.position == pos)
        {
            pos += new Vector3(-dist,0, 0);
        }
        else if (rightBtn.buttonPressed && tr.position == pos)
        {
            pos += new Vector3(dist,0, 0);
        }
        else if (downBtn.buttonPressed && tr.position == pos)
        {
            pos += new Vector3(0, -dist, 0);
        }
        else if (downLeftBtn.buttonPressed && tr.position == pos)
        {
            pos += new Vector3(-dist, -dist, 0);
        }
        else if (downRightBtn.buttonPressed && tr.position == pos)
        {
            pos += new Vector3(dist, -dist, 0);
        }

        transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * speed);
    }
}
