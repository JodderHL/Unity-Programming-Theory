using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// INHERITANCE
public abstract class Target : MonoBehaviour
{




    protected GameObject _GameManager;
    [SerializeField] protected Color _Color;
    [SerializeField] protected Vector3 _Size;
    [SerializeField] protected int _Value;
    [SerializeField] protected int _Probability;

    public int Probability { get { return _Probability; } }


    public int Value { get { return _Value; } }

    public abstract void ReactToPlayer();

    protected virtual void Start()
    {
        SetColor();
        SetSize();
        SetGameManager();
    }

    private void SetGameManager()
    {
        _GameManager = GameObject.FindObjectOfType<GameManager>().gameObject;
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
