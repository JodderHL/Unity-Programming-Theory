using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _Speed;
    [SerializeField] private float _LifeTime;
    public void Launch()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * _Speed, ForceMode.Impulse);
    }
    // ENCAPSULATION
    private void Start()
    {
        StartCoroutine("DestroyShot");
        gameObject.layer = 10;
    }
    // ENCAPSULATION
    private IEnumerator DestroyShot()
    {
        yield return new WaitForSeconds(_LifeTime);
        Destroy(gameObject);
    }
    // ENCAPSULATION
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 9) return;
        if(other.gameObject.GetComponent<Target>() != null )
        {
            //print("Hit!");
            other.gameObject.GetComponent<Target>().Hit();
        }
    }
}
