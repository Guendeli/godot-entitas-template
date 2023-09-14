
using System;
using Entitas;
using Godot;

public class PlayerMovementSystem : IExecuteSystem
{
    private readonly GameContext _context;
    private IGroup<GameEntity> _group;
    
    public PlayerMovementSystem(GameContext context)
    {
        _context = context;
        _group = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Position));

    }
    public void Execute()
    {
        foreach (GameEntity playerEntity in _group.GetEntities())
        {
            Oscillate(playerEntity);
        }
    }

    private void Oscillate(GameEntity playerEntity)
    {
        float timeInSec = (Time.GetTicksMsec() / 1000f);
        float variance= Mathf.Cos( timeInSec * 3 / Mathf.Pi);
        playerEntity.ReplacePosition(new Vector3(0,variance,0));
    }
}