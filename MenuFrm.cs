using System;
using System.Windows.Forms;
using BL;

namespace GUI
{
    public partial class MenuFrm : Form
    {
        CreateList createList;
        ImageTesting imageTesting;

        public MenuFrm()
        {
            createList = new CreateList();
            imageTesting = new ImageTesting();
            InitializeComponent();
        }

        private void CreateFaceListBtn_Click(object sender, EventArgs e)
        {
            createList.CreateFaceList(this.createFaceListBtn);
        }

        private void AddWorkerBtn_Click(object sender, EventArgs e)
        {
        }

        private void UpdateProfileBtn_Click(object sender, EventArgs e)
        {
        }

        private void ImageTestingBtn_Click(object sender, EventArgs e)
        {
            imageTesting.CreateAndTestImage(label1);
        }

    }
}
