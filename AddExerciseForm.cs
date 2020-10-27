using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkaitmeninisTreneris
{
    public partial class AddExerciseForm : Form
    {
        public static AddExerciseForm Current;
        public Action<Form> KeistiLanga;

        public AddExerciseForm(Action<Form> kl)
        {
            Current = this;
            InitializeComponent();
            KeistiLanga = kl;

            LoadPictureBt.Click += (s, e) => {
                // open file dialog   
                OpenFileDialog open = new OpenFileDialog();
                // image filters  
                open.Filter = "Image Files(*.jpg)|*.jpg";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    // display image in picture box  
                    AddNewExercisePB.BackgroundImage = new Bitmap(open.FileName);
                    AddNewExercisePB.BackgroundImageLayout = ImageLayout.Stretch;
                    // image file path
                    PicturePathTB.Text = open.FileName;
                }
            };
        }

        private void SaveNewExerciseBt_Click(object sender, EventArgs e)
        {
            PratimuKatalogasLINQDataContext db = new PratimuKatalogasLINQDataContext();
            RaumenuGrupe MuscleGroup = db.RaumenuGrupes.Where(x => x.MuscleGroup == MuscleGroupComboB.Text).Single();

            PratimaiTable pratimas = new PratimaiTable();

            pratimas.ExerciseName = ExerciseNameTB.Text;
            pratimas.MainMuscle = MuscleTB.Text;
            pratimas.ExtraMuscles = ExtraMusclesTB.Text;
            pratimas.Tools = ToolsTB.Text;
            pratimas.Photo = PicturePathTB.Text;

            MuscleGroup.PratimaiTables.Add(pratimas);

            db.SubmitChanges();
        }

        private void DontSaveNewExerciseBt_Click(object sender, EventArgs e)
        {
            KeistiLanga(Form1.Current);
        }
    }
}
