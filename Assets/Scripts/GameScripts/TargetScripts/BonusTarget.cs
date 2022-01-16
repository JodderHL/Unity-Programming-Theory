using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// INHERITANCE
public class BonusTarget : Target
{
    [SerializeField] private float _DespawnTimer;
    private float _CurrentLivetime;

    // POLYMORPHISM
    protected override void Start()
    {
        base.Start();
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

    // POLYMORPHISM
    public override void ReactToPlayer()
    {
        throw new System.NotImplementedException();
    }
}
