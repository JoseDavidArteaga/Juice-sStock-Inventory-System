namespace JuiceStockProject.Presentacion.Proveedores
{
    partial class frmProveedores_Eliminar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProveedores_Eliminar));
            btnEliminarProveedores = new Button();
            label2 = new Label();
            cmbProveedores = new ComboBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnEliminarProveedores
            // 
            btnEliminarProveedores.BackColor = Color.FromArgb(255, 183, 3);
            btnEliminarProveedores.Cursor = Cursors.Hand;
            btnEliminarProveedores.FlatAppearance.BorderSize = 0;
            btnEliminarProveedores.FlatStyle = FlatStyle.Flat;
            btnEliminarProveedores.Font = new Font("Bahnschrift SemiCondensed", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEliminarProveedores.Location = new Point(239, 275);
            btnEliminarProveedores.Name = "btnEliminarProveedores";
            btnEliminarProveedores.Size = new Size(113, 38);
            btnEliminarProveedores.TabIndex = 15;
            btnEliminarProveedores.Text = "Eliminar";
            btnEliminarProveedores.UseVisualStyleBackColor = false;
            btnEliminarProveedores.Click += btnEliminarProveedores_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(176, 145);
            label2.Name = "label2";
            label2.Size = new Size(238, 20);
            label2.TabIndex = 14;
            label2.Text = "Seleccione el Proveedor a Eliminar";
            // 
            // cmbProveedores
            // 
            cmbProveedores.AutoCompleteMode = AutoCompleteMode.Suggest;
            cmbProveedores.AutoCompleteSource = AutoCompleteSource.ListItems;
            cmbProveedores.FormattingEnabled = true;
            cmbProveedores.Location = new Point(161, 170);
            cmbProveedores.Name = "cmbProveedores";
            cmbProveedores.Size = new Size(260, 28);
            cmbProveedores.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift SemiCondensed", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(166, 66);
            label1.Name = "label1";
            label1.Size = new Size(248, 34);
            label1.TabIndex = 12;
            label1.Text = "Eliminar Proveedores";
            // 
            // frmProveedores_Eliminar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 353);
            Controls.Add(btnEliminarProveedores);
            Controls.Add(label2);
            Controls.Add(cmbProveedores);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmProveedores_Eliminar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Eliminar Proveedores";
            Load += frmProveedores_Eliminar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEliminarProveedores;
        private Label label2;
        private ComboBox cmbProveedores;
        private Label label1;
    }
}