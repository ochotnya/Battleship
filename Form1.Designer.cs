﻿
namespace Battleship
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
            this.panelBoards = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelBoards
            // 
            this.panelBoards.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBoards.Location = new System.Drawing.Point(0, 0);
            this.panelBoards.Name = "panelBoards";
            this.panelBoards.Size = new System.Drawing.Size(956, 603);
            this.panelBoards.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 671);
            this.Controls.Add(this.panelBoards);
            this.Name = "Form1";
            this.Text = "Battleship Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBoards;
    }
}

