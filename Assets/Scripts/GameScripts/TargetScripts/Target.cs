using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// INHERITANCE
public abstract class Target : MonoBehaviour
{
    




    [SerializeField] protected Color _Color;
    [SerializeField] protected Vector3 _Size;
    [SerializeField] protected int _value;


    public int Value { get { return _value; } }

    public abstract void ReactToPlayer();

    protected virtual void Start()
    {
        SetColor();
        SetSize();
    }


    protected void SetColor()
    {
        gameObject.GetComponent<Renderer>().material.color = _Color;
    }


    protected void SetSize()
    {
        transform.localScale = _Size;
        transform.position = new Vector3(transform.position.x,_Size.y,transform.position.z);
    }
}
