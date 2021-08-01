
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
            this.components = new System.ComponentModel.Container();
            this.panelBoards = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnP1Fire = new System.Windows.Forms.Button();
            this.btnP2Fire = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
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
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(12, 609);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(131, 42);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "New positions";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnP1Fire
            // 
            this.btnP1Fire.Location = new System.Drawing.Point(199, 609);
            this.btnP1Fire.Name = "btnP1Fire";
            this.btnP1Fire.Size = new System.Drawing.Size(131, 42);
            this.btnP1Fire.TabIndex = 2;
            this.btnP1Fire.Text = "Player 1 Fire";
            this.btnP1Fire.UseVisualStyleBackColor = true;
            this.btnP1Fire.Click += new System.EventHandler(this.btnP1Fire_Click);
            // 
            // btnP2Fire
            // 
            this.btnP2Fire.Location = new System.Drawing.Point(702, 609);
            this.btnP2Fire.Name = "btnP2Fire";
            this.btnP2Fire.Size = new System.Drawing.Size(131, 42);
            this.btnP2Fire.TabIndex = 3;
            this.btnP2Fire.Text = "Player 2 Fire";
            this.btnP2Fire.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 673);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(109, 138);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // timer
            // 
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 705);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 823);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnP2Fire);
            this.Controls.Add(this.btnP1Fire);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panelBoards);
            this.Name = "Form1";
            this.Text = "Battleship Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBoards;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnP1Fire;
        private System.Windows.Forms.Button btnP2Fire;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label1;
    }
}

