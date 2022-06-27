using System;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Cpu3DEngine
{
    public partial class Form1 : Form
    {
        private const float BehindDistance = 6;
        private const float BehindHeight = 2;
        private const float TargetDistance = 7;

        private readonly Device device;
        private FastBitmap bitmap;

        //shapes
        private readonly Mesh flashlight;
        private readonly Mesh mainSphere;

        //cameras
        private readonly Camera staticCamera;
        private readonly Camera rotatingCamera;
        private readonly Camera followingCamera;

        //lights
        private readonly Light mainLight;
        private readonly Light spotLight;

        //movement
        private double cylinderAngle;
        private double hitAngle;
        private (float X, float Z) sphereSpeed;
        private (float X, float Z) sphereAcceleration;
        private Vector3 sphereTransform;
        private (int X, int Z) direction = (1,1);


        private readonly FogGenerator fogGenerator = new(Color.FromArgb(200, 200, 200), 30);
        Bitmap image;

        public Form1()
        {
            InitializeComponent();
            bitmap = new FastBitmap(pictureBox1.Width, pictureBox1.Height);
            device = new Device(bitmap);

            image = new Bitmap(Directory.GetCurrentDirectory() + "\\arrow.png");
            image = new Bitmap(image, 101, 101);
            image.RotateFlip(RotateFlipType.Rotate90FlipY);

            Mesh[] walls = CreateWalls();

            mainSphere = ShapesGenerator.CreateSphere(2, Color.YellowGreen);
            mainSphere.Translate(4.5f, 0.1f, 0);
            var sphere = ShapesGenerator.CreateSphere(2, Color.Blue);
            sphere.Translate(-4, 0.1f, 0);
            var sphere2 = ShapesGenerator.CreateSphere(2, Color.Red);
            sphere2.Translate(-6f, 0.1f, 1f);
            var sphere3 = ShapesGenerator.CreateSphere(2, Color.Green);
            sphere3.Translate(-6f, 0.1f, -1f);
            sphereTransform = new Vector3(4.5f, 0.1f, 0);

            flashlight = ShapesGenerator.CreateCylinder(10, 1.5, 0.2, Color.Brown);

            var floor = ShapesGenerator.CreateFloor(Color.FromArgb(10, 50, 10));
            floor.Scale(10.5f, 1f, 6);
            floor.Translate(0, -0.5f, 0);

            device.Meshes.Add(flashlight);
            device.Meshes.Add(sphere);
            device.Meshes.Add(sphere2);
            device.Meshes.Add(sphere3);
            device.Meshes.Add(mainSphere);
            device.Meshes.Add(floor);
            foreach (var w in walls) device.Meshes.Add(w);

            mainLight = new Light
            {
                IsSpotlight = false,
                Position = new Vector3(-5, 5, 0),
                Off = false
            };

            spotLight = new Light
            {
                IsSpotlight = true,
                Position = new Vector3(0, 0, 0),
                Off = false,
                Direction = new Vector3(0, 0, 1),
                P = 12
            };

            device.Lights.Add(mainLight);
            device.Lights.Add(spotLight);

            staticCamera = new Camera(new Vector3(0f, 25f, -13f), new Vector3(0, 0, 0), new Vector3(0, 0, -1), 50);
            followingCamera = new Camera(new Vector3(0f, 10f, -20f), new Vector3(0, 0, 0), new Vector3(0, -1, 0), 65);
            rotatingCamera = new Camera(new Vector3(0, BehindHeight, -BehindDistance), new Vector3(0, 0, TargetDistance), new Vector3(0, 0, -1), 65);

            device.activeCamera = staticCamera;
            pictureBox1.Image = bitmap.Bitmap;
        }

        private void UpdateRotatingCamera()
        {
            var xV = Math.Sin(cylinderAngle * Math.PI);
            var zV = Math.Cos(cylinderAngle * Math.PI);

            rotatingCamera.Position = new Vector3((float)(-BehindDistance * xV), BehindHeight*9.5f, (float)(-BehindDistance * zV));
            rotatingCamera.Target = new Vector3((float)(TargetDistance * xV), -8, (float)(TargetDistance * zV));
            rotatingCamera.UpVector = Vector3.Normalize(new Vector3((float)-xV, 0, (float)-zV));
        }

        private Mesh[] CreateWalls()
        {
            var walls = new Mesh[4];
            walls[0] = ShapesGenerator.CreateCube(Color.FromArgb(109, 49, 11));
            walls[1] = ShapesGenerator.CreateCube(Color.FromArgb(109, 49, 11));
            walls[2] = ShapesGenerator.CreateCube(Color.FromArgb(109, 49, 11));
            walls[3] = ShapesGenerator.CreateCube(Color.FromArgb(109, 49, 11));
            walls[0].Translate(0, 0, 12);
            walls[0].Scale(10.2f, 0.5f, 0.5f);
            walls[1].Translate(0, 0, -12);
            walls[1].Scale(10.2f, 0.5f, 0.5f);
            walls[2].Translate(21.2f, 0, 0);
            walls[2].Scale(0.5f, 0.5f, 6.5f);
            walls[3].Translate(-21.2f, 0, 0);
            walls[3].Scale(0.5f, 0.5f, 6.5f);
            return walls;
        }

        private void Follow()
        {
            followingCamera.Target = new Vector3(sphereTransform.X, 0, sphereTransform.Z);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateSphere();
            UpdateRotatingCamera();
            Follow();
            OnMapUpdated();
            bitmap = new FastBitmap(pictureBox1.Width, pictureBox1.Height);
            device.Bitmap = bitmap;
            device.Render();
            pictureBox1.Image = device.Bitmap.Bitmap;
        }

        private void UpdateSphere()
        {
            if (sphereSpeed.X < 0 || sphereSpeed.Z < 0) return;

            mainSphere.Translate(-sphereTransform.X, -0.1f, -sphereTransform.Z);
            mainSphere.Rotate(Axis.Z, -sphereSpeed.X * direction.X);
            mainSphere.Rotate(Axis.X,  sphereSpeed.Z * direction.Z);
            mainSphere.Translate( sphereTransform.X,  0.1f,  sphereTransform.Z);

            if (sphereTransform.X + sphereSpeed.X > 8.7)
            {
                direction = (-1, direction.Z);
            }
            else if (sphereTransform.X + sphereSpeed.X < -8.7)
            {
                direction = (1, direction.Z);
            }
            if (sphereTransform.Z + sphereSpeed.X > 4.5)
            {
                direction = (direction.X, -1);
            }
            else if (sphereTransform.Z + sphereSpeed.X < -4.5)
            {
                direction = (direction.X, 1);
            }
            mainSphere.Translate(sphereSpeed.X*direction.X, 0, sphereSpeed.Z*direction.Z);
            sphereTransform.X += sphereSpeed.X * direction.X;
            sphereTransform.Z += sphereSpeed.Z * direction.Z;
            sphereSpeed.X -= sphereAcceleration.X;
            sphereSpeed.Z -= sphereAcceleration.Z;
            this.Text = GetFps().ToString("0.##") + " FPS";
        }
        DateTime _lastCheckTime = DateTime.Now;
        long _frameCount = 0;

        // called whenever a map is updated
        void OnMapUpdated()
        {
            Interlocked.Increment(ref _frameCount);
        }

        // called every once in a while
        double GetFps()
        {
            double secondsElapsed = (DateTime.Now - _lastCheckTime).TotalSeconds;
            long count = Interlocked.Exchange(ref _frameCount, 0);
            double fps = count / secondsElapsed;
            _lastCheckTime = DateTime.Now;
            return fps;
        }
    }
}



