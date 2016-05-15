using UnityEngine;
using System.Collections;
using Image = UnityEngine.UI.Image;

public class HPcontroller : Entity {

	Image Healthbar;
	//float tmpHealth = 1;

	Image Energybar;
	float tmpEnergy = 1;

    float playerhealth = 0;

    // Use this for initialization
    void Start () {
		
		//Healthbar = GameObject.Find ("MainCamera").transform.FindChild ("Canvas").FindChild ("HealthBar").GetComponent<Image>();
		Healthbar = GameObject.FindGameObjectWithTag ("HealthBar").GetComponent<Image>();
		Energybar = GameObject.FindGameObjectWithTag ("EnergyBar").GetComponent<Image>();
        
	}

	// Update is called once per frame
	void Update () {
        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().currentHealth / 100;
		Healthbar.fillAmount = playerhealth;

       // Debug.Log(playerhealth);

		//tmpEnergy = energy/100;
		Energybar.fillAmount = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>().currentEnergy / 100;


    }

	public void changeHealth(float health)

    {

	}
}
