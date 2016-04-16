using UnityEngine;
using System.Collections;

public class Location : MonoBehaviour {

	//world cords
	private Vector2 worldCord2D;

	//Zone
	private ZoneTypes zone;
	public enum ZoneTypes{
		A,
		B,
		C,
		None
	}


	public Vector2 WorldCord2D{
		get { return worldCord2D; }
	}

	public ZoneTypes Zone{
		get { return zone; }
	}


	public Location(Vector2 worldCord2D){
		this.worldCord2D = worldCord2D;
		zone = ZoneTypes.None;
	}

	public Location(ZoneTypes zone){
		worldCord2D = Vector2.zero;
		this.zone = zone;
	}

	public bool Compare(Location location)	{
		if (worldCord2D != Vector2.zero && location.worldCord2D == worldCord2D){
			return true;
		}
		else if (zone != ZoneTypes.None && location.zone == zone){
			return true;
		}
		else
			return false;
	}

}
