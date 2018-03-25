using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherBehavior : MonoBehaviour {

    private Node root;
    private Dictionary<string, object> dataStore;
    private bool done;

    private void Awake() {
        dataStore = new Dictionary<string, object>();
        done = false;

        Selector selector = new Selector();

        /* Commenting out for a sec to test
        //branch one: if prey is close and hasn't detected archer, get ready to shoot
        Sequence shootPrey = new Sequence();
        shootPrey.AddNode(new PreyNear());
        Node isSeen = new IsSeen();
        Invert notSeen = new Invert(isSeen);
        shootPrey.AddNode(notSeen);
        shootPrey.AddNode(new PickTarget());
        shootPrey.AddNode(new AimAtTarget());
        shootPrey.AddNode(new ShootTarget());
        //Node targetHit; 

        selector.AddNode(shootPrey);


        //branch two: run away from herd
        Sequence flee = new Sequence();
        flee.AddNode(isSeen);
        flee.AddNode(new PickPosition());
        flee.AddNode(new GeneratePath());
        flee.AddNode(new RunToPosition());

        selector.AddNode(flee);
        */

        //branch three: walk to another location to look for the herd
        Sequence scout = new Sequence();
        scout.AddNode(new PickPosition());
        //scout.AddNode(new GeneratePath());
        scout.AddNode(new WalkToLocation());

        selector.AddNode(scout);

        root = selector;
    }

    void Update() {
        if (done) return;
        Node.Result result = root.Process(dataStore);
        if (result != Node.Result.RUNNING) {
            done = true;
            Debug.Log("Result " + result);
        }
    }

}
