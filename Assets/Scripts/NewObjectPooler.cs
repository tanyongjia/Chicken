using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewObjectPooler : MonoBehaviour {

	public static NewObjectPooler current;
	public GameObject[] pooledObject;
	public int pooledAmount = 20;
	public bool willGrow = false; //create a new one when no object in pool is available
	
	List<GameObject> pooledObjects;
	int j = 0;
	
	void Awake(){
		current = this;
	}
	
	void Start () {
		pooledObjects = new List<GameObject> ();
		for (int i = 0; i < pooledAmount; i++) {
			GameObject obj = (GameObject)Instantiate(pooledObject[i % 2]);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}
	
	public GameObject GetPooledObject(){
		for (int i = 0; i < pooledObjects.Count; i++) {
			if(!pooledObjects[i].activeInHierarchy){
				return pooledObjects[i];
			}
		}
		
		if (willGrow) {
			GameObject obj = (GameObject)Instantiate(pooledObject[j]);
			pooledObjects.Add(obj);
			j = 1 - j;
			return obj;
		}
		
		return null;
	}
}
