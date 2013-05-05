﻿using System;
using System.Collections.Generic;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SpoidaGamesArcadeLibrary.Resources.Entities
{
    public class BasketballManager
    {
        private Random random = new Random();

        public static Dictionary<BasketballTypes, Basketball> basketballs = new Dictionary<BasketballTypes, Basketball>();
        public static Dictionary<int, Texture2D> lockedBasketballTextures = new Dictionary<int, Texture2D>();
        public static Dictionary<int, BasketballTypes> basketballSelection = new Dictionary<int, BasketballTypes>();

        private static Basketball selectedBasketball;
        public static Basketball SelectedBasketball
        {
            get { return selectedBasketball; }
            set { selectedBasketball = value; }
        }

        public void SelectBasketball(BasketballTypes type)
        {
            Basketball selectedBall;
            if (basketballs.TryGetValue(type, out selectedBall))
            {
                SelectedBasketball = selectedBall;
            }
            else
            {
                selectedBasketball = basketballs[0];
            }
        }

        private Body basketballBody;
        public Body BasketballBody
        {
            get { return basketballBody; }
        }
        
        public BasketballManager(ContentManager content)
        {
            basketballBody = BodyFactory.CreateCircle(PhysicalWorld.World, 32f / (2f * PhysicalWorld.MetersInPixels), 1.0f, new Vector2((random.Next(370, 1230)) / PhysicalWorld.MetersInPixels, (random.Next(310, 680)) / PhysicalWorld.MetersInPixels));
            basketballBody.BodyType = BodyType.Dynamic;
            basketballBody.Restitution = 0.3f;
            basketballBody.Friction = 0.1f;
            LoadBasketballs(content);
            LoadLockedBasketballs(content);
        }

        private static void LoadBasketballs(ContentManager content)
        {
            basketballs.Add(BasketballTypes.RedGlowBall, new Basketball(content.Load<Texture2D>(@"Textures/Basketballs/RedGlowBall"), new List<Rectangle> {new Rectangle(0, 0, 64, 64)}, false, "Red Glow Ball"));
            basketballs.Add(BasketballTypes.SlimeBall, new Basketball(content.Load<Texture2D>(@"Textures/Basketballs/SlimeBall"), new List<Rectangle> { new Rectangle(0,0,96,96) }, false, "Green Slime Ball"));
            basketballs.Add(BasketballTypes.RedSlimeBall, new Basketball(content.Load<Texture2D>(@"Textures/Basketballs/RedSlimeBall"), new List<Rectangle> { new Rectangle(0, 0, 96, 96) }, false, "Red Slime Ball"));
            basketballs.Add(BasketballTypes.BlueSlimeBall, new Basketball(content.Load<Texture2D>(@"Textures/Basketballs/BlueSlimeBall"), new List<Rectangle> { new Rectangle(0, 0, 96, 96) }, false, "Blue Slime Ball"));
            basketballs.Add(BasketballTypes.PurpleSkullBall, new Basketball(content.Load<Texture2D>(@"Textures/Basketballs/PurpleSkull"), new List<Rectangle> { new Rectangle(0, 0, 64, 64), new Rectangle(64, 0, 64, 64) }, true, "Purple Skull Ball"));
            basketballs.Add(BasketballTypes.BrokenPlanet, new Basketball(content.Load<Texture2D>(@"Textures/Basketballs/BrokenPlanet"), new List<Rectangle> { new Rectangle(0, 0, 64, 64) }, false, "Broken Planet"));
            basketballs.Add(BasketballTypes.ThatsNoMoon, new Basketball(content.Load<Texture2D>(@"Textures/Basketballs/ThatsNoMoon"), new List<Rectangle> { new Rectangle(0, 0, 64, 64) }, false, "That's No Moon!"));
            basketballs.Add(BasketballTypes.EarthDay, new Basketball(content.Load<Texture2D>(@"Textures/Basketballs/EarthDay"), new List<Rectangle> { new Rectangle(0, 0, 36, 36) }, false, "Earth Day"));
            basketballs.Add(BasketballTypes.CuteInPink, new Basketball(content.Load<Texture2D>(@"Textures/Basketballs/CuteInPink"), new List<Rectangle> {new Rectangle(0, 0, 96, 96)}, false, "Cute In Pink"));
        }

        private static void LoadLockedBasketballs(ContentManager content)
        {
            lockedBasketballTextures.Add(0, content.Load<Texture2D>(@"Textures/Basketballs/Locked"));
        }
    }

    public enum BasketballTypes
    {
        RedGlowBall,
        SlimeBall,
        PurpleSkullBall,
        RedSlimeBall,
        BlueSlimeBall,
        BrokenPlanet,
        ThatsNoMoon,
        EarthDay,
        CuteInPink,
    }
}
