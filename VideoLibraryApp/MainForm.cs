using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VideoLibraryApp
{
    public partial class MainForm : Form
    {
        private bool _isAdmin = false;
        private string _currentUsername = "Потребител";
        private int _userId;

        private static readonly Color BtnHover = Color.FromArgb(50, 62, 88);
        private static readonly Color BtnActive = Color.FromArgb(255, 200, 100);
        private static readonly Color BtnNormal = Color.FromArgb(38, 48, 70);

        private CassettesView _cassettesView;
        private MyFilmsView _myFilmsView;
        private UsersView _usersView;
        private Button _activeMenuButton;

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(bool isAdmin, string username, int userId = 0) : this()
        {
            _isAdmin = isAdmin;
            _currentUsername = username;
            _userId = userId;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                lblLogo.Text = "🎬";
                lblWelcome.Text = "Добре дошли, " + _currentUsername + "!";
                lblTitle.Text = "ВИДЕОТЕКА";
                lblSubtitle.Text = "Вашата колекция от филмови заглавия";
                lblContentTitle.Text = "Добре дошли във Видеотека!";
                lblContentSubtitle.Text = "Изберете опция от менюто вляво:\r\n\r\n" +
                    "• Преглед касети – разгледайте и добавяйте филми\r\n" +
                    "• Моите филми – филмите, които сте запазили\r\n" +
                    "• Потребители – управление (само за администратори)";
                btnCassettes.Text = "   Преглед касети";
                btnMyFilms.Text = "   Моите филми";
                btnUsers.Text = "   Потребители";
                btnLogout.Text = "   Изход";
                lblSidebarTitle.Text = "МЕНЮ";
                this.Text = "Видеотека – Главно меню";
                ApplyAdminRestrictions();
                SetActiveButton(null);
                SetupButtonHoverEffects();
            }
        }

        private void SetupButtonHoverEffects()
        {
            foreach (Control c in pnlSidebar.Controls)
            {
                if (c is Button btn && btn != btnLogout)
                {
                    btn.MouseEnter += (s, ev) =>
                    {
                        if (btn != _activeMenuButton)
                        {
                            btn.BackColor = BtnHover;
                            btn.Cursor = Cursors.Hand;
                        }
                    };
                    btn.MouseLeave += (s, ev) =>
                    {
                        btn.BackColor = (btn == _activeMenuButton) ? BtnActive : BtnNormal;
                    };
                }
            }
        }

        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {
            if (DesignMode || pnlHeader == null) return;
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (var pen = new Pen(Color.FromArgb(60, 255, 200, 100), 3))
            {
                g.DrawLine(pen, 0, 99, pnlHeader.Width, 99);
            }
        }

        private void PnlSidebar_Paint(object sender, PaintEventArgs e)
        {
            if (DesignMode) return;
            var g = e.Graphics;
            using (var pen = new Pen(Color.FromArgb(40, 255, 200, 100), 1))
            {
                g.DrawLine(pen, pnlSidebar.Width - 1, 0, pnlSidebar.Width - 1, pnlSidebar.Height);
            }
        }

        private void ApplyAdminRestrictions()
        {
            btnUsers.Visible = _isAdmin;
        }

        private void ShowCassettes()
        {
            SetActiveButton(btnCassettes);
            if (_cassettesView == null)
                _cassettesView = new CassettesView(_isAdmin, _userId, () => { _myFilmsView?.LoadSavedFilms(); });
            _cassettesView.LoadCassettes();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(_cassettesView);
            _cassettesView.Dock = DockStyle.Fill;
        }

        private void ShowMyFilms()
        {
            SetActiveButton(btnMyFilms);
            if (_myFilmsView == null)
                _myFilmsView = new MyFilmsView(_userId);
            _myFilmsView.LoadSavedFilms();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(_myFilmsView);
            _myFilmsView.Dock = DockStyle.Fill;
        }

        private void ShowUsers()
        {
            if (!_isAdmin) return;
            SetActiveButton(btnUsers);
            if (_usersView == null)
                _usersView = new UsersView(_userId);
            _usersView.LoadUsers();
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(_usersView);
            _usersView.Dock = DockStyle.Fill;
        }

        private void SetActiveButton(Button active)
        {
            _activeMenuButton = active;
            btnCassettes.BackColor = active == btnCassettes ? BtnActive : BtnNormal;
            btnCassettes.ForeColor = active == btnCassettes ? Color.FromArgb(15, 22, 36) : Color.FromArgb(235, 238, 245);
            btnCassettes.Font = new Font("Segoe UI", active == btnCassettes ? 11F : 10.5F, active == btnCassettes ? FontStyle.Bold : FontStyle.Regular);

            btnMyFilms.BackColor = active == btnMyFilms ? BtnActive : BtnNormal;
            btnMyFilms.ForeColor = active == btnMyFilms ? Color.FromArgb(15, 22, 36) : Color.FromArgb(235, 238, 245);
            btnMyFilms.Font = new Font("Segoe UI", active == btnMyFilms ? 11F : 10.5F, active == btnMyFilms ? FontStyle.Bold : FontStyle.Regular);

            btnUsers.BackColor = active == btnUsers ? BtnActive : BtnNormal;
            btnUsers.ForeColor = active == btnUsers ? Color.FromArgb(15, 22, 36) : Color.FromArgb(235, 238, 245);
            btnUsers.Font = new Font("Segoe UI", active == btnUsers ? 11F : 10.5F, active == btnUsers ? FontStyle.Bold : FontStyle.Regular);
        }

        private void BtnCassettes_Click(object sender, EventArgs e) => ShowCassettes();

        private void BtnMyFilms_Click(object sender, EventArgs e) => ShowMyFilms();

        private void BtnUsers_Click(object sender, EventArgs e) => ShowUsers();

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Сигурни ли сте, че искате да излезете?", "Изход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }
    }
}
