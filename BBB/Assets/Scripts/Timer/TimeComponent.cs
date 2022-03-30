using UnityEngine;

public abstract class TimeComponent<TComponent, TSnapshot> : TimeComponentBase where TComponent : Component where TSnapshot : struct
{
    private TComponent _component;
    private TSnapshot _snapshot;
    private float _lastTimeScale = 1F, _lastPositiveTimeScale = 1F;

    protected abstract TSnapshot TakeSnapshot();
    protected abstract void ApplySnapshot(TSnapshot snapshot, float scaleRatio);

    private void Awake()
    {
        _component = GetComponent<TComponent>();
    }

    public override void Apply(float timeScale)
    {
		if (timeScale > 0F)
		{
			float scaleRatio = timeScale / _lastPositiveTimeScale;
			_lastPositiveTimeScale = timeScale;

			if (_lastTimeScale > 0F)
				_snapshot = TakeSnapshot();
			ApplySnapshot(_snapshot, scaleRatio);
		}
		else if (_lastTimeScale > 0F)
		{
			_snapshot = TakeSnapshot();
			ApplySnapshot(new TSnapshot(), 1F);			
		}

		_lastTimeScale = timeScale;
    }

    protected TComponent Component => _component;
    protected float TimeScale => _lastTimeScale;
}