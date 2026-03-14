using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HTQuanLyThuCung.DataAccess;

namespace HTQuanLyThuCung.Controls
{
    public partial class CalendarView : UserControl
    {
        private DateTime _currentMonth;
        private int _userId;
        private Dictionary<DateTime, int> _petCountByDate;
        private Panel[,] _dayPanels;

        private const int ROWS = 6;
        private const int COLS = 7;

        public event EventHandler<DateTime> DateClicked;

        public CalendarView()
        {
            InitializeComponent();

            _currentMonth = DateTime.Today;
            _petCountByDate = new Dictionary<DateTime, int>();
            _dayPanels = new Panel[ROWS, COLS];

            InitializeCalendarLayout();
        }

        public void SetUserId(int userId)
        {
            _userId = userId;
            LoadPetsForMonth();
        }

        private void InitializeCalendarLayout()
        {
            this.SuspendLayout();
            this.Controls.Clear();
            this.BackColor = Color.White;
            this.Size = new Size(350, 320);

            Panel headerPanel = CreateHeaderPanel();
            this.Controls.Add(headerPanel);

            Panel weekDaysPanel = CreateWeekDaysPanel();
            this.Controls.Add(weekDaysPanel);

            Panel daysGrid = CreateDaysGrid();
            this.Controls.Add(daysGrid);

            this.ResumeLayout();
        }

        private Panel CreateHeaderPanel()
        {
            Panel panel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(350, 40),
                BackColor = Color.FromArgb(52, 152, 219)
            };

            Button btnPrev = new Button
            {
                Text = "◀",
                Location = new Point(10, 8),
                Size = new Size(35, 25),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White
            };

            btnPrev.FlatAppearance.BorderSize = 0;

            btnPrev.Click += (s, e) =>
            {
                _currentMonth = _currentMonth.AddMonths(-1);
                LoadPetsForMonth();
            };

            Label lblMonthYear = new Label
            {
                Name = "lblMonthYear",
                Text = _currentMonth.ToString("MMMM yyyy"),
                Location = new Point(50, 8),
                Size = new Size(250, 25),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold)
            };

            Button btnNext = new Button
            {
                Text = "▶",
                Location = new Point(305, 8),
                Size = new Size(35, 25),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(41, 128, 185),
                ForeColor = Color.White
            };

            btnNext.FlatAppearance.BorderSize = 0;

            btnNext.Click += (s, e) =>
            {
                _currentMonth = _currentMonth.AddMonths(1);
                LoadPetsForMonth();
            };

            panel.Controls.AddRange(new Control[] { btnPrev, lblMonthYear, btnNext });

            return panel;
        }

        private Panel CreateWeekDaysPanel()
        {
            Panel panel = new Panel
            {
                Location = new Point(0, 40),
                Size = new Size(350, 30),
                BackColor = Color.FromArgb(236, 240, 241)
            };

            string[] dayNames = { "CN", "T2", "T3", "T4", "T5", "T6", "T7" };

            int dayWidth = 50;

            for (int i = 0; i < 7; i++)
            {
                Label lbl = new Label
                {
                    Text = dayNames[i],
                    Location = new Point(i * dayWidth, 5),
                    Size = new Size(dayWidth, 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold)
                };

                panel.Controls.Add(lbl);
            }

            return panel;
        }

        private Panel CreateDaysGrid()
        {
            Panel panel = new Panel
            {
                Name = "pnlDaysGrid",
                Location = new Point(0, 70),
                Size = new Size(350, 250)
            };

            int dayWidth = 50;
            int dayHeight = 40;

            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    Panel dayPanel = new Panel
                    {
                        Location = new Point(col * dayWidth, row * dayHeight),
                        Size = new Size(dayWidth, dayHeight),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.White,
                        Tag = null
                    };

                    Label lblDay = new Label
                    {
                        Name = "lblDay",
                        Location = new Point(2, 2),
                        Size = new Size(46, 18),
                        TextAlign = ContentAlignment.TopRight,
                        Font = new Font("Segoe UI", 9F)
                    };

                    Label lblCount = new Label
                    {
                        Name = "lblPetCount",
                        Location = new Point(2, 20),
                        Size = new Size(46, 16),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 7F, FontStyle.Bold),
                        BackColor = Color.FromArgb(231, 76, 60),
                        ForeColor = Color.White,
                        Visible = false
                    };

                    dayPanel.Controls.Add(lblDay);
                    dayPanel.Controls.Add(lblCount);

                    dayPanel.Click += DayPanel_Click;

                    _dayPanels[row, col] = dayPanel;

                    panel.Controls.Add(dayPanel);
                }
            }

            return panel;
        }

        private void LoadPetsForMonth()
        {
            try
            {
                _petCountByDate.Clear();

                string query = @"
                SELECT CAST(CreatedDate AS DATE) AS PetDate, COUNT(*) AS PetCount
                FROM Pets
                WHERE YEAR(CreatedDate) = @Year
                AND MONTH(CreatedDate) = @Month
                GROUP BY CAST(CreatedDate AS DATE)
                ";

                DataTable dt = DatabaseHelper.ExecuteQuery(
                    query,
                    new System.Data.SqlClient.SqlParameter("@Year", _currentMonth.Year),
                    new System.Data.SqlClient.SqlParameter("@Month", _currentMonth.Month)
                );

                foreach (DataRow row in dt.Rows)
                {
                    DateTime date = Convert.ToDateTime(row["PetDate"]);
                    int count = Convert.ToInt32(row["PetCount"]);

                    _petCountByDate[date] = count;
                }

                UpdateCalendarDisplay();
            }
            catch
            {
            }
        }

        private void UpdateCalendarDisplay()
        {
            DateTime firstDayOfMonth = new DateTime(_currentMonth.Year, _currentMonth.Month, 1);

            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;

            int daysInMonth = DateTime.DaysInMonth(_currentMonth.Year, _currentMonth.Month);

            int dayNumber = 1;

            bool monthStarted = false;

            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    Panel panel = _dayPanels[row, col];

                    Label lblDay = panel.Controls["lblDay"] as Label;

                    Label lblCount = panel.Controls["lblPetCount"] as Label;

                    if (!monthStarted && row == 0 && col == startDayOfWeek)
                    {
                        monthStarted = true;
                    }

                    if (monthStarted && dayNumber <= daysInMonth)
                    {
                        DateTime currentDate = new DateTime(_currentMonth.Year, _currentMonth.Month, dayNumber);

                        lblDay.Text = dayNumber.ToString();

                        panel.Tag = currentDate;

                        if (_petCountByDate.ContainsKey(currentDate))
                        {
                            lblCount.Text = _petCountByDate[currentDate] + " pet";

                            lblCount.Visible = true;
                        }
                        else
                        {
                            lblCount.Visible = false;
                        }

                        dayNumber++;
                    }
                    else
                    {
                        lblDay.Text = "";

                        lblCount.Visible = false;

                        panel.Tag = null;
                    }
                }
            }
        }

        private void DayPanel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;

            if (panel?.Tag != null)
            {
                DateTime selectedDate = (DateTime)panel.Tag;

                DateClicked?.Invoke(this, selectedDate);
            }
        }
    }
}