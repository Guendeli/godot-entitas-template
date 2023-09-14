﻿
using System.Collections.Generic;
using Entitas;
using Godot;

public class PlayerRenderInitSystem : ReactiveSystem<GameEntity>
{
    private readonly GameContext _context;
    private const string PREFAB_NAME = "res://src/Prefabs/player.tscn";
    public PlayerRenderInitSystem(IContext<GameEntity> context) : base(context)
    {
        _context = (GameContext)context;
    }



    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Player.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.isPlayer;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity playerEntity in entities)
        {
            Node rootScene = _context.scene.Root;
            if (rootScene != null)
            {
                Node player = GD.Load<PackedScene>(PREFAB_NAME).Instance() as Node;
                if (player != null)
                {
                    rootScene.AddChild(player);
                    playerEntity.AddView(player);
                }
            }
            
        }
    }
}

public class PlayerPositionApplySystem : IExecuteSystem
{
    private readonly GameContext _context;
    private IGroup<GameEntity> _group;

    public PlayerPositionApplySystem(GameContext context)
    {
        _context = context;
        _group = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.Position));

    }
    public void Execute()
    {
        foreach (GameEntity entity in _group.GetEntities())
        {
            Spatial gameObject = (Spatial)entity.view.GameObject;
            if (gameObject == null)
                continue;

            gameObject.Translation = entity.position.Position;
        }
    }
}