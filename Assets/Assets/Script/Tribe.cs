using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tribe : MonoBehaviour {

    public int lives;
    public int resources;
    public int resToLifeThreshold;
    public Vector3 spawnPoint;

	void Start () {
        lives = 5;
        resources = 0;
        resToLifeThreshold = 100;
	}
	
	public void AddResources(int addition) {
        if(addition < 0 && this.resources + addition < 0) {
            throw new System.Exception("Not enough resources");
        }
        this.resources += addition;

        CheckNewLife();
    }

    void CheckNewLife() {
        if (this.resources > this.resToLifeThreshold) {

            this.lives += this.resources / this.resToLifeThreshold;
            this.resources %= this.resToLifeThreshold;
        }
    }

    public bool UseLife() {
        if (lives > 0) {
            this.lives -= 1;
            return true;
        }

        return false;
    }
}
