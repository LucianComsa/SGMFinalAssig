using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckpointList {

	List<CheckPoint> checkpoints;
	int indexOfActive = -1;

	public CheckpointList()
	{
		checkpoints = new List<CheckPoint>();
	}

	public CheckpointList(List<CheckPoint> list)
	{
		checkpoints = list;
	}

	public CheckPoint getCheckpoint(int index)
	{
		if (index > 0 && index < checkpoints.Count) return checkpoints[index];
		return null;
	}
	public CheckPoint getActiveCheckpoint()
	{
		if (indexOfActive == -1) return null;
		return checkpoints[indexOfActive];
	}

	public int getActiveCheckpointIndex()
	{
		return indexOfActive;
	}

	public void setNextActive()
	{
		if(indexOfActive >= 0 && indexOfActive < checkpoints.Count)
		{
			checkpoints[indexOfActive].isActive = false;
		}
		indexOfActive += 1;
		if(indexOfActive < 0 || indexOfActive >= checkpoints.Count)
		{
			indexOfActive = 0;
		}
		checkpoints[indexOfActive].isActive = true;
	}
	public void deActivateAll()
	{
		for(int i = 0; i < checkpoints.Count; i++)
		{
			checkpoints[i].isActive = false;
		}
	}
	public void ActivateAll()
	{
		for(int i = 0; i < checkpoints.Count; i++)
		{
			checkpoints[i].isActive = true;
		}
	}

}
