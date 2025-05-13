namespace ExportacionDB
{
    partial class FrmInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGuardarTXT = new System.Windows.Forms.Button();
            this.btnGuardarXML = new System.Windows.Forms.Button();
            this.cbTablas = new System.Windows.Forms.ComboBox();
            this.lblExportacion = new System.Windows.Forms.Label();
            this.lblNombreTabla = new System.Windows.Forms.Label();
            this.btnGuardarCSV = new System.Windows.Forms.Button();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardarTXT
            // 
            this.btnGuardarTXT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(124)))), ((int)(((byte)(112)))));
            this.btnGuardarTXT.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarTXT.Location = new System.Drawing.Point(438, 567);
            this.btnGuardarTXT.Name = "btnGuardarTXT";
            this.btnGuardarTXT.Size = new System.Drawing.Size(186, 43);
            this.btnGuardarTXT.TabIndex = 14;
            this.btnGuardarTXT.Text = "Guardar en TXT";
            this.btnGuardarTXT.UseVisualStyleBackColor = false;
            this.btnGuardarTXT.Click += new System.EventHandler(this.btnGuardarTXT_Click_1);
            // 
            // btnGuardarXML
            // 
            this.btnGuardarXML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(124)))), ((int)(((byte)(112)))));
            this.btnGuardarXML.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarXML.Location = new System.Drawing.Point(721, 567);
            this.btnGuardarXML.Name = "btnGuardarXML";
            this.btnGuardarXML.Size = new System.Drawing.Size(186, 43);
            this.btnGuardarXML.TabIndex = 15;
            this.btnGuardarXML.Text = "Guardar en XML";
            this.btnGuardarXML.UseVisualStyleBackColor = false;
            this.btnGuardarXML.Click += new System.EventHandler(this.btnGuardarXML_Click);
            // 
            // cbTablas
            // 
            this.cbTablas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTablas.FormattingEnabled = true;
            this.cbTablas.Location = new System.Drawing.Point(684, 132);
            this.cbTablas.Name = "cbTablas";
            this.cbTablas.Size = new System.Drawing.Size(253, 28);
            this.cbTablas.TabIndex = 11;
            this.cbTablas.SelectedIndexChanged += new System.EventHandler(this.cbTablas_SelectedIndexChanged);
            // 
            // lblExportacion
            // 
            this.lblExportacion.AutoSize = true;
            this.lblExportacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(124)))), ((int)(((byte)(112)))));
            this.lblExportacion.Font = new System.Drawing.Font("Mongolian Baiti", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExportacion.Location = new System.Drawing.Point(372, 32);
            this.lblExportacion.Name = "lblExportacion";
            this.lblExportacion.Size = new System.Drawing.Size(358, 40);
            this.lblExportacion.TabIndex = 17;
            this.lblExportacion.Text = "Exportación de Datos";
            // 
            // lblNombreTabla
            // 
            this.lblNombreTabla.AutoSize = true;
            this.lblNombreTabla.Font = new System.Drawing.Font("Mongolian Baiti", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreTabla.Location = new System.Drawing.Point(680, 110);
            this.lblNombreTabla.Name = "lblNombreTabla";
            this.lblNombreTabla.Size = new System.Drawing.Size(257, 19);
            this.lblNombreTabla.TabIndex = 16;
            this.lblNombreTabla.Text = "Elija la tabla que desea visualizar:";
            // 
            // btnGuardarCSV
            // 
            this.btnGuardarCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(124)))), ((int)(((byte)(112)))));
            this.btnGuardarCSV.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCSV.Location = new System.Drawing.Point(150, 567);
            this.btnGuardarCSV.Name = "btnGuardarCSV";
            this.btnGuardarCSV.Size = new System.Drawing.Size(186, 43);
            this.btnGuardarCSV.TabIndex = 12;
            this.btnGuardarCSV.Text = "Guardar en CSV";
            this.btnGuardarCSV.UseVisualStyleBackColor = false;
            this.btnGuardarCSV.Click += new System.EventHandler(this.btnGuardarCSV_Click);
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(124)))), ((int)(((byte)(112)))));
            this.btnCargarArchivo.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarArchivo.Location = new System.Drawing.Point(53, 120);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(158, 43);
            this.btnCargarArchivo.TabIndex = 10;
            this.btnCargarArchivo.Text = "Cargar archivo";
            this.btnCargarArchivo.UseVisualStyleBackColor = false;
            this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click);
            // 
            // dtgDatos
            // 
            this.dtgDatos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(232)))), ((int)(((byte)(220)))));
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos.Location = new System.Drawing.Point(53, 179);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.RowHeadersWidth = 51;
            this.dtgDatos.RowTemplate.Height = 24;
            this.dtgDatos.Size = new System.Drawing.Size(935, 330);
            this.dtgDatos.TabIndex = 13;
            this.dtgDatos.TabStop = false;
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1038, 643);
            this.Controls.Add(this.btnGuardarTXT);
            this.Controls.Add(this.btnGuardarXML);
            this.Controls.Add(this.cbTablas);
            this.Controls.Add(this.lblExportacion);
            this.Controls.Add(this.lblNombreTabla);
            this.Controls.Add(this.btnGuardarCSV);
            this.Controls.Add(this.btnCargarArchivo);
            this.Controls.Add(this.dtgDatos);
            this.Name = "FrmInicio";
            this.Text = "Inicio";
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardarTXT;
        private System.Windows.Forms.Button btnGuardarXML;
        private System.Windows.Forms.ComboBox cbTablas;
        private System.Windows.Forms.Label lblExportacion;
        private System.Windows.Forms.Label lblNombreTabla;
        private System.Windows.Forms.Button btnGuardarCSV;
        private System.Windows.Forms.Button btnCargarArchivo;
        public System.Windows.Forms.DataGridView dtgDatos;
    }
}

