namespace EstructurasGrafos
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
            lstResultados = new ListBox();
            txtOrigen = new TextBox();
            txtDestino = new TextBox();
            btnCargarGrafo = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // lstResultados
            // 
            lstResultados.FormattingEnabled = true;
            lstResultados.Location = new Point(26, 193);
            lstResultados.Name = "lstResultados";
            lstResultados.Size = new Size(844, 514);
            lstResultados.TabIndex = 0;
            // 
            // txtOrigen
            // 
            txtOrigen.Location = new Point(108, 36);
            txtOrigen.Name = "txtOrigen";
            txtOrigen.Size = new Size(175, 35);
            txtOrigen.TabIndex = 1;
            // 
            // txtDestino
            // 
            txtDestino.Location = new Point(392, 38);
            txtDestino.Name = "txtDestino";
            txtDestino.Size = new Size(175, 35);
            txtDestino.TabIndex = 2;
            // 
            // btnCargarGrafo
            // 
            btnCargarGrafo.Location = new Point(26, 118);
            btnCargarGrafo.Name = "btnCargarGrafo";
            btnCargarGrafo.Size = new Size(175, 40);
            btnCargarGrafo.TabIndex = 3;
            btnCargarGrafo.Text = "Cargar grafo";
            btnCargarGrafo.UseVisualStyleBackColor = true;
            btnCargarGrafo.Click += btnCargarGrafo_Click;
            // 
            // button2
            // 
            button2.Location = new Point(265, 118);
            button2.Name = "button2";
            button2.Size = new Size(241, 40);
            button2.TabIndex = 4;
            button2.Text = "Calcular Ruta (Dijkstra)";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(557, 118);
            button3.Name = "button3";
            button3.Size = new Size(208, 40);
            button3.TabIndex = 5;
            button3.Text = "Ver Matriz";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 41);
            label1.Name = "label1";
            label1.Size = new Size(76, 30);
            label1.TabIndex = 6;
            label1.Text = "Origen";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(302, 41);
            label2.Name = "label2";
            label2.Size = new Size(84, 30);
            label2.TabIndex = 7;
            label2.Text = "Destino";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1514, 817);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(btnCargarGrafo);
            Controls.Add(txtDestino);
            Controls.Add(txtOrigen);
            Controls.Add(lstResultados);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstResultados;
        private TextBox txtOrigen;
        private TextBox txtDestino;
        private Button btnCargarGrafo;
        private Button button2;
        private Button button3;
        private Label label1;
        private Label label2;
    }
}
