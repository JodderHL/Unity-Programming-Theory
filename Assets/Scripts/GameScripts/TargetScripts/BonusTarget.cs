using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// INHERITANCE
public class BonusTarget : Target
{
    // POLYMORPHISM
    protected override void Start()
    {
        base.Start();
    }



    // POLYMORPHISM
    public override void ReactToPlayer()
    {
        throw new System.NotImplementedException();
    }
}
