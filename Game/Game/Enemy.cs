﻿using SFML.Graphics;
using SFML.System;
using System;
namespace Game
{
    public class Enemy : GameObject
    {
        public float health { get; set; }

        public override void Start()
        {
            RectangleShape c = new RectangleShape(new Vector2f(10, 10));
            c.FillColor = Color.Magenta;
            drawable = c;

            bounds = new BoundingBox(10, 10);

            health = 100f;   
        }

        public override void Update()
        {
            Vector2f offset = new Vector2f((float)Math.Sin(Time.time), (float)Math.Cos(Time.time * 2));
            Position += offset;
        }
    }
}