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
    public partial class ExercisesForm : Form
    {
        public static ExercisesForm Current;
        public Action<Form> KeistiLanga;
        static SqlConnection Sql;

        public ExercisesForm(Action<Form> kl)
        {
            var ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\User\\Desktop\\C#\\Pamokos\\10_26 atsiskaitymas\\SkaitmeninisTreneris\\SkaitmeninisTreneris\\Pratimai.mdf\";Integrated Security = True";
            Sql = new SqlConnection(ConnectionString);
            Current = this;
            InitializeComponent();
            KeistiLanga = kl;

            PratimuKatalogasLINQDataContext db = new PratimuKatalogasLINQDataContext();
            List<PratimaiTable> exercises = db.PratimaiTables.Where(x => x.RaumenuGrupesId == MuscleGroupForm.muscleGroup).ToList();

            int objektuAtstumas = 10;

            foreach (var exercise in exercises)
            {
                Panel NewPanel = new Panel();
                NewPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
                NewPanel.Size = ExerciseP.Size;
                NewPanel.Location = new Point(ExerciseP.Location.X, ExerciseP.Location.Y + objektuAtstumas);
                RaumenuGrupesPasirinkimoP.Controls.Add(NewPanel);

                Label NewLabel = new Label();
                NewLabel.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                NewLabel.Size = new System.Drawing.Size(250, 20);
                NewLabel.Text = exercise.ExerciseName;
                NewLabel.Location = new Point(ExerciseNameL.Location.X, ExerciseNameL.Location.Y);
                NewPanel.Controls.Add(NewLabel);

                PictureBox NewPicture = new PictureBox();
                NewPicture.BackgroundImage = Image.FromFile(exercise.Photo);
                NewPicture.Size = ExercisePB.Size;
                NewPicture.BackgroundImageLayout = ImageLayout.Zoom;
                NewPicture.Location = new Point(ExercisePB.Location.X, ExercisePB.Location.Y);
                NewPanel.Controls.Add(NewPicture);

                Label infoL = new Label();
                infoL.Size = new System.Drawing.Size(250, 15);
                infoL.Text = "Would you like to add it to your schedule?";
                infoL.Location = new System.Drawing.Point(5, 70);
                NewPanel.Controls.Add(infoL);


                Button newAddButton = new Button();
                newAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                newAddButton.Location = new System.Drawing.Point(5, 90);
                newAddButton.Name = "AddToscheduleBt";
                newAddButton.Size = new System.Drawing.Size(100, 30);
                newAddButton.TabIndex = 5;
                newAddButton.Text = "Add";
                newAddButton.UseVisualStyleBackColor = true;
                NewPanel.Controls.Add(newAddButton);
                if (exercise.Patinka == true)
                {
                    newAddButton.BackColor = System.Drawing.Color.SpringGreen;
                }
                newAddButton.Click += (s, e) => {
                    UpdateArPatinka(NewLabel.Text, true);
                    if (exercise.Patinka == true)
                    {
                            newAddButton.BackColor = System.Drawing.Color.SpringGreen;
                    }
                };
                

                Button newRemoveButton = new Button();
                newRemoveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
                newRemoveButton.Location = new System.Drawing.Point(120, 90);
                newRemoveButton.Name = "AddToscheduleBt";
                newRemoveButton.Size = new System.Drawing.Size(100, 30);
                newRemoveButton.TabIndex = 5;
                newRemoveButton.Text = "Remove";
                newRemoveButton.UseVisualStyleBackColor = true;
                NewPanel.Controls.Add(newRemoveButton);
                if (exercise.Patinka == false)
                {
                    newAddButton.BackColor = System.Drawing.Color.SpringGreen;
                }
                newRemoveButton.Click += (s, e) => {
                    UpdateArPatinka(NewLabel.Text, false);
                    if (exercise.Patinka == false)
                    {
                        newAddButton.BackColor = System.Drawing.Color.SpringGreen;
                    }
                };
                

                objektuAtstumas += 150;
            }

            AddNewExerciseP.Click += (s, e) => {
                this.Visible = false;
                KeistiLanga(new AddExerciseForm(KeistiLanga));
            };
            

        }

        private void BackBt_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            KeistiLanga(Form1.Current);
        }

        static void UpdateArPatinka(string name, bool x)
        {
            var query = "UPDATE PratimaiTable Set Patinka = @patinka Where ExerciseName = @exerciseName";
            SqlCommand command = new SqlCommand(query, Sql);
            Sql.Open();
            command.Parameters.AddWithValue("@patinka", x);
            command.Parameters.AddWithValue("@exerciseName", name);
            command.ExecuteNonQuery();
            Sql.Close();
        }
    }
}
