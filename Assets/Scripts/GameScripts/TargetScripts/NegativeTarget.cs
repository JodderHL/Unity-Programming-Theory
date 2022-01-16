using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// INHERITANCE
public class NegativeTarget: Target
{

    [SerializeField] private float _DespawnTimer;
    private float _CurrentLivetime;
    protected override void Start()
    {
        base.Start();
    }

    // POLYMORPHISM
    public override void ReactToPlayer()
    {
        throw new System.NotImplementedException();
    }


    private void Update()
    {
        _CurrentLivetime += Time.deltaTime;
        if (_DespawnTimer < _CurrentLivetime)
        {
            _GameManager.GetComponent<GameManager>().DestroyTarget(this);
            Destroy(gameObject);
        }
    }
}
