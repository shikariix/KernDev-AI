using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour {

    public Vector3 targetPosition;

    public void SetTargetPosition(Vector3 vector) {
        targetPosition = vector;
    }
}
