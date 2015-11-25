using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Risk_World_Conquest
{
    class Camara
    {
            public static GraphicsDeviceManager gDevManager;
            public static float worldWidth { private set; get; }
            public static float ratio { private set; get; }
            private static Vector2 target;
            private static int lastSeenPixelWidth = 0;

            public static void SetGraphicsDeviceManager(GraphicsDeviceManager gdm)
            {
                Camara.gDevManager = gdm;
            }

            public static void SetWorldWidth(float w)
            {
                Camara.worldWidth = w;
                Camara.ratio = Camara.gDevManager.PreferredBackBufferWidth /
                Camara.worldWidth;
            }

            public static void SetTarget(Vector2 target)
            {
                Camara.target = target;
            }

            private static void UpdateRatio()
            {
                if (Camara.lastSeenPixelWidth !=
                    Camara.gDevManager.PreferredBackBufferWidth)
                {
                    Camara.ratio = Camara.gDevManager.PreferredBackBufferWidth /
                        Camara.worldWidth;
                    Camara.lastSeenPixelWidth = Camara.gDevManager.PreferredBackBufferWidth;
                }
            }

            public static Vector2 WorldPoint2Pixels(Vector2 point)
            {
                Camara.UpdateRatio();
                Vector2 pixelPoint = new Vector2();

                // Calcular pixeis em relacao ao target da camara (centro)
                pixelPoint.X = (int)((point.X - target.X) * Camara.ratio + 0.5f);
                pixelPoint.Y = (int)((point.Y - target.Y) * Camara.ratio + 0.5f);

                // protetar pixeis calculados para o canto inferior esquerdo do ecra
                pixelPoint.X += Camara.lastSeenPixelWidth / 2;
                pixelPoint.Y += Camara.gDevManager.PreferredBackBufferHeight / 2;

                // inverter coordenadas Y
                pixelPoint.Y = Camara.gDevManager.PreferredBackBufferHeight - pixelPoint.Y;

                return pixelPoint;
            }

            public static Rectangle WorldSize2PixelRectangle(Vector2 pos, Vector2 size)
            {
                Camara.UpdateRatio();

                Vector2 pixelPos = WorldPoint2Pixels(pos);
                int pixelWidth = (int)(size.X * Camara.ratio + .5f);
                int pixelHeight = (int)(size.Y * Camara.ratio + .5f);

                return new Rectangle((int)pixelPos.X, (int)pixelPos.Y, pixelWidth, pixelHeight);
            }

            public static Vector2 GetTarget()
            {
                return Camara.target;
            }
        }

}
