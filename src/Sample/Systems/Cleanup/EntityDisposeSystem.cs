
using Entitas;

public class EntityDisposeSystem : ICleanupSystem
{
    private readonly GameContext _context;
    private IGroup<GameEntity> _group;
    
    public EntityDisposeSystem(GameContext context)
    {
        _context = context;
        _group = _context.GetGroup(GameMatcher.AllOf(GameMatcher.Dispose));
    }
    public void Cleanup()
    {
        foreach (GameEntity entity in _group.GetEntities())
        {
            if (entity.hasView && entity.view.GameObject != null)
            {
                entity.view.GameObject.QueueFree();
            }
            
            entity.Destroy();
        }
    }
}