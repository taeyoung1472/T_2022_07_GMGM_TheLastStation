using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T>
{
    protected StateMachine<T> stateMachine;
    protected T stateMachineClass;

    public State() { }

    internal void SetMachineWithClass(StateMachine<T> _stateMachine, T _stateMachineClass)
    {
        stateMachine = _stateMachine;
        stateMachineClass = _stateMachineClass;

        OnAwake();
    }
    public virtual void OnAwake() { }
    public virtual void OnStart() { }
    public abstract void OnUpdate(float dealtaTime);
    public virtual void OnEnd() { }
}
public sealed class StateMachine<T>
{
    private T stateMachine;

    private Dictionary<System.Type, State<T>> stateLists = new Dictionary<System.Type, State<T>>();

    private State<T> nowState;
    public State<T> getNowState => nowState;

    private State<T> beforeState;
    public State<T> getBeforeState => beforeState;

    private float stateDurationTime = 0f;
    public float getStateDurationTime => stateDurationTime;

    public StateMachine(T stateMachine, State<T> initState)
    {
        this.stateMachine = stateMachine;

        AddStateList(initState);
        nowState = initState;
        nowState.OnStart();
    }
    public void AddStateList(State<T> state)
    {
        state.SetMachineWithClass(this, stateMachine);
        stateLists[state.GetType()] = state;
    }

    public void Update(float deltaTime)
    {
        stateDurationTime += deltaTime;
        nowState.OnUpdate(deltaTime);
    }
    
    public Q ChangeState<Q>() where Q : State<T> //state<T>만 상속받을 수 있다
    {
        var newType = typeof(Q);

        if (nowState.GetType() == newType)
        {
            return nowState as Q;
        }
        if (nowState != null)
        {
            nowState.OnEnd();
        }
        beforeState = nowState;
        nowState = stateLists[newType];

        nowState.OnStart();
        stateDurationTime = 0f;
        return nowState as Q;
    }
}

