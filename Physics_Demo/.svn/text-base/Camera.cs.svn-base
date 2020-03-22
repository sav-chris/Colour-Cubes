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

namespace Physics_Demo
{
    class Camera
    {

        //Camera/View information
        Vector3 cameraPosition = new Vector3(0.0f, 50.0f, 50.0f);
        Vector3 cameraFocusOn = new Vector3(0.0f, 50.0f, 51.0f);
        Matrix viewMatrix;
        Matrix projectionMatrix;
        
        // viewElevation is how high or low we are looking, viewAngle is the horizontal angle
        float viewElevation = 0, viewAngle;

        public Vector3 CameraPosition
        {
            get
            {
                return cameraPosition;
            }
            set
            {
                cameraPosition = value;
            }
        }

        public Vector3 CameraFocusOn
        {
            get
            {
                return cameraFocusOn;
            }
            set
            {
                cameraFocusOn = value;
            }
        }

        public Matrix ViewMatrix
        {
            get
            {
                return viewMatrix;
            }
            set
            {
                viewMatrix = value;
            }
        }

        public Matrix ProjectionMatrix
        {
            get
            {
                return projectionMatrix;
            }
            set
            {
                projectionMatrix = value;
            }
        }

        public float ViewElevation
        {
            get
            {
                return viewElevation;
            }
            set
            {
                viewElevation = value;
            }
        }

        public float ViewAngle
        {
            get
            {
                return viewAngle;
            }
            set
            {
                viewAngle = value;
            }
        }

        public void LookUp()
        {
            viewElevation = (viewElevation + GameConstants.angleAdjustment) % MathHelper.TwoPi;
        }

        public void LookDown()
        {
            viewElevation = (viewElevation - GameConstants.angleAdjustment) % MathHelper.TwoPi;
        }

        public void LookLeft()
        {
            viewAngle = viewAngle - GameConstants.angleAdjustment;
            if (viewAngle < ((-1) * MathHelper.Pi))
            {
                viewAngle += MathHelper.TwoPi;
            }
        }

        public void LookRight()
        {
            viewAngle = viewAngle + GameConstants.angleAdjustment;
            if (viewAngle > MathHelper.Pi)
            {
                viewAngle -= MathHelper.TwoPi;
            }
        }

        public void MoveForward()
        {
            Vector3 moveDirection = new Vector3(cameraFocusOn.X - cameraPosition.X, 0, cameraFocusOn.Z - cameraPosition.Z);
            moveDirection.Normalize();
            cameraPosition += moveDirection * GameConstants.movementAmount;
            cameraFocusOn += moveDirection * GameConstants.movementAmount;
        }

        public void MoveBackward()
        {
            Vector3 moveDirection = new Vector3(cameraFocusOn.X - cameraPosition.X, 0, cameraFocusOn.Z - cameraPosition.Z);
            moveDirection.Normalize();
            cameraPosition -= moveDirection * GameConstants.movementAmount;
            cameraFocusOn -= moveDirection * GameConstants.movementAmount;
        }

        public void MoveLeft()
        {
            Vector3 moveDirection = new Vector3(cameraFocusOn.X - cameraPosition.X, 0, cameraFocusOn.Z - cameraPosition.Z);
            moveDirection = Vector3.Cross(moveDirection, Vector3.Up);
            moveDirection.Normalize();
            cameraPosition -= moveDirection * GameConstants.movementAmount;
            cameraFocusOn -= moveDirection * GameConstants.movementAmount;
        }

        public void MoveRight()
        {
            Vector3 moveDirection = new Vector3(cameraFocusOn.X - cameraPosition.X, 0, cameraFocusOn.Z - cameraPosition.Z);
            moveDirection = Vector3.Cross(moveDirection, Vector3.Up);
            moveDirection.Normalize();
            cameraPosition += moveDirection * GameConstants.movementAmount;
            cameraFocusOn += moveDirection * GameConstants.movementAmount;
        }

        public void UpdateCamera()
        {
            // Horizontal viewpoint:
            float xOffset = (float)Math.Cos((double)viewAngle);
            float zOffset = (float)Math.Sin((double)viewAngle);

            // Vertical viewpoint:
            float yOffset = (float)Math.Sin((double)viewElevation);

            // Aim camera
            cameraFocusOn.X = cameraPosition.X + xOffset;
            cameraFocusOn.Z = cameraPosition.Z + zOffset;
            cameraFocusOn.Y = cameraPosition.Y + yOffset;
        }
    }
}
