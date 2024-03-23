using Entitas;
using Godot;
using System;

public partial class TickInitializeSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private const int TARGET_FRAME_RATE = 60;
    public TickInitializeSystem(GameContext context)
    {
        _context = context;
    }
    public void Initialize()
    {
        float secondsSinceStartup = GetRealTimeSinceStartup();
        _context.ReplaceCurrentTick((int)secondsSinceStartup * TARGET_FRAME_RATE);
    }
    
    private float GetRealTimeSinceStartup()
    {
        float secondsSinceStartup = (Time.GetTicksMsec() / 1000.0f);

        return secondsSinceStartup;

    }
}

public partial class TickUpdateSystem : IExecuteSystem
{
    private readonly GameContext _context;
    private const float STEP = 16 / 60f;
    
    public TickUpdateSystem(GameContext context)
    {
        _context = context;
    }
    
    public void Execute()
    {
        int currentTick = _context.currentTick.Tick;
        float realtimeSinceStartup = GetRealTimeSinceStartup();
        if (realtimeSinceStartup > currentTick + STEP)
        {
            currentTick++;
            _context.ReplaceCurrentTick(currentTick);
        }

    }
    
    private float GetRealTimeSinceStartup()
    {
        float secondsSinceStartup = (Time.GetTicksMsec() / 1000.0f);

        return secondsSinceStartup;

    }
}