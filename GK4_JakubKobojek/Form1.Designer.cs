namespace Cpu3DEngine
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.phongRadioButton = new System.Windows.Forms.RadioButton();
            this.gouraudShadingRadioButton = new System.Windows.Forms.RadioButton();
            this.flatShadingRadioButton = new System.Windows.Forms.RadioButton();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.shininessTrackBar = new System.Windows.Forms.TrackBar();
            this.specularTrackBar = new System.Windows.Forms.TrackBar();
            this.ambientTrackBar = new System.Windows.Forms.TrackBar();
            this.diffuseTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dynamicCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.followingCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.staticCameraRadioButton = new System.Windows.Forms.RadioButton();
            this.playButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.fogCheckBox = new System.Windows.Forms.CheckBox();
            this.rotationTrackBar = new System.Windows.Forms.TrackBar();
            this.globalLightCheckBox = new System.Windows.Forms.CheckBox();
            this.spotLightCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shininessTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.specularTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ambientTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diffuseTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotationTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 615);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox2);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDown1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.trackBar1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.playButton);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.fogCheckBox);
            this.splitContainer1.Panel2.Controls.Add(this.rotationTrackBar);
            this.splitContainer1.Panel2.Controls.Add(this.globalLightCheckBox);
            this.splitContainer1.Panel2.Controls.Add(this.spotLightCheckBox);
            this.splitContainer1.Size = new System.Drawing.Size(920, 615);
            this.splitContainer1.SplitterDistance = 700;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 17;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(302, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(101, 101);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 542);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 30;
            this.label7.Text = "Strength";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 542);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 29;
            this.label6.Text = "Hit direction";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numericUpDown1.Location = new System.Drawing.Point(122, 570);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(80, 23);
            this.numericUpDown1.TabIndex = 28;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.phongRadioButton);
            this.groupBox1.Controls.Add(this.gouraudShadingRadioButton);
            this.groupBox1.Controls.Add(this.flatShadingRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 100);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shading mode";
            // 
            // phongRadioButton
            // 
            this.phongRadioButton.AutoSize = true;
            this.phongRadioButton.Location = new System.Drawing.Point(10, 72);
            this.phongRadioButton.Name = "phongRadioButton";
            this.phongRadioButton.Size = new System.Drawing.Size(60, 19);
            this.phongRadioButton.TabIndex = 2;
            this.phongRadioButton.Text = "Phong";
            this.phongRadioButton.UseVisualStyleBackColor = true;
            this.phongRadioButton.CheckedChanged += new System.EventHandler(this.phongRadioButton_CheckedChanged);
            // 
            // gouraudShadingRadioButton
            // 
            this.gouraudShadingRadioButton.AutoSize = true;
            this.gouraudShadingRadioButton.Checked = true;
            this.gouraudShadingRadioButton.Location = new System.Drawing.Point(10, 47);
            this.gouraudShadingRadioButton.Name = "gouraudShadingRadioButton";
            this.gouraudShadingRadioButton.Size = new System.Drawing.Size(71, 19);
            this.gouraudShadingRadioButton.TabIndex = 1;
            this.gouraudShadingRadioButton.TabStop = true;
            this.gouraudShadingRadioButton.Text = "Gouraud";
            this.gouraudShadingRadioButton.UseVisualStyleBackColor = true;
            this.gouraudShadingRadioButton.CheckedChanged += new System.EventHandler(this.gouraudShadingRadioButton_CheckedChanged);
            // 
            // flatShadingRadioButton
            // 
            this.flatShadingRadioButton.AutoSize = true;
            this.flatShadingRadioButton.Location = new System.Drawing.Point(10, 22);
            this.flatShadingRadioButton.Name = "flatShadingRadioButton";
            this.flatShadingRadioButton.Size = new System.Drawing.Size(44, 19);
            this.flatShadingRadioButton.TabIndex = 0;
            this.flatShadingRadioButton.Text = "Flat";
            this.flatShadingRadioButton.UseVisualStyleBackColor = true;
            this.flatShadingRadioButton.CheckedChanged += new System.EventHandler(this.flatShadingRadioButton_CheckedChanged);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(11, 570);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 27;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.shininessTrackBar);
            this.groupBox3.Controls.Add(this.specularTrackBar);
            this.groupBox3.Controls.Add(this.ambientTrackBar);
            this.groupBox3.Controls.Add(this.diffuseTrackBar);
            this.groupBox3.Location = new System.Drawing.Point(13, 118);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(192, 184);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mesh light coefficients";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Shininess";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Specular";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ambient";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Diffuse";
            // 
            // shininessTrackBar
            // 
            this.shininessTrackBar.Location = new System.Drawing.Point(65, 136);
            this.shininessTrackBar.Minimum = 1;
            this.shininessTrackBar.Name = "shininessTrackBar";
            this.shininessTrackBar.Size = new System.Drawing.Size(104, 45);
            this.shininessTrackBar.TabIndex = 3;
            this.shininessTrackBar.Value = 5;
            this.shininessTrackBar.Scroll += new System.EventHandler(this.shininessTrackBar_Scroll);
            // 
            // specularTrackBar
            // 
            this.specularTrackBar.Location = new System.Drawing.Point(65, 103);
            this.specularTrackBar.Maximum = 100;
            this.specularTrackBar.Name = "specularTrackBar";
            this.specularTrackBar.Size = new System.Drawing.Size(104, 45);
            this.specularTrackBar.TabIndex = 2;
            this.specularTrackBar.Value = 20;
            this.specularTrackBar.Scroll += new System.EventHandler(this.specularTrackBar_Scroll);
            // 
            // ambientTrackBar
            // 
            this.ambientTrackBar.Location = new System.Drawing.Point(65, 68);
            this.ambientTrackBar.Maximum = 100;
            this.ambientTrackBar.Name = "ambientTrackBar";
            this.ambientTrackBar.Size = new System.Drawing.Size(104, 45);
            this.ambientTrackBar.TabIndex = 1;
            this.ambientTrackBar.Value = 20;
            this.ambientTrackBar.Scroll += new System.EventHandler(this.ambientTrackBar_Scroll);
            // 
            // diffuseTrackBar
            // 
            this.diffuseTrackBar.Location = new System.Drawing.Point(65, 31);
            this.diffuseTrackBar.Maximum = 100;
            this.diffuseTrackBar.Name = "diffuseTrackBar";
            this.diffuseTrackBar.Size = new System.Drawing.Size(104, 45);
            this.diffuseTrackBar.TabIndex = 0;
            this.diffuseTrackBar.Value = 100;
            this.diffuseTrackBar.Scroll += new System.EventHandler(this.diffuseTrackBar_Scroll);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dynamicCameraRadioButton);
            this.groupBox2.Controls.Add(this.followingCameraRadioButton);
            this.groupBox2.Controls.Add(this.staticCameraRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(13, 308);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 99);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera type";
            // 
            // dynamicCameraRadioButton
            // 
            this.dynamicCameraRadioButton.AutoSize = true;
            this.dynamicCameraRadioButton.Location = new System.Drawing.Point(6, 74);
            this.dynamicCameraRadioButton.Name = "dynamicCameraRadioButton";
            this.dynamicCameraRadioButton.Size = new System.Drawing.Size(114, 19);
            this.dynamicCameraRadioButton.TabIndex = 5;
            this.dynamicCameraRadioButton.Text = "Dynamic camera";
            this.dynamicCameraRadioButton.UseVisualStyleBackColor = true;
            this.dynamicCameraRadioButton.CheckedChanged += new System.EventHandler(this.dynamicCameraRadioButton_CheckedChanged);
            // 
            // followingCameraRadioButton
            // 
            this.followingCameraRadioButton.AutoSize = true;
            this.followingCameraRadioButton.Location = new System.Drawing.Point(6, 49);
            this.followingCameraRadioButton.Name = "followingCameraRadioButton";
            this.followingCameraRadioButton.Size = new System.Drawing.Size(119, 19);
            this.followingCameraRadioButton.TabIndex = 4;
            this.followingCameraRadioButton.Text = "Following camera";
            this.followingCameraRadioButton.UseVisualStyleBackColor = true;
            this.followingCameraRadioButton.CheckedChanged += new System.EventHandler(this.followingCameraRadioButton_CheckedChanged);
            // 
            // staticCameraRadioButton
            // 
            this.staticCameraRadioButton.AutoSize = true;
            this.staticCameraRadioButton.Checked = true;
            this.staticCameraRadioButton.Location = new System.Drawing.Point(6, 24);
            this.staticCameraRadioButton.Name = "staticCameraRadioButton";
            this.staticCameraRadioButton.Size = new System.Drawing.Size(96, 19);
            this.staticCameraRadioButton.TabIndex = 3;
            this.staticCameraRadioButton.TabStop = true;
            this.staticCameraRadioButton.Text = "Static camera";
            this.staticCameraRadioButton.UseVisualStyleBackColor = true;
            this.staticCameraRadioButton.CheckedChanged += new System.EventHandler(this.staticCameraRadioButton_CheckedChanged);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(11, 499);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(191, 36);
            this.playButton.TabIndex = 18;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "Light rotation";
            // 
            // fogCheckBox
            // 
            this.fogCheckBox.AutoSize = true;
            this.fogCheckBox.Location = new System.Drawing.Point(108, 474);
            this.fogCheckBox.Name = "fogCheckBox";
            this.fogCheckBox.Size = new System.Drawing.Size(46, 19);
            this.fogCheckBox.TabIndex = 26;
            this.fogCheckBox.Text = "Fog";
            this.fogCheckBox.UseVisualStyleBackColor = true;
            this.fogCheckBox.CheckedChanged += new System.EventHandler(this.fogCheckBox_CheckedChanged);
            // 
            // rotationTrackBar
            // 
            this.rotationTrackBar.Location = new System.Drawing.Point(98, 423);
            this.rotationTrackBar.Maximum = 100;
            this.rotationTrackBar.Name = "rotationTrackBar";
            this.rotationTrackBar.Size = new System.Drawing.Size(104, 45);
            this.rotationTrackBar.TabIndex = 20;
            this.rotationTrackBar.Value = 50;
            this.rotationTrackBar.Scroll += new System.EventHandler(this.rotationTrackBar_Scroll);
            // 
            // globalLightCheckBox
            // 
            this.globalLightCheckBox.AutoSize = true;
            this.globalLightCheckBox.Checked = true;
            this.globalLightCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.globalLightCheckBox.Location = new System.Drawing.Point(15, 474);
            this.globalLightCheckBox.Name = "globalLightCheckBox";
            this.globalLightCheckBox.Size = new System.Drawing.Size(87, 19);
            this.globalLightCheckBox.TabIndex = 24;
            this.globalLightCheckBox.Text = "Global light";
            this.globalLightCheckBox.UseVisualStyleBackColor = true;
            this.globalLightCheckBox.CheckedChanged += new System.EventHandler(this.globalLightCheckBox_CheckedChanged);
            // 
            // spotLightCheckBox
            // 
            this.spotLightCheckBox.AutoSize = true;
            this.spotLightCheckBox.Checked = true;
            this.spotLightCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.spotLightCheckBox.Location = new System.Drawing.Point(15, 441);
            this.spotLightCheckBox.Name = "spotLightCheckBox";
            this.spotLightCheckBox.Size = new System.Drawing.Size(77, 19);
            this.spotLightCheckBox.TabIndex = 25;
            this.spotLightCheckBox.Text = "Flashlight";
            this.spotLightCheckBox.UseVisualStyleBackColor = true;
            this.spotLightCheckBox.CheckedChanged += new System.EventHandler(this.spotLightCheckBox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 616);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GK4";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shininessTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.specularTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ambientTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diffuseTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotationTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox spotLightCheckBox;
        private System.Windows.Forms.CheckBox globalLightCheckBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar rotationTrackBar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar shininessTrackBar;
        private System.Windows.Forms.TrackBar specularTrackBar;
        private System.Windows.Forms.TrackBar ambientTrackBar;
        private System.Windows.Forms.TrackBar diffuseTrackBar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton dynamicCameraRadioButton;
        private System.Windows.Forms.RadioButton followingCameraRadioButton;
        private System.Windows.Forms.RadioButton staticCameraRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton phongRadioButton;
        private System.Windows.Forms.RadioButton gouraudShadingRadioButton;
        private System.Windows.Forms.RadioButton flatShadingRadioButton;
        private System.Windows.Forms.CheckBox fogCheckBox;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}
