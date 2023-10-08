using System;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

public interface ICondition
{
    public object             Info       { set; }
    public bool               IsSuitable { get; }
    public Action<ICondition> OnSuitable { set; }
    public void ResetCondition();
}

public interface IHandle
{
    public object Info { set; }
    public void Handle();
}



public class Skills : MonoBehaviour
{
    public string skillName;

    protected List<ICondition> conditions = new List<ICondition>();
    protected List<IHandle>    handles    = new List<IHandle>();

    private void Start()
    {
        GetSkillData();
    }

    protected virtual void GetSkillData()
    {
        var json = JSON.Parse(Resources.Load<TextAsset>($"Data/Skills/{skillName}").text);
        var jsonConditions = json["data"]["conditions"].AsArray;
        var jsonHandles = json["data"]["handles"].AsArray;

        InitConditionsData(jsonConditions);

        InitHandlesData(jsonHandles);

    }

    private void InitHandlesData(JSONArray jsonHandles)
    {
        var dataHandles = Utils.GetSubEffectInfos(jsonHandles);
        foreach (var handleInfo in dataHandles)
        {
            var handle = (IHandle)gameObject.AddComponent(handleInfo.type);
            handle.Info = handleInfo.data;
            handles.Add(handle);
        }
    }
    
    private void InitConditionsData(JSONArray jsonConditions)
    {
        var dataConditions = Utils.GetSubEffectInfos(jsonConditions);
        foreach (var conditionInfo in dataConditions)
        {
            var condition = (ICondition)gameObject.AddComponent(conditionInfo.type);
            condition.Info       = conditionInfo.data;
            condition.OnSuitable = OnSuitable;
            conditions.Add(condition);
        }
    }
    
    private void OnSuitable(ICondition condition)
    {
        if (!CheckConditions()) return;
        foreach (ICondition condition1 in conditions)
        {
            condition1.ResetCondition();
        }
        foreach (IHandle handle in handles)
        {
            handle.Handle();
        }
    }
    private bool CheckConditions()
    {
        foreach(ICondition condition in conditions)
        {
            if (!condition.IsSuitable) return false;
        }
        return true;
    }
}