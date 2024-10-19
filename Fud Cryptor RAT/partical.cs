using System;
using System.Drawing;

public class Particle
{
    public PointF Position { get; set; }
    public float Speed { get; set; }
    public float Size { get; set; }
    public Color Color { get; set; }

    public Particle(PointF position, float speed, float size, Color color)
    {
        Position = position;
        Speed = speed;
        Size = size;
        Color = color;
    }

    public void Update(float deltaTime, float formHeight)
    {
        Position = new PointF(Position.X, Position.Y + Speed * deltaTime);
        if (Position.Y > formHeight)
        {
            Position = new PointF(Position.X, 0);
        }
    }

    public void Draw(Graphics g)
    {
        using (Brush brush = new SolidBrush(Color))
        {
            g.FillEllipse(brush, Position.X - Size / 2, Position.Y - Size / 2, Size, Size);
        }
    }
}