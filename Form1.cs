using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkaitmeninisTreneris
{
    public partial class Form1 : Form
    {
        public static Form1 Current;
        public Action<Form> KeistiLanga;
        static PratimuKatalogasLINQDataContext db = new PratimuKatalogasLINQDataContext();
        public static int yKoordinateOfGroupBox = 20;

        public Form1(Action<Form> kl)
        {
            Current = this;
            InitializeComponent();
            KeistiLanga = kl;

            UserNameL.Text = $"user: {LoginForm.userName}";

            ExercisesBt.Click += (s, e) =>
            {
                this.Visible = false;
                KeistiLanga(new MuscleGroupForm(KeistiLanga));
            };

            SetScheduleL.Click += (s, e) =>
            {
                this.Visible = false;
                KeistiLanga(new SetScheduleForm(KeistiLanga));
                QuestionL.Visible = false;
                SetScheduleL.Visible = false;
                ShowBt.Visible = true;
            };

            //key => muscleGroup, value => diena;
            int yKoordinateOfTextBox = 40;

            ShowBt.Click += (s, e) => {
                ShowBt.Visible = false;

                foreach (var pratimas in SetScheduleForm.pratimai)
                {
                    string tipas = pratimas.Exercise;
                    string diena = pratimas.Day;
                    string tekstas = $"{diena}/{tipas}";
                    InformacijosSpausdinimasPagalPavadinima(tekstas, tipas, Form1P, yKoordinateOfTextBox, yKoordinateOfGroupBox);
                    yKoordinateOfGroupBox += 220;
                }
            };
        }

        public static void InformacijosSpausdinimasPagalPavadinima(string tekstas, string pavadinimas,Panel whereGroupBoxGoes, int yTB, int yGB)
        {
            RaumenuGrupe muscleGroup = db.RaumenuGrupes.Where(x => x.MuscleGroup == pavadinimas).Single();

            IEnumerable<RaumenuGrupe> pratimuTipas =
                from raumenuGrupe in db.RaumenuGrupes
                where raumenuGrupe.MuscleGroup == pavadinimas
                select raumenuGrupe;

            foreach (var i in pratimuTipas)
            {
                GroupBox NewGroupBox = new GroupBox();
                NewGroupBox.Location = new System.Drawing.Point(5, yGB);
                NewGroupBox.Size = new System.Drawing.Size(380, 200);
                NewGroupBox.TabStop = false;
                NewGroupBox.Text = tekstas;
                whereGroupBoxGoes.Controls.Add(NewGroupBox);

                Label exerciseL = new Label();
                exerciseL.Location = new System.Drawing.Point(8, -20 + yTB);
                exerciseL.Size = new System.Drawing.Size(60, 15);
                exerciseL.TabIndex = 13;
                exerciseL.Text = "Exercise name";
                NewGroupBox.Controls.Add(exerciseL);

                Label toolsL = new Label();
                toolsL.Location = new System.Drawing.Point(183, -20 + yTB);
                toolsL.Size = new System.Drawing.Size(60, 15);
                toolsL.TabIndex = 13;
                toolsL.Text = "Tools";
                NewGroupBox.Controls.Add(toolsL);

                Label setsL = new Label();
                setsL.Location = new System.Drawing.Point(275, -20 + yTB);
                setsL.Size = new System.Drawing.Size(30, 15);
                setsL.TabIndex = 13;
                setsL.Text = "Sets";
                NewGroupBox.Controls.Add(setsL);

                Label weightL = new Label();
                weightL.Location = new System.Drawing.Point(323, -20 + yTB);
                weightL.Size = new System.Drawing.Size(60, 15);
                weightL.TabIndex = 13;
                weightL.Text = "Weight";
                NewGroupBox.Controls.Add(weightL);

                if (pavadinimas == muscleGroup.MuscleGroup)
                {
                    IEnumerable<PratimaiTable> pratimas =
                    from pratimasTable in db.PratimaiTables
                    where pratimasTable.Patinka == true
                    where pratimasTable.RaumenuGrupesId == muscleGroup.Id
                    select pratimasTable;

                    foreach (var eilute in pratimas)
                    {
                        TextBox newNameTextBox = new TextBox();
                        newNameTextBox.Location = new System.Drawing.Point(5, yTB);
                        newNameTextBox.Name = "ExerciseNameTB";
                        newNameTextBox.Size = new System.Drawing.Size(150, 25);
                        newNameTextBox.TabIndex = 8;
                        newNameTextBox.Visible = true;
                        newNameTextBox.Text = eilute.ExerciseName;
                        NewGroupBox.Controls.Add(newNameTextBox);

                        TextBox newToolsTextBox = new TextBox();
                        newToolsTextBox.Location = new System.Drawing.Point(180, yTB);
                        newToolsTextBox.Name = "ExerciseNameTB";
                        newToolsTextBox.Size = new System.Drawing.Size(80, 25);
                        newToolsTextBox.TabIndex = 8;
                        newToolsTextBox.Visible = true;
                        newToolsTextBox.Text = eilute.Tools;
                        NewGroupBox.Controls.Add(newToolsTextBox);

                        Label numberOfSetsL = new Label();
                        numberOfSetsL.Location = new System.Drawing.Point(275, yTB);
                        numberOfSetsL.Size = new System.Drawing.Size(20, 15);
                        numberOfSetsL.TabIndex = 13;
                        numberOfSetsL.Text = "#4";
                        NewGroupBox.Controls.Add(numberOfSetsL);

                        TextBox newWeightTextBox = new TextBox();
                        newWeightTextBox.Location = new System.Drawing.Point(320, yTB);
                        newWeightTextBox.Name = "ExerciseNameTB";
                        newWeightTextBox.Size = new System.Drawing.Size(50, 25);
                        newWeightTextBox.TabIndex = 8;
                        newWeightTextBox.Visible = true;
                        newWeightTextBox.Text = eilute.Weight.ToString();
                        NewGroupBox.Controls.Add(newWeightTextBox);

                        yTB += 30;
                    }
                }
            }

            
            
        }
    }
}
