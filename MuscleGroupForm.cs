using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkaitmeninisTreneris
{
    public partial class MuscleGroupForm : Form
    {
        public static MuscleGroupForm Current;
        public Action<Form> KeistiLanga;
        public static int muscleGroup;

        public MuscleGroupForm(Action<Form> kl)
        {
            Current = this;
            InitializeComponent();
            KeistiLanga = kl;

            UserNameL.Text = $"user: {LoginForm.userName}";

            PratimuKatalogasLINQDataContext db = new PratimuKatalogasLINQDataContext();
            List<RaumenuGrupe> raumenuGrupes = db.RaumenuGrupes.ToList();

            int objektuAtstumas = 0;

            foreach (var raumenuGrupe in raumenuGrupes)
            {

                Panel NewPanel = new Panel();
                NewPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
                NewPanel.Size = MuscleGroupP.Size;
                NewPanel.Location = new Point(MuscleGroupP.Location.X, MuscleGroupP.Location.Y + objektuAtstumas);
                RaumenuGrupesPasirinkimoP.Controls.Add(NewPanel);
                NewPanel.Click += (s, e) => {
                    muscleGroup = raumenuGrupe.Id;

                    this.Visible = false;
                    KeistiLanga(new ExercisesForm(KeistiLanga));
                };

                Label NewLabel = new Label();
                NewLabel.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NewLabel.Text = raumenuGrupe.MuscleGroup;
                NewLabel.Size = MuscleGroupNameL.Size;
                NewLabel.Location = new Point(MuscleGroupNameL.Location.X, MuscleGroupNameL.Location.Y);
                NewPanel.Controls.Add(NewLabel);

                PictureBox NewPicture = new PictureBox();
                NewPicture.BackgroundImage = Image.FromFile(raumenuGrupe.MuscleGroupPhoto);
                NewPicture.Size = MuscleGroupPB.Size;
                NewPicture.BackgroundImageLayout = ImageLayout.Zoom;
                NewPicture.Location = new Point(MuscleGroupPB.Location.X, MuscleGroupPB.Location.Y);
                NewPanel.Controls.Add(NewPicture);

                objektuAtstumas += 150;
            }
        }

        private void BackBt_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            KeistiLanga(Form1.Current);
        }
    }
}
