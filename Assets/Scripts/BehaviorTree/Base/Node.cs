using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node {

    public enum Result {
        SUCCESS,
        FAILURE,
        RUNNING
    }

    public abstract void Init();
    public abstract Result Process(Dictionary<string, System.Object> dataStore);

}
