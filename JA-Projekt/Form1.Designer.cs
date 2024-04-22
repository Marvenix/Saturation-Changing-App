namespace JA_Projekt
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.bttn_Choose = new System.Windows.Forms.Button();
            this.bttn_Start = new System.Windows.Forms.Button();
            this.trackBar_G = new System.Windows.Forms.TrackBar();
            this.trackBar_Threads = new System.Windows.Forms.TrackBar();
            this.trackBar_R = new System.Windows.Forms.TrackBar();
            this.trackBar_B = new System.Windows.Forms.TrackBar();
            this.lbl_Saturation = new System.Windows.Forms.Label();
            this.lbl_R = new System.Windows.Forms.Label();
            this.lbl_G = new System.Windows.Forms.Label();
            this.lbl_B = new System.Windows.Forms.Label();
            this.lbl_Threads = new System.Windows.Forms.Label();
            this.lbl_Lib = new System.Windows.Forms.Label();
            this.lbl_Time = new System.Windows.Forms.Label();
            this.lbl_CSHARP_map = new System.Windows.Forms.Label();
            this.lbl_ASM = new System.Windows.Forms.Label();
            this.lbl_CSHARP_map_t = new System.Windows.Forms.Label();
            this.lbl_ASM_t = new System.Windows.Forms.Label();
            this.lbl_R_v = new System.Windows.Forms.Label();
            this.lbl_G_v = new System.Windows.Forms.Label();
            this.lbl_B_v = new System.Windows.Forms.Label();
            this.lbl_Threads_v = new System.Windows.Forms.Label();
            this.radioBttn_CSHARP_map = new System.Windows.Forms.RadioButton();
            this.radioBttn_ASM = new System.Windows.Forms.RadioButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.bttn_Clear = new System.Windows.Forms.Button();
            this.bttn_Exit = new System.Windows.Forms.Button();
            this.radioBttn_CSHARP_byte = new System.Windows.Forms.RadioButton();
            this.lbl_CSHARP_byte = new System.Windows.Forms.Label();
            this.lbl_CSHARP_byte_t = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_G)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Threads)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_B)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(385, 325);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragDrop);
            this.pictureBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox1_DragEnter);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Location = new System.Drawing.Point(402, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(385, 325);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // bttn_Choose
            // 
            this.bttn_Choose.Location = new System.Drawing.Point(675, 350);
            this.bttn_Choose.Name = "bttn_Choose";
            this.bttn_Choose.Size = new System.Drawing.Size(88, 34);
            this.bttn_Choose.TabIndex = 2;
            this.bttn_Choose.Text = "Wybierz";
            this.bttn_Choose.UseVisualStyleBackColor = true;
            this.bttn_Choose.Click += new System.EventHandler(this.bttn_Choose_Click);
            // 
            // bttn_Start
            // 
            this.bttn_Start.Location = new System.Drawing.Point(675, 430);
            this.bttn_Start.Name = "bttn_Start";
            this.bttn_Start.Size = new System.Drawing.Size(88, 34);
            this.bttn_Start.TabIndex = 3;
            this.bttn_Start.Text = "Start";
            this.bttn_Start.UseVisualStyleBackColor = true;
            this.bttn_Start.Click += new System.EventHandler(this.bttn_Start_Click);
            // 
            // trackBar_G
            // 
            this.trackBar_G.Location = new System.Drawing.Point(62, 421);
            this.trackBar_G.Maximum = 100;
            this.trackBar_G.Minimum = -100;
            this.trackBar_G.Name = "trackBar_G";
            this.trackBar_G.Size = new System.Drawing.Size(104, 45);
            this.trackBar_G.TabIndex = 6;
            this.trackBar_G.Scroll += new System.EventHandler(this.trackBar_G_Scroll);
            // 
            // trackBar_Threads
            // 
            this.trackBar_Threads.Location = new System.Drawing.Point(241, 371);
            this.trackBar_Threads.Maximum = 64;
            this.trackBar_Threads.Minimum = 1;
            this.trackBar_Threads.Name = "trackBar_Threads";
            this.trackBar_Threads.Size = new System.Drawing.Size(104, 45);
            this.trackBar_Threads.TabIndex = 7;
            this.trackBar_Threads.Value = 1;
            this.trackBar_Threads.Scroll += new System.EventHandler(this.trackBar_Threads_Scroll);
            // 
            // trackBar_R
            // 
            this.trackBar_R.Location = new System.Drawing.Point(62, 370);
            this.trackBar_R.Maximum = 100;
            this.trackBar_R.Minimum = -100;
            this.trackBar_R.Name = "trackBar_R";
            this.trackBar_R.Size = new System.Drawing.Size(104, 45);
            this.trackBar_R.TabIndex = 8;
            this.trackBar_R.Scroll += new System.EventHandler(this.trackBar_R_Scroll);
            // 
            // trackBar_B
            // 
            this.trackBar_B.Location = new System.Drawing.Point(62, 472);
            this.trackBar_B.Maximum = 100;
            this.trackBar_B.Minimum = -100;
            this.trackBar_B.Name = "trackBar_B";
            this.trackBar_B.Size = new System.Drawing.Size(104, 45);
            this.trackBar_B.TabIndex = 9;
            this.trackBar_B.Scroll += new System.EventHandler(this.trackBar_B_Scroll);
            // 
            // lbl_Saturation
            // 
            this.lbl_Saturation.AutoSize = true;
            this.lbl_Saturation.Location = new System.Drawing.Point(94, 354);
            this.lbl_Saturation.Name = "lbl_Saturation";
            this.lbl_Saturation.Size = new System.Drawing.Size(55, 13);
            this.lbl_Saturation.TabIndex = 10;
            this.lbl_Saturation.Text = "Saturacja:";
            // 
            // lbl_R
            // 
            this.lbl_R.AutoSize = true;
            this.lbl_R.Location = new System.Drawing.Point(9, 371);
            this.lbl_R.Name = "lbl_R";
            this.lbl_R.Size = new System.Drawing.Size(18, 13);
            this.lbl_R.TabIndex = 11;
            this.lbl_R.Text = "R:";
            // 
            // lbl_G
            // 
            this.lbl_G.AutoSize = true;
            this.lbl_G.Location = new System.Drawing.Point(9, 421);
            this.lbl_G.Name = "lbl_G";
            this.lbl_G.Size = new System.Drawing.Size(18, 13);
            this.lbl_G.TabIndex = 12;
            this.lbl_G.Text = "G:";
            // 
            // lbl_B
            // 
            this.lbl_B.AutoSize = true;
            this.lbl_B.Location = new System.Drawing.Point(9, 472);
            this.lbl_B.Name = "lbl_B";
            this.lbl_B.Size = new System.Drawing.Size(17, 13);
            this.lbl_B.TabIndex = 13;
            this.lbl_B.Text = "B:";
            // 
            // lbl_Threads
            // 
            this.lbl_Threads.AutoSize = true;
            this.lbl_Threads.Location = new System.Drawing.Point(275, 354);
            this.lbl_Threads.Name = "lbl_Threads";
            this.lbl_Threads.Size = new System.Drawing.Size(38, 13);
            this.lbl_Threads.TabIndex = 14;
            this.lbl_Threads.Text = "Wątki:";
            // 
            // lbl_Lib
            // 
            this.lbl_Lib.AutoSize = true;
            this.lbl_Lib.Location = new System.Drawing.Point(275, 419);
            this.lbl_Lib.Name = "lbl_Lib";
            this.lbl_Lib.Size = new System.Drawing.Size(79, 13);
            this.lbl_Lib.TabIndex = 15;
            this.lbl_Lib.Text = "Biblioteka DLL:";
            // 
            // lbl_Time
            // 
            this.lbl_Time.AutoSize = true;
            this.lbl_Time.Location = new System.Drawing.Point(454, 355);
            this.lbl_Time.Name = "lbl_Time";
            this.lbl_Time.Size = new System.Drawing.Size(33, 13);
            this.lbl_Time.TabIndex = 16;
            this.lbl_Time.Text = "Czas:";
            // 
            // lbl_CSHARP_map
            // 
            this.lbl_CSHARP_map.AutoSize = true;
            this.lbl_CSHARP_map.Location = new System.Drawing.Point(399, 411);
            this.lbl_CSHARP_map.Name = "lbl_CSHARP_map";
            this.lbl_CSHARP_map.Size = new System.Drawing.Size(64, 13);
            this.lbl_CSHARP_map.TabIndex = 17;
            this.lbl_CSHARP_map.Text = "C# - bitmap:";
            // 
            // lbl_ASM
            // 
            this.lbl_ASM.AutoSize = true;
            this.lbl_ASM.Location = new System.Drawing.Point(399, 470);
            this.lbl_ASM.Name = "lbl_ASM";
            this.lbl_ASM.Size = new System.Drawing.Size(33, 13);
            this.lbl_ASM.TabIndex = 18;
            this.lbl_ASM.Text = "ASM:";
            // 
            // lbl_CSHARP_map_t
            // 
            this.lbl_CSHARP_map_t.AutoSize = true;
            this.lbl_CSHARP_map_t.Location = new System.Drawing.Point(487, 411);
            this.lbl_CSHARP_map_t.Name = "lbl_CSHARP_map_t";
            this.lbl_CSHARP_map_t.Size = new System.Drawing.Size(0, 13);
            this.lbl_CSHARP_map_t.TabIndex = 19;
            // 
            // lbl_ASM_t
            // 
            this.lbl_ASM_t.AutoSize = true;
            this.lbl_ASM_t.Location = new System.Drawing.Point(487, 472);
            this.lbl_ASM_t.Name = "lbl_ASM_t";
            this.lbl_ASM_t.Size = new System.Drawing.Size(0, 13);
            this.lbl_ASM_t.TabIndex = 20;
            // 
            // lbl_R_v
            // 
            this.lbl_R_v.AutoSize = true;
            this.lbl_R_v.Location = new System.Drawing.Point(173, 371);
            this.lbl_R_v.Name = "lbl_R_v";
            this.lbl_R_v.Size = new System.Drawing.Size(13, 13);
            this.lbl_R_v.TabIndex = 21;
            this.lbl_R_v.Text = "0";
            // 
            // lbl_G_v
            // 
            this.lbl_G_v.AutoSize = true;
            this.lbl_G_v.Location = new System.Drawing.Point(172, 419);
            this.lbl_G_v.Name = "lbl_G_v";
            this.lbl_G_v.Size = new System.Drawing.Size(13, 13);
            this.lbl_G_v.TabIndex = 22;
            this.lbl_G_v.Text = "0";
            // 
            // lbl_B_v
            // 
            this.lbl_B_v.AutoSize = true;
            this.lbl_B_v.Location = new System.Drawing.Point(172, 476);
            this.lbl_B_v.Name = "lbl_B_v";
            this.lbl_B_v.Size = new System.Drawing.Size(13, 13);
            this.lbl_B_v.TabIndex = 23;
            this.lbl_B_v.Text = "0";
            // 
            // lbl_Threads_v
            // 
            this.lbl_Threads_v.AutoSize = true;
            this.lbl_Threads_v.Location = new System.Drawing.Point(352, 375);
            this.lbl_Threads_v.Name = "lbl_Threads_v";
            this.lbl_Threads_v.Size = new System.Drawing.Size(13, 13);
            this.lbl_Threads_v.TabIndex = 24;
            this.lbl_Threads_v.Text = "1";
            // 
            // radioBttn_CSHARP_map
            // 
            this.radioBttn_CSHARP_map.AutoSize = true;
            this.radioBttn_CSHARP_map.Location = new System.Drawing.Point(260, 441);
            this.radioBttn_CSHARP_map.Name = "radioBttn_CSHARP_map";
            this.radioBttn_CSHARP_map.Size = new System.Drawing.Size(79, 17);
            this.radioBttn_CSHARP_map.TabIndex = 25;
            this.radioBttn_CSHARP_map.TabStop = true;
            this.radioBttn_CSHARP_map.Text = "C# - bitmap";
            this.radioBttn_CSHARP_map.UseVisualStyleBackColor = true;
            // 
            // radioBttn_ASM
            // 
            this.radioBttn_ASM.AutoSize = true;
            this.radioBttn_ASM.Location = new System.Drawing.Point(260, 487);
            this.radioBttn_ASM.Name = "radioBttn_ASM";
            this.radioBttn_ASM.Size = new System.Drawing.Size(48, 17);
            this.radioBttn_ASM.TabIndex = 26;
            this.radioBttn_ASM.TabStop = true;
            this.radioBttn_ASM.Text = "ASM";
            this.radioBttn_ASM.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
            this.openFileDialog1.FilterIndex = 2;
            this.openFileDialog1.InitialDirectory = "C:\\\\";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // bttn_Clear
            // 
            this.bttn_Clear.Location = new System.Drawing.Point(675, 390);
            this.bttn_Clear.Name = "bttn_Clear";
            this.bttn_Clear.Size = new System.Drawing.Size(88, 34);
            this.bttn_Clear.TabIndex = 27;
            this.bttn_Clear.Text = "Czyść";
            this.bttn_Clear.UseVisualStyleBackColor = true;
            this.bttn_Clear.Click += new System.EventHandler(this.bttn_Clear_Click);
            // 
            // bttn_Exit
            // 
            this.bttn_Exit.Location = new System.Drawing.Point(675, 470);
            this.bttn_Exit.Name = "bttn_Exit";
            this.bttn_Exit.Size = new System.Drawing.Size(88, 34);
            this.bttn_Exit.TabIndex = 28;
            this.bttn_Exit.Text = "Wyjdź";
            this.bttn_Exit.UseVisualStyleBackColor = true;
            this.bttn_Exit.Click += new System.EventHandler(this.bttn_Exit_Click);
            // 
            // radioBttn_CSHARP_byte
            // 
            this.radioBttn_CSHARP_byte.AutoSize = true;
            this.radioBttn_CSHARP_byte.Location = new System.Drawing.Point(260, 464);
            this.radioBttn_CSHARP_byte.Name = "radioBttn_CSHARP_byte";
            this.radioBttn_CSHARP_byte.Size = new System.Drawing.Size(68, 17);
            this.radioBttn_CSHARP_byte.TabIndex = 29;
            this.radioBttn_CSHARP_byte.TabStop = true;
            this.radioBttn_CSHARP_byte.Text = "C# - byte";
            this.radioBttn_CSHARP_byte.UseVisualStyleBackColor = true;
            // 
            // lbl_CSHARP_byte
            // 
            this.lbl_CSHARP_byte.AutoSize = true;
            this.lbl_CSHARP_byte.Location = new System.Drawing.Point(399, 441);
            this.lbl_CSHARP_byte.Name = "lbl_CSHARP_byte";
            this.lbl_CSHARP_byte.Size = new System.Drawing.Size(53, 13);
            this.lbl_CSHARP_byte.TabIndex = 30;
            this.lbl_CSHARP_byte.Text = "C# - byte:";
            // 
            // lbl_CSHARP_byte_t
            // 
            this.lbl_CSHARP_byte_t.AutoSize = true;
            this.lbl_CSHARP_byte_t.Location = new System.Drawing.Point(487, 443);
            this.lbl_CSHARP_byte_t.Name = "lbl_CSHARP_byte_t";
            this.lbl_CSHARP_byte_t.Size = new System.Drawing.Size(0, 13);
            this.lbl_CSHARP_byte_t.TabIndex = 31;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 529);
            this.Controls.Add(this.lbl_CSHARP_byte_t);
            this.Controls.Add(this.lbl_CSHARP_byte);
            this.Controls.Add(this.radioBttn_CSHARP_byte);
            this.Controls.Add(this.bttn_Exit);
            this.Controls.Add(this.bttn_Clear);
            this.Controls.Add(this.radioBttn_ASM);
            this.Controls.Add(this.radioBttn_CSHARP_map);
            this.Controls.Add(this.lbl_Threads_v);
            this.Controls.Add(this.lbl_B_v);
            this.Controls.Add(this.lbl_G_v);
            this.Controls.Add(this.lbl_R_v);
            this.Controls.Add(this.lbl_ASM_t);
            this.Controls.Add(this.lbl_CSHARP_map_t);
            this.Controls.Add(this.lbl_ASM);
            this.Controls.Add(this.lbl_CSHARP_map);
            this.Controls.Add(this.lbl_Time);
            this.Controls.Add(this.lbl_Lib);
            this.Controls.Add(this.lbl_Threads);
            this.Controls.Add(this.lbl_B);
            this.Controls.Add(this.lbl_G);
            this.Controls.Add(this.lbl_R);
            this.Controls.Add(this.lbl_Saturation);
            this.Controls.Add(this.trackBar_B);
            this.Controls.Add(this.trackBar_R);
            this.Controls.Add(this.trackBar_Threads);
            this.Controls.Add(this.trackBar_G);
            this.Controls.Add(this.bttn_Start);
            this.Controls.Add(this.bttn_Choose);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(816, 568);
            this.MinimumSize = new System.Drawing.Size(816, 568);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saturacja";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_G)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_Threads)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_B)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button bttn_Choose;
        private System.Windows.Forms.Button bttn_Start;
        private System.Windows.Forms.TrackBar trackBar_G;
        private System.Windows.Forms.TrackBar trackBar_Threads;
        private System.Windows.Forms.TrackBar trackBar_R;
        private System.Windows.Forms.TrackBar trackBar_B;
        private System.Windows.Forms.Label lbl_Saturation;
        private System.Windows.Forms.Label lbl_R;
        private System.Windows.Forms.Label lbl_G;
        private System.Windows.Forms.Label lbl_B;
        private System.Windows.Forms.Label lbl_Threads;
        private System.Windows.Forms.Label lbl_Lib;
        private System.Windows.Forms.Label lbl_Time;
        private System.Windows.Forms.Label lbl_CSHARP_map;
        private System.Windows.Forms.Label lbl_ASM;
        private System.Windows.Forms.Label lbl_CSHARP_map_t;
        private System.Windows.Forms.Label lbl_ASM_t;
        private System.Windows.Forms.Label lbl_R_v;
        private System.Windows.Forms.Label lbl_G_v;
        private System.Windows.Forms.Label lbl_B_v;
        private System.Windows.Forms.Label lbl_Threads_v;
        private System.Windows.Forms.RadioButton radioBttn_CSHARP_map;
        private System.Windows.Forms.RadioButton radioBttn_ASM;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bttn_Clear;
        private System.Windows.Forms.Button bttn_Exit;
        private System.Windows.Forms.RadioButton radioBttn_CSHARP_byte;
        private System.Windows.Forms.Label lbl_CSHARP_byte;
        private System.Windows.Forms.Label lbl_CSHARP_byte_t;
    }
}

