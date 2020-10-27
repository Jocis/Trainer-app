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
    public partial class SetScheduleForm : Form
    {
        public static Form1 Current;
        public Action<Form> KeistiLanga;
        public static List<DayAndExercise> pratimai = new List<DayAndExercise>();

        public SetScheduleForm(Action<Form> kl)
        {
            InitializeComponent();
            KeistiLanga = kl;

            //GROUP BOX 1//////////////////////////////////////////////////////////////
            Button button1 = new Button();
            button1.Font = new System.Drawing.Font("Poor Richard", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button1.Location = new System.Drawing.Point(250, 165);
            button1.Size = new System.Drawing.Size(80, 30);
            button1.TabIndex = 5;
            button1.Text = "Next>>";
            button1.UseVisualStyleBackColor = true;
            QuestionGB.Controls.Add(button1);

            //OTHER GROUP BOXES//////////////////////////////////////////////////////////////
            int xKoordinate = 15;
            int yKoordinate = 235;
            int question = 1;

            button1.Click += (s, e) => {
                if (PirmadienisCB.Checked == true)
                {
                    question++;
                    GettingSceduleValuesFunction(question, xKoordinate, yKoordinate, SetScheduleP, QuestionL, PirmadienisCB, "pirmadieni");
                    yKoordinate += 220;
                }
                if (AntradienisCB.Checked == true)
                {
                    question++;
                    GettingSceduleValuesFunction(question, xKoordinate, yKoordinate, SetScheduleP, QuestionL, AntradienisCB, "antradieni");
                    yKoordinate += 220;
                }
                if (TreciadienisCB.Checked == true)
                {
                    question++;
                    GettingSceduleValuesFunction(question, xKoordinate, yKoordinate, SetScheduleP, QuestionL, TreciadienisCB, "treciadieni");
                    yKoordinate += 220;
                }
                if (KetvirtadienisCB.Checked == true)
                {
                    question++;
                    GettingSceduleValuesFunction(question, xKoordinate, yKoordinate, SetScheduleP, QuestionL, KetvirtadienisCB, "ketvirtadieni");
                    yKoordinate += 220;
                }
                if (PenktadienisCB.Checked == true)
                {
                    question++;
                    GettingSceduleValuesFunction(question, xKoordinate, yKoordinate, SetScheduleP, QuestionL, PenktadienisCB, "penktadieni");
                    yKoordinate += 220;
                }
                if (SestadienisCB.Checked == true)
                {
                    question++;
                    GettingSceduleValuesFunction(question, xKoordinate, yKoordinate, SetScheduleP, QuestionL, SestadienisCB, "sestadieni");
                    yKoordinate += 220;
                }
                if (SekmadienisCB.Checked == true)
                {
                    question++;
                    GettingSceduleValuesFunction(question, xKoordinate, yKoordinate, SetScheduleP, QuestionL, SekmadienisCB, "sekmadieni");
                }
            };

            DoneBt.Click += (s, e) => {
                this.Visible = false;
                KeistiLanga(Form1.Current);
            };
        }

        public static void GettingSceduleValuesFunction(int question, int xKoordinate, int yKoordinate, Panel panel, Label label, CheckBox checkBox, string day)
        {
            GroupBox NewGroupBox = new GroupBox();
            NewGroupBox.Location = new System.Drawing.Point(xKoordinate, yKoordinate);
            NewGroupBox.Size = new System.Drawing.Size(357, 200);
            NewGroupBox.TabIndex = 1;
            NewGroupBox.TabStop = false;
            NewGroupBox.Text = $"#{question} question";
            panel.Controls.Add(NewGroupBox);

            Label NewLabel = new Label();
            NewLabel.Font = new System.Drawing.Font("Showcard Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            NewLabel.Text = $"Kokia treniruote darysi {day}?";
            NewLabel.Size = new Size(300, 30);
            NewLabel.Location = new Point(label.Location.X, label.Location.Y);
            NewGroupBox.Controls.Add(NewLabel);

            ComboBox newComboBox = new ComboBox();
            newComboBox.FormattingEnabled = true;
            newComboBox.Items.AddRange(new object[] {
                    "Chest",
                    "Back",
                    "Arms",
                    "Abdominals",
                    "Legs",
                    "Shoulders"});
            newComboBox.Location = new System.Drawing.Point(15, 60);
            newComboBox.Size = new System.Drawing.Size(200, 25);
            newComboBox.TabIndex = 1;
            NewGroupBox.Controls.Add(newComboBox);

            Button button = new Button();
            button.Font = new System.Drawing.Font("Poor Richard", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            button.Location = new System.Drawing.Point(250, 165);
            button.Size = new System.Drawing.Size(80, 30);
            button.TabIndex = 5;
            button.Text = "Save";
            button.UseVisualStyleBackColor = true;
            NewGroupBox.Controls.Add(button);

            button.Click += (s, e) => {
                button.BackColor = System.Drawing.Color.SpringGreen;
                pratimai.Add(new DayAndExercise(checkBox.Name, newComboBox.SelectedItem.ToString()));
            };
            
        }
    }

    public class DayAndExercise
    {
        public string Day { get; }
        public string Exercise { get; }

        public DayAndExercise (string day, string exercise)
        {
            Day = day;
            Exercise = exercise;
        }
    }
}
