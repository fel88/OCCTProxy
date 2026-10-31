using OCCTProxy.Common.Interfaces;
using OpenTK.GLControl;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CascadeDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();



            glcontrol = new GLControl(new GLControlSettings()
            {
                Profile = OpenTK.Windowing.Common.ContextProfile.Compatability,

                NumberOfSamples = 4,
                StencilBits = 8,

            });


            glcontrol.MouseMove += gPanel1_MouseMove;
            glcontrol.MouseUp += gPanel1_MouseUp;
            glcontrol.MouseDown += gPanel1_MouseDown;


            glcontrol.MouseWheel += gPanel1_MouseWheel;
            Shown += Form1_Shown;

            panel1.Controls.Add(glcontrol);
            glcontrol.Dock = DockStyle.Fill;
            
            glcontrol.Load += Glcontrol_Load;
            glcontrol.Resize += Panel1_Resize;
            FormClosing += Form1_FormClosing;


            SizeChanged += Form1_SizeChanged;
            Paint += Form1_Paint;


        }

        private void Panel1_Resize(object? sender, EventArgs e)
        {
            proxy?.Resize(panel1.Width, panel1.Height);
        }

     

        [DllImport("opengl32.dll")]
        public static extern IntPtr wglGetCurrentContext();

        nint? hglrc;
        bool inited = false;


        private void Glcontrol_Load(object? sender, EventArgs e)
        {
            inited = true;
        }

        private void Form1_FormClosing(object? sender, FormClosingEventArgs e)
        {
            proxy.cleanup();
        }

        GLControl glcontrol;


        private void gPanel1_MouseWheel(object? sender, MouseEventArgs e)
        {
            Point cursorPosition = System.Windows.Forms.Cursor.Position;

            var pos = panel1.PointToClient(cursorPosition);

            proxy?.MouseScroll(pos.X, pos.Y, e.Delta);
        }

        private void gPanel1_MouseDown(object? sender, MouseEventArgs e)
        {
            Point cursorPosition = System.Windows.Forms.Cursor.Position;

            var pos = glcontrol.PointToClient(cursorPosition);
            int btn = 1;
            if (e.Button == MouseButtons.Right)
                btn = 3;
            if (e.Button == MouseButtons.Middle)
                btn = 2;

            if (e.Button == MouseButtons.Middle)
            {

            }

            if (proxy.ImGuiMouseDown(btn, pos.X, pos.Y))
                return;

            Panel1_MouseDown(sender, e);

        }

        private void gPanel1_MouseUp(object? sender, MouseEventArgs e)
        {
            Point cursorPosition = System.Windows.Forms.Cursor.Position;

            var pos = glcontrol.PointToClient(cursorPosition);
            int btn = 1;
            if (e.Button == MouseButtons.Right)
                btn = 3;
            if (e.Button == MouseButtons.Middle)
                btn = 2;


            if (proxy.ImGuiMouseUp(btn, pos.X, pos.Y))
                return;

            Panel1_MouseUp(sender, e);
        }


        private void gPanel1_MouseMove(object? sender, MouseEventArgs e)
        {
            Point cursorPosition = System.Windows.Forms.Cursor.Position;

            var pos = glcontrol.PointToClient(cursorPosition);
            //Panel1_MouseMove(sender, e);
            panel1_MouseMove(sender, e);

            proxy?.MouseMove(pos.X, pos.Y);
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrag = false;
            if (e.Button == MouseButtons.Left)
            {
                proxy.Select(ModifierKeys.HasFlag(Keys.Control));

            }
        }

        System.Drawing.Point startDrag;
        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            startDrag = e.Location;
            if (e.Button == MouseButtons.Right)
            {
                proxy.StartRotation(e.Location.X, e.Location.Y);
            }

            if (e.Button == MouseButtons.Left)
            {
                isDrag = true;
            }
        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (proxy == null)
                return;

            proxy.RedrawView();
            proxy.UpdateView();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            proxy.UpdateView();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            proxy = new OCCTProxy.OCCTProxy();

            hglrc = wglGetCurrentContext();

            Proxy.runOpenTk(glcontrol.Context.WindowPtr, hglrc.Value);


            inited = true;

            
            proxy.ActivateGrid(true);
            //proxy.ShowCube();
            proxy.SetDisplayMode(1);
            proxy.SetMaterial(1);
            //proxy.SetDegenerateModeOff();
            proxy.RedrawView();

            Color clr1 = Color.DarkBlue;
            Color clr2 = Color.Olive;
            //proxy.SetBackgroundColor(clr1.R, clr1.G, clr1.B, clr2.R, clr2.G, clr2.B);


            proxy.UpdateCurrentViewer();
            proxy.UpdateView();
            Width = Width + 1;
        }



        public IOCCTProxyInterface Proxy => proxy;


        IOCCTProxyInterface proxy;



        bool isDrag = false;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                proxy.Rotation(e.Location.X, e.Location.Y);
            }
            if (e.Button == MouseButtons.Left && isDrag)
            {
                var delta = new System.Drawing.Point(e.Location.X - startDrag.X, startDrag.Y - e.Location.Y);
                proxy.Pan(delta.X, delta.Y);
                startDrag = e.Location;
            }
            proxy.MoveTo(e.Location.X, e.Location.Y);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (proxy == null || !inited)
            {
                return;                
            }


            proxy.iterate();
            var eye = proxy.GetEye().Value;
            var center = proxy.GetCenter().Value;
            var up = proxy.GetUp().Value;


            glcontrol.MakeCurrent();
            var r = GL.GetBoolean(GetPName.DepthTest);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.Disable(EnableCap.Blend);
            GL.DepthMask(true);
            GL.DepthFunc(DepthFunction.Less);


            Vector3 cameraPosition = new Vector3(10.0f, 10.0f, 10);
            Vector3 cameraTarget = new Vector3(0.0f, 0.0f, 0.0f);
            Vector3 cameraUpVector = new Vector3(0.0f, 1.0f, 0.0f);


            Matrix4d view = Matrix4d.LookAt(cameraPosition, cameraTarget, cameraUpVector);

            view = Matrix4d.LookAt(eye, center, up);
            
            var projection = Matrix4d.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), (float)Width / Height, 0.1f, 100f);


            var anAspect = proxy.ProjectionAspect().Value;
            var aZNear = proxy.ProjectionZNear().Value;
            var aZFar = proxy.ProjectionZFar().Value;
            var aScale = proxy.ProjectionScale().Value; // Or derive from view dimensions
            ///aScale = 1;
            var halfWidth = aScale * anAspect / 2.0f;
            var halfHeight = aScale / 2.0f;
            projection = Matrix4d.CreateOrthographicOffCenter(-halfWidth, halfWidth, -halfHeight, halfHeight, -100000, 100000);
            

            GL.MatrixMode(MatrixMode.Projection);

            GL.LoadMatrix(ref projection);
            GL.MatrixMode(MatrixMode.Modelview);

            GL.LoadMatrix(ref view);



            {
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(Color.Red);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(100, 0, 0);

                GL.Color3(Color.Green);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 100, 0);

                GL.Color3(Color.Blue);
                GL.Vertex3(0, 0, 0);
                GL.Vertex3(0, 0, 100);
                GL.End();
            }



            GL.Disable(EnableCap.Lighting);

            proxy.StartRenderGui();

            proxy.EndRenderGui();
            glcontrol.SwapBuffers();
        }
    }
}
