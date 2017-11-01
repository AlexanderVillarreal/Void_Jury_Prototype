using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public partial class Dialogues : MonoBehaviour {

    [HideInInspector]
    //public DialogueSystem.Window StartWindow = null;

    Window Current;

    //Enums
    public enum WindowTypes { Text, Decision, Option }
    public enum NodeType { Start, Default, End }

    [HideInInspector]
    public List<WindowSet> Set = new List<WindowSet>();

    [HideInInspector]
    public int CurrentSet = 0;

    [HideInInspector]
    public List<string> TabList = new List<string>();

	public int choiceCount { get { return GetChoices ().Length; } }
	public bool hasChoices { get { return GetChoices ().Length > 0; } }


    /// <summary>
    /// Set the current node back to the beginning.
    /// </summary>
    /// <returns></returns>
    public string Reset()
    {
        if(CurrentSet < Set.Count)
        Current = Set[CurrentSet].FirstWindow;
		
        if (Current == null)
            return "";
        return Current.Text;
    }

   
    /// <summary>
    /// Sets the current tree to be used.
    /// </summary>
    /// <param name="TreeName"></param>
    /// <returns></returns>
    public bool SetTree(string TreeName)
    {
        for (int i = 0; i < Set.Count; i++)
        {
            if (TabList[i] == TreeName)
            {
                CurrentSet = i;
                Reset();
                return true;
            }
        }
        return false;
    }

    public string GetCurrentTree()
    {
        return TabList[CurrentSet];
    }

    /// <summary>
    /// Returns if you're at the end of the dialogue tree.
    /// </summary>
    /// <returns></returns>
    public bool End()
    {
        if (Current.Connections.Count == 0)
            return true;
        else
            return false;
    }
    
    /// <summary>
    /// Checks if the current window has a trigger.
    /// </summary>
    /// <returns></returns>
    public bool HasTrigger()
    {
        return Current.Trigger;
    }

    /// <summary>
    /// Returns any trigger text this current window might have.
    /// </summary>
    /// <returns></returns>
    public string GetTrigger()
    {
        return Current.TriggerText;
    }

    /// <summary>
    /// Moves to the next item in the list.
    /// </summary>
    /// <returns>True upon successful move to next item, false otherwise</returns>
    public bool Next()
    {
		if (Current.Type == WindowTypes.Decision)
			return false;
		else if (Current.Connections.Count == 0)
			return false;
        else
        {
            Current = Set[CurrentSet].GetWindow(Current.Connections[0]);
			return true;

        }
    }

    /// <summary>
    /// Returns the choices the current node has. 
    /// </summary>
    /// <returns>Null if the node isn't a decision node. An array of strings otherwise.</returns>
    public string[] GetChoices()
    {
        if (Current.Type != WindowTypes.Decision)
            return null;
        else
        {
            List<string> Choices = new List<string>();
            for (int i = 0; i < Current.Connections.Count; i++)
            {
                Choices.Add(Set[CurrentSet].GetWindow(Current.Connections[i]).Text);
            }
            return Choices.ToArray();
        }
    }

    /// <summary>
    /// Moves to the next selected choice
    /// </summary>
    /// <param name="choice"></param>
    /// <returns></returns>
    public bool NextChoice(string choice)
    {
        if (Current.Type != WindowTypes.Decision)
            return false;
        else
        {
            for (int i = 0; i < Current.Connections.Count; i++)
            {
                if (Set[CurrentSet].GetWindow(Current.Connections[i]).Text == choice)
                {
                    Current = Set[CurrentSet].GetWindow(Set[CurrentSet].GetWindow(Current.Connections[i]).Connections[0]);
                    return true;
                }
            }
            return false;
        }
    }

    public string GetCurrentDialogue()
    {
        if (Current == null)
            Reset();
        return Current.Text;
    }
}
