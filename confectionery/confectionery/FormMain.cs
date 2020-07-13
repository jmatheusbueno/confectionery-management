using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace confectionery
{
    public partial class formMain : System.Windows.Forms.Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        #region Events
        private void formMain_Load(object sender, EventArgs e)
        {
            HideButtons(SelectButtons());
            ShowMenuButtons(-1);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            HideButtons(SelectButtons());
            ShowMenuButtons(0);
        }
        private void btnProducts_Click(object sender, EventArgs e)
        {
            HideButtons(SelectButtons());
            ShowMenuButtons(2);
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            FormProducts frmProducts = new FormProducts();
            frmProducts.MdiParent = this;
            frmProducts.Show();
        }
        #endregion

        #region Private Methods
        private List<Button> SelectButtons()
        {
            List<Button> lstMenu = new List<Button>();
            foreach (Control btn in pnlMenu.Controls)
            {
                if (btn is Button)
                    lstMenu.Add(btn as Button);
            }

            return lstMenu;
        }

        private void HideButtons(List<Button> lst)
        {
            foreach (Button btn in lst)
            {
                btn.Hide();
            }
        }

        private void ShowMenuButtons(Int32 Position)
        {
            switch (Position)
            {
                case -1:
                    btnProducts.Location = btnPosition1.Location;
                    btnProducts.BackColor = btnPosition1.BackColor;
                    btnProducts.Show();
                    break;

                case 0:
                    btnProducts.Show();
                    this.IsMdiContainer = false;
                    break;

                case 2:
                    btnBack.Location = btnPosition0.Location;
                    btnBack.BackColor = btnPosition0.BackColor;
                    btnListProducts.Location = btnProducts.Location;
                    btnListProducts.BackColor = btnProducts.BackColor;
                    btnNewProduct.Location = btnPosition2.Location;
                    btnNewProduct.BackColor = btnProducts.BackColor;
                    btnBack.Show();
                    btnListProducts.Show();
                    btnNewProduct.Show();
                    break;
            }

        }
        #endregion

    }
}
