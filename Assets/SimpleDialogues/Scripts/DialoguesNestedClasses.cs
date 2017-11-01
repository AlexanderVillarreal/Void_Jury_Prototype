using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Dialogues : MonoBehaviour
{
	[System.Serializable]
	public class WindowSet
	{
		public int CurrentId;
		public bool NewWindowOpen;
		public Window FirstWindow;
		public List<Window> Windows = new List<Window>();

		public WindowSet() { CurrentId = 0; NewWindowOpen = false; }

		public Window GetWindow(int ID)
		{
			for (int i = 0; i < Windows.Count; i++)
			{
				if (Windows[i].ID == ID)
					return Windows[i];
			}
			return null;
		}
	}


	[System.Serializable]
	public class Window
	{
		//Holds all the info a Window needs
		public int ID;

		public Rect Size;
		public string Text = "";
		public WindowTypes Type;
		public NodeType NodeType;
		public int Parent;
		public bool Trigger = false;
		public string TriggerText = "";
		public Sprite portrait = null;

		public List<int> Connections = new List<int>();

		public Window(int id, int parent, Rect newSize, WindowTypes type = WindowTypes.Text, 
						NodeType nodeType = NodeType.Default) 
		{ 
			ID = id; 
			Parent = parent; 
			Size = newSize; 
			Type = type; 
			NodeType = nodeType; 
		}

		public bool IsChoice() { if (Type == WindowTypes.Decision) return true; else return false; }
	}
}
