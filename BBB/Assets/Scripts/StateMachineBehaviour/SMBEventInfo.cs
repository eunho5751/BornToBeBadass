using UnityEngine;

public struct SMBEventInfo
{
    [SerializeField]
    private string _functionName;
    [SerializeField]
    private IEventParameter _parameter;

    public string FunctionName => _functionName;
    public IEventParameter Parameter => _parameter;
}
