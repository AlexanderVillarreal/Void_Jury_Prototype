using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// A list of gameobjects does not persist through scenes. So we have to store the clue's information
// in a static list of type ClueInfo (a Struct) in order to be able to access it through scenes.
public struct ClueInfo
{
	public int id;
	public int rating;
	public string clueName;
	public string description;

	// Constructor that passes a ClueItem object by reference
	public ClueInfo (ref ClueItem item)
	{
		id = item.ID;
		rating = item.Rating;
		clueName = item.ClueName;
		description = item.Description;

	}

	// Copy Constructor for ClueInfo
	public ClueInfo (ref ClueInfo clue)
	{
		id = clue.id;
		rating = clue.rating;
		clueName = clue.clueName;
		description = clue.description;
	}
}

public class ClueItem : MonoBehaviour {

	public int id;
	public int rating;
	public string clueName;
	public string description;
	private bool isCollected;

	// copy Constructor
	public ClueItem (ref ClueItem passedClueItem)
	{
		ID = passedClueItem.id;
		Rating = passedClueItem.rating;
		ClueName = passedClueItem.clueName;
		Description = passedClueItem.description;
		IsCollected = passedClueItem.isCollected;
	}

	public ClueItem (int ident, int rate, string cName, string descrip, bool collected)
	{
		ID = ident;
		Rating = rate;
		ClueName = cName;
		Description = descrip;
		IsCollected = collected;
	}

	// Properties to get and set all variables
	public int ID
	{
		get { return id; }
		set { id = value; }
	}

	public int Rating
	{
		get { return rating; }
		set { rating = value; }
	}

	public string ClueName
	{
		get { return clueName; }
		set { clueName = value; }
	}

	public string Description
	{
		get { return description; }
		set { description = value; }
	}

	public bool IsCollected
	{
		get { return isCollected; }
		set { isCollected = value; }
	}
}
