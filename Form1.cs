using ThreadExample;

// to keep things in a clear and maintainable format , all variables are 
// defined in the beginning of the class , we also instantiate the Ui Elements
// and define functions in the beginning of the class
// the design of Ui elements and the logic of Event Handlers are defined at the
// end of the file.  

// we also need a connection between the back-end logic and the ui
// using a simple dependancy injection we can instantiate the ui class in the 
// back-end class , which results in a connection between these two classes 
// that allows us to update the ui after each request is done in the back-end. 

namespace Gephwin
{
    public partial class Form1 : Form
    {
        backend back;
        TextBox hitbox = new TextBox();
        Button cbtn = new Button();
        Button stopbtn = new Button();
        Label hit = new Label();
        Label free = new Label();
        Label bad = new Label();
        Label rem = new Label();
        Label cpm = new Label();
        Label acc = new Label();
        public static string[] combo;
        public static string[] tproxy;
        int threadvalue;
        public static int all;
        public static int chit;
        public static int cfree = 0;
        public static int cbad;
        public static int change;
        public static int crem;
        public static float time;
        public static int ccpm;
        public static float last;
        public static int C = 1;
        public static int Lproxy;
        private System.Threading.Timer timer;
        
        public Form1()
        {
            InitializeComponent();
            back = new backend(this);
            
            Cbtn();
            Pbtn();
            Sbtn();
            Stopbtn();
            Hit();
            Bad();
            Free();
            Acc();
            Rem();
            Cpm();
            cThread();
            Hitbox();
            Tnum();
            
            //The timer which is used for calculating the cpm    
            timer = new System.Threading.Timer(elapsed, null, 0, 1000);
        }
        // Combo Button ui
        public void Cbtn()
        {
            cbtn.Size = new Size(140, 50);
            cbtn.FlatStyle = FlatStyle.Flat;
            cbtn.FlatAppearance.BorderSize = 0;
            cbtn.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            cbtn.Text = "Combo";
            cbtn.BackColor = ColorTranslator.FromHtml("#2d2d33");
            cbtn.ForeColor = ColorTranslator.FromHtml("#FFDCDCDC");
            cbtn.Location = new Point(10, 10);
            cbtn.Click += comboinsert;
            this.Controls.Add(cbtn);
        }
        // Proxy Button ui
        public void Pbtn()
        {
            Button sbtn = new Button();
            sbtn.Size = new Size(140, 50);
            sbtn.FlatStyle = FlatStyle.Flat;
            sbtn.FlatAppearance.BorderSize = 0;
            sbtn.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            sbtn.Text = "Proxy";
            sbtn.BackColor = ColorTranslator.FromHtml("#2d2d33");
            sbtn.ForeColor = ColorTranslator.FromHtml("#FFDCDCDC");
            sbtn.Location = new Point(10, 70);
            this.Controls.Add(sbtn);
        }
        // Start Button ui
        public void Sbtn()
        {
            Button pbtn = new Button();
            pbtn.Name = "start";
            pbtn.Click += new EventHandler(sclick);
            pbtn.Size = new Size(140, 50);
            pbtn.FlatStyle = FlatStyle.Flat;
            pbtn.FlatAppearance.BorderSize = 0;
            pbtn.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            pbtn.Text = "Start";
            pbtn.BackColor = ColorTranslator.FromHtml("#2d2d33");
            pbtn.ForeColor = ColorTranslator.FromHtml("#FFDCDCDC");
            pbtn.Location = new Point(10, 130);
            this.Controls.Add(pbtn);
        }
        // Stop Button ui
        public void Stopbtn()
        {
            stopbtn.Size = new Size(140, 50);
            stopbtn.FlatStyle = FlatStyle.Flat;
            stopbtn.FlatAppearance.BorderSize = 0;
            stopbtn.Font = new Font("Segoe UI", 13, FontStyle.Bold);
            stopbtn.Text = "Stop";
            stopbtn.BackColor = ColorTranslator.FromHtml("#2d2d33");
            stopbtn.ForeColor = ColorTranslator.FromHtml("#FFDCDCDC");
            stopbtn.Location = new Point(10, 190);
            stopbtn.Click += stopconfig;
            this.Controls.Add(stopbtn);
        }
        // Hit Label ui
        public void Hit()
        {
            hit.Size = new Size(80, 40);
            hit.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            hit.ForeColor = Color.GreenYellow;
            hit.BackColor = ColorTranslator.FromHtml("#FF222222");
            hit.Text = "Hit " + chit;
            hit.Location = new Point(370, 260);
            this.Controls.Add(hit);
        }
        // Bad Label ui
        public void Bad()
        {
            bad.Size = new Size(160, 40);
            bad.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            bad.ForeColor = Color.Red;
            bad.BackColor = ColorTranslator.FromHtml("#FF222222");
            bad.Text = "Bad  " + cbad;
            bad.Location = new Point(370, 300);
            this.Controls.Add(bad);
        }
        // Free Label ui
        public void Free()
        {
            free.Size = new Size(80, 40);
            free.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            free.ForeColor = Color.Orange;
            free.BackColor = ColorTranslator.FromHtml("#FF222222");
            free.Text = "Free " + cfree;
            free.Location = new Point(370, 340);
            this.Controls.Add(free);
        }
        // Acc Label ui
        public void Acc()
        {
            acc.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            acc.Size = new Size(160, 40);
            acc.ForeColor = Color.AntiqueWhite;
            acc.BackColor = ColorTranslator.FromHtml("#FF222222");
            acc.Text = "Total  " + all;
            acc.Location = new Point(160, 260);
            this.Controls.Add(acc);
        }
        // Remaining Label ui
        public void Rem()
        {
            rem.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            rem.Size = new Size(160, 40);
            rem.ForeColor = ColorTranslator.FromHtml("#b7b6bf");
            rem.BackColor = ColorTranslator.FromHtml("#FF222222");
            rem.Text = "Remaining " + crem;
            rem.Location = new Point(160, 300);
            this.Controls.Add(rem);
        }
        // Checker Per Minute Label ui
        public void Cpm()
        {
            cpm.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            cpm.Size = new Size(160, 40);
            cpm.ForeColor = Color.DarkMagenta;
            cpm.BackColor = ColorTranslator.FromHtml("#FF222222");
            cpm.Text = "Cpm             " + ccpm;
            cpm.Location = new Point(160, 340);
            this.Controls.Add(cpm);
        }
        // Total Threads Label
        public void cThread()
        {
            Label thread = new Label();
            thread.Font = new Font("Segoe Ui", 10, FontStyle.Regular);
            thread.Size = new Size(160, 20);
            thread.ForeColor = Color.White;
            thread.BackColor = ColorTranslator.FromHtml("#FF222222");
            thread.Text = "Thread";
            thread.Location = new Point(8, 260);
            this.Controls.Add(thread);
        }
        // The Ui for Hitbox , Any Result is going to be Shown in this Hitbox
        public void Hitbox()
        {
            hitbox.Size = new Size(380, 230);
            hitbox.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            hitbox.Location = new Point(160, 10);
            hitbox.BorderStyle = BorderStyle.FixedSingle;
            hitbox.BackColor = ColorTranslator.FromHtml("#FF222222");
            hitbox.ForeColor = ColorTranslator.FromHtml("#FFDCDCDC");
            hitbox.ScrollBars = ScrollBars.Vertical;
            hitbox.Multiline = true;
            this.Controls.Add(hitbox);
        }
        // The Thread selector , Allows the user to set the desired thread
        public void Tnum()
        {
            NumericUpDown tnum = new NumericUpDown();
            tnum.Size = new Size(140, 100);
            tnum.Location = new Point(10, 290);
            tnum.Font = new Font("Segoe Ui", 9, FontStyle.Regular);
            tnum.BackColor = ColorTranslator.FromHtml("#FF222222");
            tnum.ForeColor = ColorTranslator.FromHtml("#FFDCDCDC");
            tnum.Maximum = 200;
            tnum.ValueChanged += (sender, e) =>
            {
                threadvalue = (int)tnum.Value;
            };
            this.Controls.Add(tnum);
        }
        // Event Handler for the Start Button
        public void sclick(object sender, EventArgs e)
        {
            back.pauseThreads = false;
            int bot = threadvalue;
            backend.flag = 1;
            back.Main(combo, bot);
        }
        //Updating the Bad Label
        public void updatecbad(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(updatecbad), value);
                return;
            }
            last++;
            cbad += value;
            UpdateLabels();
        }
        // Updating the Hit label
        public void updatechit(int value, string username, string password, string modified)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, string, string, string>(updatechit), value, username, password, modified);
                return;
            }
            last++;
            chit += value;
            string capture = $"USER: {username} PASS: {password} {modified}";
            hitbox.AppendText(capture + Environment.NewLine);
            UpdateLabels();
        }
        // Updating the Free label
        public void updatecfree(int value)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(updatecfree), value);
                return;
            }
            last++;
            cfree += value;
            UpdateLabels();
        }
        // the Logic for calculating the elapsed time and updating the Cpm label
        
        public void elapsed(object state)
        {
            time++;
            if (time >= 60)
            {
                time = 0;
                last = 0;
            }
            ccpm = (int)(last / (time / 60.0));
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateCPMLabel));
            }
            else
            {
                UpdateCPMLabel();
            }
        }
        // updating all of the labels , this is used in some of the Event handlers
        private void UpdateLabels()
        {
            crem = all - chit - cbad - cfree;
            hit.Text = "Hit " + chit;
            bad.Text = "Bad " + cbad;
            free.Text = "Free " + cfree;
            rem.Text = "Remaining " + crem;
            cpm.Text = "CPM " + ccpm;
        }
        
        private void UpdateCPMLabel()
        {
            cpm.Text = "CPM " + ccpm;
        }
        // Event Handler for inserting the combolist , when we press the start button
        public void comboinsert(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string path = dialog.FileName;
                combo = System.IO.File.ReadAllLines(path);
                all = combo.Length;
                acc.Text = "Total  " + all;
            }
        }
        // Event handler for stopping the App , when the Stop button is pressed
        public void stopconfig(object sender, EventArgs e)
        {
            C++;
            if (C % 2 == 0)
            {
                back.pauseThreads = true;
                stopbtn.Text = "Resume";
            }
            else
            {
                back.pauseThreads = false;
                stopbtn.Text = "Pause";
            }
        }
    }
}
