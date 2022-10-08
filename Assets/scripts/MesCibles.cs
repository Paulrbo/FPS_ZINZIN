using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesCibles : MonoBehaviour {
	
  public GameObject[] cibles;
  
  void Start(){
  	  int rand = Random.Range(0, cibles.Length); // int variable that's equal to a random number that has a value of 0 to the amount of game objects in your array
      Instantiate(cibles[rand], transform.position, Quaternion.identity); // identify objects you want to spawn and choose the location of which they will spawn
  }
}
