using UnityEngine;

public abstract class CustomUIComponent : MonoBehaviour
{
    public void Awake()
    {
        Init();
    }
    protected abstract void Setup();
    protected abstract void Configure();

    protected void Init()
    {
        Setup();
        Configure();
    }
    private void OnValidate()
    {
        
    }
}
