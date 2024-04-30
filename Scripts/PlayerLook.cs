using Godot;
using System;
using System.Linq;

public partial class PlayerLook : Sprite2D
{
    private float startRotation = 0f;

    public override void _Ready()
    {
        startRotation = Rotation;
    }

    public override void _Process(double delta)
    {
        Vector2 _cursorPosition = GetLocalMousePosition();

        Rotation += _cursorPosition.Angle() + startRotation;
        Rotation = Godot.Mathf.Wrap(Rotation, Mathf.DegToRad(-360), Mathf.DegToRad(360));

        //var fps = Engine.GetFramesPerSecond();
        //GD.Print(fps);


        ////Point player towards the cursor
        //var mousePosition = GetGlobalMousePosition();
        ////var offset = new Vector2(Texture.GetWidth() / 2, Texture.GetHeight() / 2);

        ////Get the parent node
        ////var parent = GetParent<Node2D>();


        ////calculate rotation to mouse in radians
        //var angle = Mathf.Atan2(mousePosition.Y - (GlobalPosition.Y/* + offset.Y*/), mousePosition.X - (GlobalPosition.X/* + offset.X*/));
        //Rotation = angle + 90;
        //Console.Write(angle.ToString());
    }

}
