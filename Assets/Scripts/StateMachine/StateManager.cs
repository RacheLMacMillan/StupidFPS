using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
	public BaseState<EState> CurrentState { get; protected set; }
	
	protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
	
	protected bool IsTransitioningState = false;
	
	
	private void Start()
	{
		CurrentState.EnterState();
	}
	
	private void Update()
	{
		EState nextStateKey = CurrentState.GetNextState();
	
		if (!IsTransitioningState && nextStateKey.Equals(CurrentState.StateKey))
		{
			CurrentState.UpdateState();
		}
		else if (!IsTransitioningState)
		{
			TransitionToState(nextStateKey);
		}
		
		CurrentState.UpdateState();
	}
	
	private void TransitionToState(EState stateKey)
	{
		IsTransitioningState = true;
		
		CurrentState.ExitState();
		
		CurrentState = States[stateKey];
		
		CurrentState.EnterState();
		
		IsTransitioningState = false;
	}
}