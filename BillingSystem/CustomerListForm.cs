using System;
using System.Linq;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BillingSystem.Database;
namespace BillingSystem;
using ClosedXML.Excel;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Drawing;






public partial class CustomerListForm : Form
{
    public CustomerListForm() { InitializeComponent(); }
    private void lblTitle_Click(object sender, EventArgs e) { }
    private void CustomerListForm_Load(object sender, EventArgs e) { LoadCustomers(); }

    private void LoadCustomers()
    {
        try
        {
            // Hanapin si dgvCustomers kahit saan siya nakalagay sa form
            DataGridView grid = dgvCustomers;
            if (grid == null)
            {
                grid = this.Controls.Find("dgvCustomers", true).FirstOrDefault() as DataGridView;
            }
            if (grid == null)
            {
                // Kung wala talaga, hanapin kahit anong DataGridView sa form
                foreach (Control c in this.Controls)
                {
                    if (c is DataGridView) { grid = (DataGridView)c; break; }
                }
            }

            if (grid == null)
            {
                MessageBox.Show("There's no DataGridView in the form. Save the Design again.", "Designer Error");
                return;
            }

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT CustomerID, FullName, Address, ContactNumber, Email, Status, Balance FROM Customers";
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    grid.AutoGenerateColumns = true;
                    grid.DataSource = dt;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), "REAL ERROR");
        }
    }

    // Stores the CustomerID of the currently selected row.
    // 0 means no customer is currently selected.
    private int _selectedCustomerId = 0;






    private void SearchCustomers(string keyword)
    {
        try
        {
            var grid = this.Controls.Find("dgvCustomers", true).FirstOrDefault() as DataGridView;
            if (grid == null) grid = dgvCustomers;

            var txtBox = this.Controls.Find("txtSearch", true).FirstOrDefault() as TextBox;
            string finalKeyword = keyword;
            if (txtBox != null && !string.IsNullOrWhiteSpace(txtBox.Text))
            {
                finalKeyword = txtBox.Text.Trim();
            }

            if (grid == null) return;

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "SELECT CustomerID, FullName, Address, ContactNumber, Email, Status, Balance FROM Customers";
                if (!string.IsNullOrEmpty(finalKeyword))
                {
                    sql += " WHERE FullName LIKE @key OR ContactNumber LIKE @key OR Email LIKE @key";
                }

                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    if (!string.IsNullOrEmpty(finalKeyword))
                    {
                        cmd.Parameters.AddWithValue("@key", "%" + finalKeyword + "%");
                    }
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    grid.DataSource = dt;
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Search Error: " + ex.Message);
        }
    }



    private void btnSearch_Click(object sender, EventArgs e)
    {
        SearchCustomers(txtSearch.Text.Trim());
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        AddCustomerForm addCustomerForm = new AddCustomerForm();
        addCustomerForm.ShowDialog();
        LoadCustomers();
    }

    private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
    {

    }

    private void txtSearch_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {

            SearchCustomers(txtSearch.Text.Trim());
            e.SuppressKeyPress = true; // para hindi tumunog
        }
    }



    private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
    {
        // If no row is selected (e.g., grid is empty), do nothing
        if (dgvCustomers == null) return;
        if (dgvCustomers.CurrentRow == null) return;
        // Read the CustomerID value from the selected row
        var idCell = dgvCustomers.CurrentRow.Cells["CustomerID"].Value;

        if (idCell != null && int.TryParse(idCell.ToString(), out int id))
        {
            _selectedCustomerId = id;
        }
    }


    private void dgvCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;

        var grid = sender as DataGridView;
        if (grid == null) return;

        DataGridViewRow row = grid.Rows[e.RowIndex];
        if (row.Cells["CustomerID"].Value == null) return;

        int customerId = Convert.ToInt32(row.Cells["CustomerID"].Value);

        // tawagin na yung edit form mo
        OpenEditForm(customerId);
    }





    private void OpenEditForm(int customerId)
    {
        if (customerId == 0)
        {
            MessageBox.Show("Please select a customer to edit.",
                "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Open AddCustomerForm in EDIT mode, passing the selected CustomerID
        AddCustomerForm editForm = new AddCustomerForm(customerId);

        // Refresh the grid automatically once the edit form closes
        editForm.FormClosed += (s, args) => LoadCustomers();

        editForm.ShowDialog(this);
    }


    private void DeleteCustomer(int customerId)
    {
        try
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string sql = "DELETE FROM Customers WHERE CustomerID = @CustomerID;";
                using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCustomers();
                        _selectedCustomerId = 0;
                    }
                    else
                    {
                        MessageBox.Show("Customer could not be deleted. It may no longer exist.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting customer:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        // 1. Kunin yung current row - ito lang gagawin dito
        var row = dgvCustomers.CurrentRow;

        if (row == null || row.IsNewRow || row.Cells["CustomerID"].Value == null)
        {
            MessageBox.Show("Please select a customer to delete.");
            return;
        }

        int id = Convert.ToInt32(row.Cells["CustomerID"].Value);
        string name = row.Cells["FullName"].Value?.ToString() ?? "this customer";

        DialogResult ask = MessageBox.Show($"Delete {name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        if (ask != DialogResult.Yes) return;

        // 2. Tawagin yung isang delete method lang - wag na mag double code
        DeleteCustomer(id);
    }


    private void btnExportExcel_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Button clicked!");
        DataGridView grid = null;

        foreach (Control c in this.Controls)
        {
            if (c is DataGridView) { grid = c as DataGridView; break; }
            foreach (Control child in c.Controls)
            {
                if (child is DataGridView) { grid = child as DataGridView; break; }
            }
        }

        if (grid == null || grid.DataSource == null)
        {
            MessageBox.Show("There's no grid or data available for export!", "Error");
            return;
        }

        DataTable dt = null;
        if (grid.DataSource is DataTable t) dt = t;
        else if (grid.DataSource is DataView v) dt = v.ToTable();
        else if (grid.DataSource is BindingSource bs && bs.DataSource is DataTable bt) dt = bt;

        if (dt == null || dt.Rows.Count == 0)
        {
            MessageBox.Show("There are no records to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using (SaveFileDialog save = new SaveFileDialog())
        {
            save.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            save.FileName = "CustomerList.xlsx";
            if (save.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (var workbook = new ClosedXML.Excel.XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("Customers");
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        ws.Cell(1, col + 1).Value = dt.Columns[col].ColumnName;
                        ws.Cell(1, col + 1).Style.Font.Bold = true;
                    }
                    for (int r = 0; r < dt.Rows.Count; r++)
                    {
                        for (int c = 0; c < dt.Columns.Count; c++)
                        {
                            ws.Cell(r + 2, c + 1).Value = dt.Rows[r][c]?.ToString() ?? "";
                        }
                    }
                    ws.Columns().AdjustToContents();
                    workbook.SaveAs(save.FileName);
                }
                MessageBox.Show($" Export was successful! {dt.Rows.Count} records", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Export Error");
            }
        }


    }

    private void btnExportPdf_Click(object sender, EventArgs e)
    {
        DataGridView grid = null;

      
        foreach (Control c in this.Controls)
        {
            if (c is DataGridView) { grid = c as DataGridView; break; }
            foreach (Control child in c.Controls)
            {
                if (child is DataGridView) { grid = child as DataGridView; break; }
            }
        }
        if (grid == null) grid = dgvCustomers; 

        if (grid == null || grid.DataSource == null)
        {
            MessageBox.Show("There is no grid or data available for export.", "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DataTable dt = null;
        if (grid.DataSource is DataTable t) dt = t;
        else if (grid.DataSource is DataView v) dt = v.ToTable();
        else if (grid.DataSource is BindingSource bs && bs.DataSource is DataTable bt) dt = bt;

        if (dt == null || dt.Rows.Count == 0)
        {
            MessageBox.Show("There are no records to export.", "Export to PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using (SaveFileDialog saveDialog = new SaveFileDialog())
        {
            saveDialog.Filter = "PDF Document (*.pdf)|*.pdf";
            saveDialog.FileName = "CustomerList.pdf";
            if (saveDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument())
                {
                    PdfSharp.Pdf.PdfPage page = document.AddPage();
                    page.Orientation = PdfSharp.PageOrientation.Landscape;
                    PdfSharp.Drawing.XGraphics gfx = PdfSharp.Drawing.XGraphics.FromPdfPage(page);

                    PdfSharp.Drawing.XFont titleFont = new PdfSharp.Drawing.XFont("Arial", 16, PdfSharp.Drawing.XFontStyleEx.Bold);
                    PdfSharp.Drawing.XFont headerFont = new PdfSharp.Drawing.XFont("Arial", 10, PdfSharp.Drawing.XFontStyleEx.Bold);
                    PdfSharp.Drawing.XFont cellFont = new PdfSharp.Drawing.XFont("Arial", 9, PdfSharp.Drawing.XFontStyleEx.Regular);

                    double margin = 30;
                    double tableWidth = page.Width.Point - (margin * 2);
                    double colWidth = tableWidth / dt.Columns.Count;
                    double rowHeight = 22;
                    double y = 60;
                    double x;

                    // Title
                    gfx.DrawString("Customer List Report", titleFont, PdfSharp.Drawing.XBrushes.Black,
                        new PdfSharp.Drawing.XRect(0, 20, page.Width.Point, 30), PdfSharp.Drawing.XStringFormats.TopCenter);

                    // Header
                    x = margin;
                    for (int col = 0; col < dt.Columns.Count; col++)
                    {
                        gfx.DrawString(dt.Columns[col].ColumnName, headerFont, PdfSharp.Drawing.XBrushes.Black,
                            new PdfSharp.Drawing.XRect(x, y, colWidth, rowHeight), PdfSharp.Drawing.XStringFormats.CenterLeft);
                        x += colWidth;
                    }
                    y += rowHeight;
                    gfx.DrawLine(PdfSharp.Drawing.XPens.Black, margin, y, page.Width.Point - margin, y);

                    // Data rows from DataTable 
                    foreach (DataRow row in dt.Rows)
                    {
                        y += rowHeight;
                        if (y > page.Height.Point - margin)
                        {
                            gfx.Dispose();
                            page = document.AddPage();
                            page.Orientation = PdfSharp.PageOrientation.Landscape;
                            gfx = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
                            y = 40;
                        }

                        x = margin;
                        for (int col = 0; col < dt.Columns.Count; col++)
                        {
                            string text = row[col]?.ToString() ?? "";
                            
                            if (text.Length > 30) text = text.Substring(0, 27) + "...";
                            gfx.DrawString(text, cellFont, PdfSharp.Drawing.XBrushes.Black,
                                new PdfSharp.Drawing.XRect(x, y, colWidth, rowHeight), PdfSharp.Drawing.XStringFormats.CenterLeft);
                            x += colWidth;
                        }
                    }

                    gfx.Dispose();
                    document.Save(saveDialog.FileName);
                }

                MessageBox.Show($"Customer list exported to PDF! {dt.Rows.Count} records", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to PDF:\n{ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


}





