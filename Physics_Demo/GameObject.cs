using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using PhysicsEngine;

namespace Physics_Demo
{
    class GameObject
    {
        class GameEntity : DefaultEntity
        {
            static Random r = new Random(System.DateTime.Now.Millisecond);
            static float RandomMass()
            {
                return (float)r.NextDouble() * 20.0f + 5.0f;
            }
            
            static float RandomAirResistance()
            {
                return GameConstants.maxAirResistance;
            }
            
            static Vector3 RandomVector()
            {
                float x = GameConstants.forceRadius * (float)r.NextDouble() - (GameConstants.forceRadius / 2);
                float y = GameConstants.forceRadius * (float)r.NextDouble() - (GameConstants.forceRadius / 2);
                float z = GameConstants.forceRadius * (float)r.NextDouble() - (GameConstants.forceRadius / 2);
                return new Vector3(x, y, z);
            }
            
            Vector3 RandomVelocity()
            {
                float x = 100.0f * (float)r.NextDouble() - 50.0f;
                float y = 100.0f * (float)r.NextDouble() - 50.0f;
                float z = 100.0f * (float)r.NextDouble() - 50.0f;
                return new Vector3(x, y, z);
            }
            
            public GameEntity(float radius, Hull hull, PhysicsEngine.Environment enviroment)
                : base(RandomVector(), RandomVector(), RandomMass(), radius, hull, new ElasticCollision(GameConstants.Elasticity), enviroment, RandomAirResistance())
            {
                this.Velocity = RandomVelocity();
            }
            
            public override Vector3  Force()
            {
                if (Position.LengthSquared() > GameConstants.forceRadius * GameConstants.forceRadius)
                {
                    return -1 * this.Position;
                }
                else
                {
                    return base.AirResistance();
                }
            }
        }
        
        // When the object is created, it needs to be added to the physics engine under physicsReference
        Model objectModel;
        Entity physicsReference;
        Matrix[] transforms;

        public Model ObjectModel
        {
            get
            {
                return objectModel;
            }
            set
            {
                objectModel = value;
            }
        }

        public Matrix[] Transforms
        {
            get
            {
                return transforms;
            }
            set
            {
                transforms = value;
            }
        }

        public GameObject(float radius, ConvexSegment hull, PhysicsEngine.Environment environment, Model model, Matrix[] transforms)
        {
            ConvexHull[] hulls = new ConvexHull[] { new ConvexHull(hull, Matrix.Identity) };
            physicsReference = new GameEntity(radius, new Hull(hulls), environment);
            environment.Add(physicsReference);
            this.objectModel = model;
            this.transforms = transforms;
        }

        public void Draw(Camera camera, float aspectRatio)
        {
            Matrix tempTransforms = physicsReference.Transform; 
            CommonFunctions.DrawModel(objectModel, tempTransforms, transforms, camera, aspectRatio);
        }

        public void Update()
        {
            
        }
    }
}
