using System.Drawing;
using System.Windows.Forms;

namespace Capstoneszn.UserControls
{
    /// <summary>
    /// NEW (UI improvement): the look and layout of the Tenants module.
    ///
    /// Appearance only. Every label, column, button and click event is the
    /// one from the Designer, and no text or data changes. It is kept in its
    /// own file so TenantsControl.Designer.cs stays untouched; to go back to
    /// the old look, comment out ApplyTenantsTheme() in the constructor.
    ///
    /// Because this runs at runtime, the Designer view in Visual Studio still
    /// shows the old look. The new look appears when the program runs.
    /// </summary>
    public partial class TenantsControl
    {
        private const int DetailRowHeight = 34;

        private void ApplyTenantsTheme()
        {
            StyleToolbar();
            StyleTenantGrid();
            StyleDetailsHeader();
            StyleTenantInfo();
            StyleBillingSummary();
            AddDetailsGap();

            // The grid takes the full width while no tenant is selected.
            pnlTenantDetails.VisibleChanged += (s, e) => UpdateDetailsColumn();
            UpdateDetailsColumn();
        }

        /* =================================================================
           TITLE AND SEARCH - one row, so the grid gets the saved height
           ================================================================= */

        private void StyleToolbar()
        {
            pnlSearch.Padding = new Padding(10, 13, 10, 13);

            lblTenantsTitle.Font = new Font("Segoe UI Semibold", 20F);
            lblTenantsTitle.TextAlign = ContentAlignment.MiddleLeft;

            // The search box moves up beside the title; its old row is hidden.
            pnlSearch.Controls.Add(pnlSearchContainer);
            pnlSearchContainer.Dock = DockStyle.Right;
            pnlSearchContainer.Width = 380;
            pnlSearchContainer.BorderStyle = BorderStyle.None;
            pnlSearchContainer.BackColor = Color.White;
            pnlSearchContainer.Padding = new Padding(10, 8, 10, 4);
            pnlSearchContent.Visible = false;

            lblTenantsTitle.BringToFront();   // Fill must dock last

            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.TextAlign = HorizontalAlignment.Left;
        }

        /* =================================================================
           TENANT LIST
           ================================================================= */

        private void StyleTenantGrid()
        {
            pnlTenantContent.BorderStyle = BorderStyle.None;
            pnlTenantList.Padding = new Padding(10, 0, 10, 10);
            pnlTenantDetails.Padding = new Padding(0, 0, 10, 10);

            UiTheme.StyleGrid(dgvTenants);

            // Narrow column for Room, more room for the long text columns.
            colRoom.FillWeight = 60F;
            colFname.FillWeight = 105F;
            colMname.FillWeight = 95F;
            colLname.FillWeight = 105F;
            colAddress.FillWeight = 125F;
            colContactNumber.FillWeight = 130F;
            colDateOccupied.FillWeight = 115F;
        }

        private void UpdateDetailsColumn()
        {
            bool detailsOpen = pnlTenantDetails.Visible;

            tblTenantSplit.ColumnStyles[0].Width = detailsOpen ? 70F : 100F;
            tblTenantSplit.ColumnStyles[1].Width = detailsOpen ? 30F : 0F;
        }

        /* =================================================================
           TENANT INFORMATION
           ================================================================= */

        private void StyleDetailsHeader()
        {
            pnlTenantDetailsHeader.BackColor = UiTheme.TitleBar;
            pnlTenantDetailsHeader.Padding = new Padding(12, 6, 6, 6);

            lblTenantDetailsTitle.Dock = DockStyle.Fill;
            lblTenantDetailsTitle.Padding = new Padding(0);
            lblTenantDetailsTitle.Font = new Font("Segoe UI Semibold", 12F);
            lblTenantDetailsTitle.TextAlign = ContentAlignment.MiddleLeft;

            UiTheme.StyleButton(btnEditTenant);
            UiTheme.StyleButton(btnCloseTenantDetails);
            btnEditTenant.Dock = DockStyle.Right;
            btnEditTenant.Width = 72;

            Panel buttonGap = new Panel { Dock = DockStyle.Right, Width = 6 };
            pnlTenantDetailsHeader.Controls.Add(buttonGap);

            // Docking runs from the highest index down, so this gives
            // [ Title ............ Edit | gap | X ]
            pnlTenantDetailsHeader.Controls.SetChildIndex(lblTenantDetailsTitle, 0);
            pnlTenantDetailsHeader.Controls.SetChildIndex(btnEditTenant, 1);
            pnlTenantDetailsHeader.Controls.SetChildIndex(buttonGap, 2);
            pnlTenantDetailsHeader.Controls.SetChildIndex(btnCloseTenantDetails, 3);
        }

        private void StyleTenantInfo()
        {
            pnlTenantInfo.BorderStyle = BorderStyle.None;
            pnlTenantInfo.BackColor = UiTheme.Card;
            pnlTenantInfo.Padding = new Padding(12, 6, 12, 6);
            pnlTenantInfo.Height = DetailRowHeight * 7 + 12;

            foreach (Label title in new[]
                     {
                         lblRoomNumberTitle, lblDateOccupiedTitle, lblFirstNameTitle,
                         lblMiddleNameTitle, lblLastNameTitle, lblAddressTitle,
                         lblContactNumberTitle
                     })
            {
                StyleField(title, ContentAlignment.MiddleLeft);
                title.ForeColor = UiTheme.MutedText;
            }

            foreach (Label value in new[]
                     {
                         lblRoomValue, lblDateOccupiedValue, lblFirstNameValue,
                         lblMiddleNameValue, lblLastNameValue, lblAddressValue,
                         lblContactNumberValue
                     })
            {
                StyleField(value, ContentAlignment.MiddleLeft);
            }

            tblTenantInfo.CellPaint += DrawRowLine;
        }

        /* =================================================================
           BILLING SUMMARY

           Value colours stay in LoadTenantBillingSummary: Salmon = owed,
           PaleGreen = paid ahead. Only their position and font change here.
           ================================================================= */

        private void StyleBillingSummary()
        {
            pnlBillingSummary.BackColor = UiTheme.Card;

            pnlBillingSummaryHeader.BorderStyle = BorderStyle.None;
            pnlBillingSummaryHeader.BackColor = UiTheme.TitleBar;
            pnlBillingSummaryHeader.Padding = new Padding(12, 0, 12, 0);

            lblBillingSummary.Dock = DockStyle.Fill;
            lblBillingSummary.Font = new Font("Segoe UI Semibold", 12F);
            lblBillingSummary.TextAlign = ContentAlignment.MiddleLeft;

            // Fixed row heights close the large gaps between the rows.
            tblBillingSummary.Dock = DockStyle.Top;
            tblBillingSummary.Height = DetailRowHeight * 5;
            tblBillingSummary.Padding = new Padding(12, 0, 12, 0);
            tblBillingSummary.ColumnStyles[0].Width = 60F;
            tblBillingSummary.ColumnStyles[1].Width = 40F;
            foreach (RowStyle row in tblBillingSummary.RowStyles)
            {
                row.SizeType = SizeType.Absolute;
                row.Height = DetailRowHeight;
            }

            foreach (Label title in new[]
                     {
                         lblRentBill, lblMaintenanceBill, lblElectricityBill, lblWaterBill
                     })
            {
                StyleField(title, ContentAlignment.MiddleLeft);
                title.ForeColor = UiTheme.MutedText;
            }

            foreach (Label value in new[]
                     {
                         lblRentBillValue, lblMaintenanceBillValue,
                         lblElectricityBillValue, lblWaterBillValue
                     })
            {
                StyleField(value, ContentAlignment.MiddleRight);
            }

            // The balance is the row people look for first.
            StyleField(lblAvaialbleBalance, ContentAlignment.MiddleLeft);
            StyleField(lblAvailableBalanceValue, ContentAlignment.MiddleRight);
            lblAvaialbleBalance.Font = new Font("Segoe UI Semibold", 10F);
            lblAvailableBalanceValue.Font = new Font("Segoe UI Semibold", 10F);

            tblBillingSummary.CellPaint += DrawRowLine;

            // View Details and Generate Statement move under the figures.
            TableLayoutPanel actions = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 56,
                ColumnCount = 2,
                RowCount = 1,
                Padding = new Padding(12, 10, 12, 10)
            };
            actions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            actions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            actions.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            actions.Controls.Add(btnViewDetails, 0, 0);
            actions.Controls.Add(btnGenerateStatement, 1, 0);

            UiTheme.StyleButton(btnViewDetails);
            UiTheme.StyleButton(btnGenerateStatement);
            btnViewDetails.Dock = DockStyle.Fill;
            btnGenerateStatement.Dock = DockStyle.Fill;
            btnViewDetails.Margin = new Padding(0, 0, 4, 0);
            btnGenerateStatement.Margin = new Padding(4, 0, 0, 0);

            pnlBillingSummary.Controls.Add(actions);

            // Top-docked controls stack from the highest index down:
            // header, then the figures, then the buttons.
            pnlBillingSummary.Controls.SetChildIndex(actions, 0);
            pnlBillingSummary.Controls.SetChildIndex(tblBillingSummary, 1);
            pnlBillingSummary.Controls.SetChildIndex(pnlBillingSummaryHeader, 2);
        }

        /// <summary>A small gap between the Tenant Information and Billing Summary cards.</summary>
        private void AddDetailsGap()
        {
            Panel cardGap = new Panel { Dock = DockStyle.Top, Height = 10 };
            pnlTenantDetails.Controls.Add(cardGap);

            // Order, highest index first: header, info, gap, then Billing fills the rest.
            pnlTenantDetails.Controls.SetChildIndex(pnlBillingSummary, 0);
            pnlTenantDetails.Controls.SetChildIndex(cardGap, 1);
            pnlTenantDetails.Controls.SetChildIndex(pnlTenantInfo, 2);
            pnlTenantDetails.Controls.SetChildIndex(pnlTenantDetailsHeader, 3);
        }

        /* =================================================================
           HELPERS
           ================================================================= */

        private static void StyleField(Label label, ContentAlignment alignment)
        {
            label.AutoSize = false;
            label.Dock = DockStyle.Fill;
            label.Margin = new Padding(0, 0, 0, 1);   // leaves room for the row line
            label.Font = new Font("Segoe UI", 10F);
            label.TextAlign = alignment;
            label.AutoEllipsis = true;                // long text ends with "..."
        }

        private static void DrawRowLine(object? sender, TableLayoutCellPaintEventArgs e)
        {
            using (Pen line = new Pen(UiTheme.Line))
            {
                e.Graphics.DrawLine(line, e.CellBounds.Left, e.CellBounds.Bottom - 1,
                                    e.CellBounds.Right, e.CellBounds.Bottom - 1);
            }
        }
    }
}
