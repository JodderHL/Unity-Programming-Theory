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

    private void Start()
    {
        StartCoroutine("DestroyShot");
        gameObject.layer = 10;
    }

    private IEnumerator DestroyShot()
    {
        yield return new WaitForSeconds(_LifeTime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Target>() != null )
        {
            print("Hit!");
            other.gameObject.GetComponent<Target>().Hit();
        }
    }
}
