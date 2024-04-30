using Godot;
using System;
using System.Linq;

public partial class PlayerMove : Node2D
{
	[Export]
	float Speed = 100f;

    public static PlayerMove instance;
	
	public override void _Ready()
	{
        if (instance == null)
        {
            instance = this;
        } 
	}

	public override void _Process(double delta)
	{
        Vector2 movementVector = new Vector2();

        if (Input.IsActionPressed("move_right") && GlobalPosition.X < GetWindow().Size.X)
            movementVector.X += 1;
        if (Input.IsActionPressed("move_left") && GlobalPosition.X > 0)
            movementVector.X -= 1;
        if (Input.IsActionPressed("move_down") && GlobalPosition.Y < GetWindow().Size.Y)
            movementVector.Y += 1;
        if (Input.IsActionPressed("move_up") && GlobalPosition.Y > 0)
            movementVector.Y -= 1;

        movementVector = movementVector.Normalized();

        GlobalPosition += movementVector * (float)delta * Speed * 20;
    }
}
