using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node {

    public abstract void Init(Hashtable data);
    public abstract Result Process();

}

public enum Result {
    SUCCESS,
    FAILURE,
    RUNNING
}
