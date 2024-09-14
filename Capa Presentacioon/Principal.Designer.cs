namespace Capa_Presentacioon
{
    partial class Principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.titulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.control = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btsesion = new System.Windows.Forms.Button();
            this.btonsultar = new System.Windows.Forms.Button();
            this.btegistrar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titulo.SuspendLayout();
            this.menu.SuspendLayout();
            this.control.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.titulo;
            this.bunifuDragControl1.Vertical = true;
            // 
            // titulo
            // 
            this.titulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(79)))), ((int)(((byte)(203)))));
            this.titulo.Controls.Add(this.label1);
            this.titulo.Controls.Add(this.pictureBox1);
            this.titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.titulo.Location = new System.Drawing.Point(0, 0);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(1399, 72);
            this.titulo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(486, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 41);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sistema de Visitas ITLA";
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.menu.CausesValidation = false;
            this.menu.Controls.Add(this.pictureBox3);
            this.menu.Controls.Add(this.label4);
            this.menu.Controls.Add(this.label3);
            this.menu.Controls.Add(this.label2);
            this.menu.Controls.Add(this.panel3);
            this.menu.Controls.Add(this.panel2);
            this.menu.Controls.Add(this.panel1);
            this.menu.Controls.Add(this.btsesion);
            this.menu.Controls.Add(this.btonsultar);
            this.menu.Controls.Add(this.btegistrar);
            this.menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu.ForeColor = System.Drawing.Color.Snow;
            this.menu.Location = new System.Drawing.Point(0, 72);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(200, 680);
            this.menu.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(47, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 24);
            this.label4.TabIndex = 7;
            this.label4.Text = "Registrar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(50, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Consultar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 637);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cerrar sesion";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(79)))), ((int)(((byte)(203)))));
            this.panel3.Location = new System.Drawing.Point(0, 542);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 81);
            this.panel3.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(79)))), ((int)(((byte)(203)))));
            this.panel2.Location = new System.Drawing.Point(3, 383);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 80);
            this.panel2.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(79)))), ((int)(((byte)(203)))));
            this.panel1.Location = new System.Drawing.Point(3, 220);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 85);
            this.panel1.TabIndex = 3;
            // 
            // control
            // 
            this.control.Controls.Add(this.pictureBox2);
            this.control.Location = new System.Drawing.Point(200, 72);
            this.control.Name = "control";
            this.control.Size = new System.Drawing.Size(1196, 680);
            this.control.TabIndex = 2;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Capa_Presentacioon.Properties.Resources.itla_750;
            this.pictureBox2.Location = new System.Drawing.Point(0, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1110, 352);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Capa_Presentacioon.Properties.Resources.itla_logo_701;
            this.pictureBox3.Location = new System.Drawing.Point(12, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(165, 102);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // btsesion
            // 
            this.btsesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btsesion.FlatAppearance.BorderSize = 0;
            this.btsesion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(67)))), ((int)(((byte)(172)))));
            this.btsesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btsesion.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btsesion.Image = global::Capa_Presentacioon.Properties.Resources.volver_a_login_40;
            this.btsesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btsesion.Location = new System.Drawing.Point(6, 542);
            this.btsesion.Name = "btsesion";
            this.btsesion.Size = new System.Drawing.Size(197, 81);
            this.btsesion.TabIndex = 2;
            this.btsesion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btsesion.UseVisualStyleBackColor = false;
            this.btsesion.Click += new System.EventHandler(this.btsesion_Click);
            // 
            // btonsultar
            // 
            this.btonsultar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btonsultar.FlatAppearance.BorderSize = 0;
            this.btonsultar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(67)))), ((int)(((byte)(172)))));
            this.btonsultar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btonsultar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btonsultar.Image = global::Capa_Presentacioon.Properties.Resources.Historia1;
            this.btonsultar.Location = new System.Drawing.Point(-69, 374);
            this.btonsultar.Name = "btonsultar";
            this.btonsultar.Size = new System.Drawing.Size(263, 89);
            this.btonsultar.TabIndex = 1;
            this.btonsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btonsultar.UseVisualStyleBackColor = false;
            this.btonsultar.Click += new System.EventHandler(this.btonsultar_Click);
            // 
            // btegistrar
            // 
            this.btegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(32)))), ((int)(((byte)(40)))));
            this.btegistrar.FlatAppearance.BorderSize = 0;
            this.btegistrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(67)))), ((int)(((byte)(172)))));
            this.btegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btegistrar.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btegistrar.Image = global::Capa_Presentacioon.Properties.Resources.persona_40;
            this.btegistrar.Location = new System.Drawing.Point(-60, 219);
            this.btegistrar.Name = "btegistrar";
            this.btegistrar.Size = new System.Drawing.Size(263, 86);
            this.btegistrar.TabIndex = 0;
            this.btegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btegistrar.UseVisualStyleBackColor = false;
            this.btegistrar.Click += new System.EventHandler(this.btegistrar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Capa_Presentacioon.Properties.Resources.Salir;
            this.pictureBox1.Location = new System.Drawing.Point(1214, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 109);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(57)))), ((int)(((byte)(118)))));
            this.ClientSize = new System.Drawing.Size(1399, 752);
            this.Controls.Add(this.control);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Principal";
            this.Text = "Principal";
            this.titulo.ResumeLayout(false);
            this.titulo.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.control.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private System.Windows.Forms.Panel titulo;
        private System.Windows.Forms.Panel menu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btegistrar;
        private System.Windows.Forms.Button btonsultar;
        private System.Windows.Forms.Button btsesion;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel control;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}