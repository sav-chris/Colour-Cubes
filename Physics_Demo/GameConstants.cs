using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Physics_Demo
{
    static class GameConstants
    {
        // Camera Adjustment Constants
        static public float angleAdjustment = MathHelper.Pi / 90;

        // Movement Constants
        static public int steadyCursorTolerance = 1;
        static public float movementAmount = 2;
        static public float forceRadius = 500.0f;
        static public int numberOfObjects = 50;
        public static float Elasticity = 1.0f;
        public static float maxAirResistance = 1.0f;


        // Tiling constants
        static int length = 400, width = 300, height = 160;
        static public int tileSize = 39;
        static public int xTiles = length / tileSize;
        static public int yTiles = width / tileSize;
        static public int zTiles = height / tileSize;
    }
}