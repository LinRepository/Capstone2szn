using System;
using System.Drawing;
using System.Windows.Forms;
using Capstoneszn.Forms;
using Capstoneszn.Forms.BuildingForms;
using Capstoneszn.UserControls;

namespace Capstoneszn
{
    /// <summary>
    /// NEW (UI improvement): shows which module is open.
    ///
    /// The open module's sidebar button gets a lighter background, bold text
    /// and a gold bar on its left edge. The bar still shows when the sidebar
    /// is collapsed and the button text is hidden.
    ///
    /// SetActiveModule is called from LoadControl and looks at WHAT was
    /// loaded, not which button was clicked. So it also stays correct when a
    /// module is opened some other way: the View All buttons on Home, the
    /// backup reminder, or a notification card that opens Bill Management.
    /// </summary>
    public partial class MainForm
    {
        private const int NavBarWidth = 5;

        private Button? _activeNavButton;
        private Font? _navNormalFont;
        private Font? _navActiveFont;
        private Color _bellNormalBack;

        private void SetActiveModule(UserControl module)
        {
            if (_navActiveFont == null)
                PrepareNavButtons();

            // The sub-screens of a module (for example a room inside Bill
            // Management) open on top of it, so its button stays selected.
            Button? next = module switch
            {
                HomeControl => btnHome,
                TenantsControl => btnTenants,
                RoomsControl => btnRooms,
                UtilitiesControl => btnUtilities,
                MaintenanceControl => btnMaintenance,
                BillingManagementControl => btnBillingManagement,
                ReportsControl => btnReports,
                PaymentHistoryControl => btnPaymentHistory,
                EmployeeControl => btnEmployee,
                AuditLogsControl => btnAuditLogs,
                SettingsControl => btnSettings,
                _ => null
            };

            if (_activeNavButton != null)
                MarkNavButton(_activeNavButton, false);

            _activeNavButton = next;

            if (next != null)
                MarkNavButton(next, true);

            // Notifications open from the bell, not from the sidebar.
            btnNotification.BackColor =
                module is Capstoneszn.Forms.UserControls.NotificationControl
                    ? UiTheme.Selection
                    : _bellNormalBack;
        }

        private void PrepareNavButtons()
        {
            _navNormalFont = btnHome.Font;
            _navActiveFont = new Font(btnHome.Font, FontStyle.Bold);
            _bellNormalBack = btnNotification.BackColor;

            foreach (Control control in flpNavigation.Controls)
            {
                if (control is Button button)
                {
                    button.FlatAppearance.MouseDownBackColor = UiTheme.Selection;
                    button.Paint += NavButton_Paint;
                    MarkNavButton(button, false);
                }
            }
        }

        private void MarkNavButton(Button button, bool active)
        {
            button.UseVisualStyleBackColor = false;
            button.BackColor = active ? UiTheme.Selection : pnlSideBar.BackColor;
            button.FlatAppearance.MouseOverBackColor = active ? UiTheme.Selection : UiTheme.TitleBar;
            button.Font = active ? _navActiveFont! : _navNormalFont!;
            button.Invalidate();   // redraws the gold bar
        }

        // A WinForms button cannot have a border on one side only, so the bar is drawn.
        private void NavButton_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is Button button && ReferenceEquals(button, _activeNavButton))
            {
                using (SolidBrush bar = new SolidBrush(UiTheme.Accent))
                {
                    e.Graphics.FillRectangle(bar, 0, 0, NavBarWidth, button.Height);
                }
            }
        }
    }
}
