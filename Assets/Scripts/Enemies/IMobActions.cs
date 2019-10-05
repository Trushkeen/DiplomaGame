using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMobActions
{
    void Attack(GameObject obj);

    void MoveToTarget();

    void Death();
}
