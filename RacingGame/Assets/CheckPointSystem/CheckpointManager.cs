using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckpointManager : MonoBehaviour {

	[SerializeField]
	string PlayerTag;
	[SerializeField]
	List<CheckPoint> checkpoints;
	int numberOfCheckpoints = 0;
	public event Action<int> OnLapFinished = delegate {};
	CheckpointList list;
	bool canUpdate = false;
	int actualNumberOfLaps;
    public List<CheckPoint> Checkpoints
    {
        get
        {
            return checkpoints;
        }

        set
        {
            checkpoints = value;
        }
    }

    void Start () {
		if (Checkpoints.Count != 0)
		{
			list = new CheckpointList(Checkpoints);
			canUpdate = true;
			list.deActivateAll();
			list.setNextActive();
		}
	}
	bool shouldGoToNext()
	{
		CheckPoint a = list.getActiveCheckpoint();
		if(a == null) return false;
		if(a.tagOfHit.Equals(PlayerTag))
		{
			a.tagOfHit = "";
			return true;
		}
		return false;
	}
	void updateCheckpoints()
	{
		if(canUpdate && shouldGoToNext())
		{
			list.setNextActive();
			numberOfCheckpoints++;
			OnLapFinishedChecker(numberOfCheckpoints);
		}
	}

	void OnLapFinishedChecker(int numberOfCheckpoints)
	{
		int n = numberOfCheckpoints/checkpoints.Count;
		if(n > actualNumberOfLaps)
		{
			actualNumberOfLaps = n;
			OnLapFinished(actualNumberOfLaps);
		}
		
	}

	void Update () {
		updateCheckpoints();
	}
}


