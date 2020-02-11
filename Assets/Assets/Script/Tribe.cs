using UnityEngine.UI;
using UnityEngine;

public class Tribe : MonoBehaviour {

    public int lives;
    public int resources;
    public int resToLifeThreshold;

    public Text livesText, resourcesText;

	void Start () {
        lives = 5;
        resources = 0;
        resToLifeThreshold = 100;

        resourcesText.text = "Resources: " + resources;
        livesText.text = "Lives: " + lives;
    }
	
	public void AddResources(int addition) {
        if (addition < 0 && this.resources + addition < 0) {
            //throw new System.Exception("Not enough resources"); // WTF Cristi ce brutal ești
        } else {
            resources += addition;
            resourcesText.text = "Resources: " + resources;
        }

        CheckNewLife();
    }

    void CheckNewLife() {
        if (this.resources > this.resToLifeThreshold) {

            this.lives += this.resources / this.resToLifeThreshold;
            this.resources %= this.resToLifeThreshold;
            livesText.text = "Lives: " + lives;
        }
    }

    public bool UseLife() {
        lives -= 1;
        livesText.text = "Lives: " + lives;
        return lives > 0;
    }

    void OnTriggerEnter (Collider other) {
        Resource resource = other.GetComponent<Resource>();

        if (resource != null) {
            AddResources(resource.value);
            Destroy(resource.gameObject);
        }
    }
}
