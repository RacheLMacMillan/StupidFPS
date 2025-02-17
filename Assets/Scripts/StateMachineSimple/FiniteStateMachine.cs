using System;
using System.Collections.Generic;

namespace FSM
{
	public class FiniteStateMachine 
	{
		private FiniteStateMachineState CurrentState { get; set; }
		
		private Dictionary<Type, FiniteStateMachineState> _states = new Dictionary<Type, FiniteStateMachineState>();
		
		public void AddState(FiniteStateMachineState state)
		{
			_states.Add(state.GetType(), state);
		}
		
		public void SetState<T>() where T : FiniteStateMachineState
		{
			var type = typeof(T);

			if (CurrentState.GetType() == type)
			{
				return;
			}
			
			if (_states.TryGetValue(type, out var newState))
			{
				CurrentState?.Exit();
				
				CurrentState = newState;
				
				CurrentState.Enter();
			}
		}
		
		public void Update()
		{
			CurrentState?.Update();
		}
	}
}