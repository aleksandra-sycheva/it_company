using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using it_company.models;

namespace it_company
{
    public partial class FormTasks : Form
    {
        private User _currentUser;
        private bool _isGuest;

        public FormTasks(User user, bool guest)
        {
            InitializeComponent();
            _currentUser = user;
            _isGuest = guest;

            SetupDataGridViewColumns();
            SetupUserInfo();
            LoadTasks();

            // Подписка на события
            btnLogout.Click += BtnLogout_Click;
        }

        private void SetupUserInfo()
        {
            if (_isGuest)
            {
                lbUser.Text = "Гость";
            }
            else
            {
                string fullName = _currentUser.FullName ?? "";

                if (string.IsNullOrWhiteSpace(fullName))
                {
                    fullName = _currentUser.Email;
                }

                lbUser.Text = fullName;
            }
        }

        private void SetupDataGridViewColumns()
        {
            dgvTasks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTasks.AllowUserToAddRows = false;
            dgvTasks.ReadOnly = true;
            dgvTasks.RowHeadersVisible = false;
            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTasks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTasks.Columns.Clear();

            var colTaskName = new DataGridViewTextBoxColumn
            {
                Name = "colTaskName",
                HeaderText = "Название задачи",
                FillWeight = 20,
                DefaultCellStyle = { WrapMode = DataGridViewTriState.True }
            };

            var colDescription = new DataGridViewTextBoxColumn
            {
                Name = "colDescription",
                HeaderText = "Описание",
                FillWeight = 25,
                DefaultCellStyle = { WrapMode = DataGridViewTriState.True }
            };

            var colStatus = new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Статус",
                FillWeight = 10,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            var colPriority = new DataGridViewTextBoxColumn
            {
                Name = "colPriority",
                HeaderText = "Приоритет",
                FillWeight = 8,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            var colProject = new DataGridViewTextBoxColumn
            {
                Name = "colProject",
                HeaderText = "Проект",
                FillWeight = 15
            };

            var colAssignee = new DataGridViewTextBoxColumn
            {
                Name = "colAssignee",
                HeaderText = "Исполнитель",
                FillWeight = 12
            };

            var colCreatedDate = new DataGridViewTextBoxColumn
            {
                Name = "colCreatedDate",
                HeaderText = "Дата создания",
                FillWeight = 10,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "dd.MM.yyyy" }
            };

            var colDueDate = new DataGridViewTextBoxColumn
            {
                Name = "colDueDate",
                HeaderText = "Срок выполнения",
                FillWeight = 10,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Format = "dd.MM.yyyy" }
            };

            var colDaysLeft = new DataGridViewTextBoxColumn
            {
                Name = "colDaysLeft",
                HeaderText = "Дней до дедлайна",
                FillWeight = 8,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            dgvTasks.Columns.AddRange(colTaskName, colDescription, colStatus, colPriority, colProject, colAssignee, colCreatedDate, colDueDate, colDaysLeft);
        }

        private void LoadTasks()
        {
            try
            {
                using (var db = new ItCompanyContext())
                {
                    var query = db.Tasks
                        .Include(t => t.Status)
                        .Include(t => t.Priority)
                        .Include(t => t.Project)
                        .Include(t => t.Assignee)
                        .AsQueryable();

                    // Для разработчика - только его задачи (role_id == 3)
                    if (!_isGuest && _currentUser?.RoleId == 3)
                    {
                        query = query.Where(t => t.AssigneeId == _currentUser.UserId);
                    }

                    var tasks = query
                        .OrderBy(t => t.DueDate)
                        .ToList();

                    DisplayTasks(tasks);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки задач: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayTasks(List<models.Task> tasks)
        {
            dgvTasks.SuspendLayout();
            dgvTasks.Rows.Clear();

            // Текущая дата для расчета дней до дедлайна
            DateOnly today = DateOnly.FromDateTime(DateTime.Today);

            foreach (var task in tasks)
            {
                string statusName = task.Status?.StatusName ?? "Неизвестно";
                string priorityName = task.Priority?.PriorityName ?? "Неизвестно";
                string projectName = task.Project?.ProjectName ?? "Неизвестно";

                // Используем FullName исполнителя
                string assigneeName = "Не назначен";
                if (task.Assignee != null)
                {
                    assigneeName = task.Assignee.FullName ?? task.Assignee.Email;
                    if (string.IsNullOrWhiteSpace(assigneeName))
                    {
                        assigneeName = task.Assignee.Email;
                    }
                }

                // РАСЧЕТ ДНЕЙ ДО ДЕДЛАЙНА
                // Если срок уже прошел - значение будет отрицательным
                int daysUntilDeadline = (task.DueDate.DayNumber - today.DayNumber);

                // Преобразование DateOnly в DateTime для отображения в DataGridView
                DateTime createdDate = new DateTime(task.CreatedDate.Year, task.CreatedDate.Month, task.CreatedDate.Day);
                DateTime dueDate = new DateTime(task.DueDate.Year, task.DueDate.Month, task.DueDate.Day);

                int rowIndex = dgvTasks.Rows.Add(
                    task.TaskName,
                    task.Description ?? "",
                    statusName,
                    priorityName,
                    projectName,
                    assigneeName,
                    createdDate,
                    dueDate,
                    daysUntilDeadline  // Отрицательное значение, если срок прошел
                );

                var row = dgvTasks.Rows[rowIndex];
                row.Tag = task.TaskId;

                // Настройка цвета ячейки "Дней до дедлайна" в зависимости от значения
                ColorDaysLeftCell(row, daysUntilDeadline);

                // Подсветка всей строки
                ApplyRowColor(row, statusName, priorityName, daysUntilDeadline);
            }

            dgvTasks.ResumeLayout();
            dgvTasks.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        private void ColorDaysLeftCell(DataGridViewRow row, int daysUntilDeadline)
        {
            var cell = row.Cells["colDaysLeft"];

            if (daysUntilDeadline < 0)
            {
                // Просрочено - красный текст
                cell.Style.ForeColor = Color.DarkRed;
                cell.Style.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                cell.Value = $"{daysUntilDeadline} дн. (просрочено)";
            }
            else if (daysUntilDeadline == 0)
            {
                // Сегодня дедлайн - оранжевый текст
                cell.Style.ForeColor = Color.DarkOrange;
                cell.Style.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                cell.Value = $"{daysUntilDeadline} дн. (сегодня)";
            }
            else if (daysUntilDeadline <= 3)
            {
                // Осталось 3 дня или меньше - желтый/оранжевый
                cell.Style.ForeColor = Color.DarkOrange;
                cell.Style.Font = new Font("Times New Roman", 12, FontStyle.Bold);
                cell.Value = $"{daysUntilDeadline} дн.";
            }
            else
            {
                // Нормальный срок - зеленый текст
                cell.Style.ForeColor = Color.Green;
                cell.Value = $"{daysUntilDeadline} дн.";
            }

            cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void ApplyRowColor(DataGridViewRow row, string statusName, string priorityName, int daysUntilDeadline)
        {
            // Правило 1: Высокий приоритет и статус не "Завершена" -> #FFF3CD
            if (priorityName == "Высокий" && statusName != "Завершена")
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FFF3CD");
            }

            // Правило 2: Срок истек (отрицательное значение) и статус не "Завершена" -> #F8D7DA
            if (daysUntilDeadline < 0 && statusName != "Завершена")
            {
                row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F8D7DA");
            }

            // Если задача завершена - серый фон
            if (statusName == "Завершена")
            {
                row.DefaultCellStyle.BackColor = Color.LightGray;
            }
        }

        private void BtnLogout_Click(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти из аккаунта?",
                "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                using (var formLogin = new FormLogin())
                {
                    var loginResult = formLogin.ShowDialog();
                    if (loginResult == DialogResult.OK)
                    {
                        var formTasks = new FormTasks(formLogin.CurrentUser, formLogin.IsGuest);
                        formTasks.ShowDialog();
                    }
                    else
                    {
                        Application.Exit();
                        return;
                    }
                }
                this.Close();
            }
        }
    }
}