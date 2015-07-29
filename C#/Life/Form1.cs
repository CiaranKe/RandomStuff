using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Life
{
    public partial class GameOfLife : Form
    {
        private Thread drawer;
        private int[,] Arena = new int[102, 102];
        private int Generation;
        private Brush redBrush = new SolidBrush(Color.Red);
        private Brush blueBrush = new SolidBrush(Color.Blue);
        private readonly static int NOT_STARTED = 0;
        private readonly static int RUNNING = 1;
        private readonly static int STOP_PENDING = 2;
        private readonly static int PAUSED = 3;
        private int threadState = NOT_STARTED;
        public int ThreadState
        {
            get
            {
                return threadState;
            }
            set
            {
                threadState = value;
            }
        }

        public GameOfLife()
        {
            InitializeComponent();
            this.InitLife();
        }

        private void GameOfLife_Load(object sender, EventArgs e)
        {

        }

        private void GameOfLife_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (drawer != null)
            {
                drawer.Join();
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Start.Enabled = false;
            Suspend.Enabled = true;
            Resume.Enabled = false;
            Abort.Enabled = true;
            drawer = new Thread(new ThreadStart(this.CalcDraw));
            threadState = RUNNING;
            drawer.Start();
        }

        private void CalcDraw()
        {
            while (true)
            {
                calcNextGeneration();
                drawGeneration(null);
                if (ThreadState == STOP_PENDING)
                {
                    ThreadState = NOT_STARTED;
                }
                else if (ThreadState == PAUSED)
                {
                    drawer.Suspend();
                }
            }
        }

        private void Suspend_Click(object sender, EventArgs e)
        {
            Start.Enabled = false;
            Suspend.Enabled = false;
            Resume.Enabled = true;
            Abort.Enabled = false;
            threadState = PAUSED;
        }

        private void Resume_Click(object sender, EventArgs e)
        {
            Start.Enabled = false;
            Suspend.Enabled = true;
            Resume.Enabled = false;
            Abort.Enabled = true;
            drawer.Resume();
            threadState = RUNNING;
        }

        private void Abort_Click(object sender, EventArgs e)
        {
            Start.Enabled = true;
            Suspend.Enabled = false;
            Resume.Enabled = false;
            Abort.Enabled = false;
            threadState = STOP_PENDING;
            this.Close();
        }

        public void InitLife()
        {
            Arena[41, 40] = 1;
            Arena[42, 40] = 1;
            Arena[40, 41] = 1;
            Arena[41, 41] = 1;
            Arena[41, 42] = 1;
        }

        public void calcNextGeneration()
        {
            int i, j, s, p, q;
            int[,] x = new int[102, 102];

            Generation++;
            GenerationCounter.Text = "Gen:" + Generation.ToString();
            GenerationCounter.Update();
            // determine if each cell should live or die
            for (i = 1; i <= 100; i++)
            {
                for (j = 1; j <= 100; j++)
                {
                    s = 0;
                    // compute effect of neighbours
                    for (p = i - 1; p <= i + 1; p++)
                    {
                        for (q = j - 1; q <= j + 1; q++)
                        {
                            s += Arena[p, q];
                        }
                    }
                    s -= Arena[i, j];
                    if (Arena[i, j] == 0 && s == 3)
                        x[i, j] = 1;
                    else if (Arena[i, j] == 1 && s >= 2 && s <= 3)
                        x[i, j] = 1;
                    else
                        x[i, j] = 0;
                }
            }
            for (i = 1; i <= 100; i++)
            {
                for (j = 1; j <= 100; j++)
                {
                    Arena[i, j] = x[i, j];
                }
            }
        }

        public void drawGeneration(Graphics g)
        {
            int i, j;

            if (g == null)
            {
                g = OurWorld.CreateGraphics();
            }

            g.FillRectangle(blueBrush, 0, 0, 400, 400);
            for (i = 0; i <= 100; i++)
            {
                for (j = 0; j <= 100; j++)
                {
                    if (Arena[i + 1, j + 1] == 1)
                    {
                        g.FillRectangle(redBrush, i * 4, j * 4, 4, 4);
                    }
                }
            }
        }
    }
}
