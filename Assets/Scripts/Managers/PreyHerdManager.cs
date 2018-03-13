using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyHerdManager : MonoBehaviour {

	public int herdSize;
	public Prey preyPrefab;
	
	//public so the behaviour can access it; may need revision
	public List<Prey> herd = new List<Prey>();
	
	private Vector3 offset = Vector3.zero;
	
	void Awake () {
		for (int i = 0; i < herdSize; ++i) {
			Prey temp = Instantiate(preyPrefab, transform.position + offset, Quaternion.identity) as Prey;
			temp.transform.parent = transform;
			herd.Add(temp);
			offset += new Vector3(2, 0, 2);
		}
	}
	
}
