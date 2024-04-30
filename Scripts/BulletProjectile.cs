using Godot;
using System;

public partial class BulletProjectile : Node2D
{

    [Export] private float damage = 10f;
    [Export] private float speed = 5f;

    [Export] private PlayerMove player;

    private int immunity = 240;

    public Vector2 moveDirection = Vector2.Zero;

    public float Damage { get => damage; set => damage = value; }
    public float Speed { get => speed; set => speed = value; }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
        player = PlayerMove.instance;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
    {
        //GlobalPosition += moveDirection * Speed;
        //moveDirection = moveDirection.Normalized();
        MoveBullet(delta);
        BounceBulletWithinScreen();
        CheckCollision(player);
        if (immunity > 0)
        {
            immunity--;
        }
        
        //GD.Print(GlobalPosition);
    }

    public void BounceBulletWithinScreen()
    {
        //if bullet is at the edge of the screen make it bounce
        if (GlobalPosition.X < 0 || GlobalPosition.X > GetWindow().Size.X)
        {
            // Check if the bullet should bounce towards the player
            if (GD.Randf() < 0.001f) // 1 in 1000 chance
            {
                // Calculate direction towards the player
                Vector2 directionToPlayer = (player.GlobalPosition - GlobalPosition).Normalized();
                // Set the move direction to the direction towards the player
                moveDirection = directionToPlayer;
            }
            else
            {
                moveDirection.X *= -1;
            }
        }

        if (GlobalPosition.Y < 0 || GlobalPosition.Y > GetWindow().Size.Y)
        {
            // Check if the bullet should bounce towards the player
            if (GD.Randf() < 0.001f) // 1 in 1000 chance
            {
                // Calculate direction towards the player
                Vector2 directionToPlayer = (player.GlobalPosition - GlobalPosition).Normalized();
                // Set the move direction to the direction towards the player
                moveDirection = directionToPlayer;
            }
            else
            {
                moveDirection.Y *= -1;
            }
        }
    }


    private void MoveBullet(double delta)
    {
        Position += (moveDirection * (float)delta * speed);
    }

    private void CheckCollision(PlayerMove player)
    {
        if (GlobalPosition.DistanceTo(player.GlobalPosition) < 50 && immunity == 0)
        {
            GameManager.instance.GameOver();
        }
    }
}
