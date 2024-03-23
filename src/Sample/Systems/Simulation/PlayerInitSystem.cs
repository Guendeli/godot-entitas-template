
using Entitas;
using Godot;

public partial class PlayerInitSystem : IInitializeSystem
{
    private readonly GameContext _context;

    public PlayerInitSystem(GameContext context)
    {
        _context = context;
    }
    public void Initialize()
    {
        GameEntity playerEntity = _context.CreateEntity();
        playerEntity.isPlayer = true;
        playerEntity.AddPosition(Vector3.Zero);
    }
}