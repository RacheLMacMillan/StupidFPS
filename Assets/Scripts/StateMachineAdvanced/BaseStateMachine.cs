using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStateMachine<EState> : MonoBehaviour where EState : Enum
{
	protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
	
	protected BaseState<EState> CurrentState;
	
	private void Awake()
	{
	}
	
	private void Start()
	{
		CurrentState.EnterState();
	}
	
	private void Update()
	{
		EState nextStateKey = CurrentState.GetNextState();
		
		if (nextStateKey.Equals(CurrentState.StateKey))
		{
			CurrentState.UpdateState();
		}
		else
		{
			TransitionToState(nextStateKey);
		}
	}

	private void TransitionToState(EState stateKey)
	{
		
		
		CurrentState.ExitState();
		CurrentState = States[stateKey];
		CurrentState.EnterState();
	}
}