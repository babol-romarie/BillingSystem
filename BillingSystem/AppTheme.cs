using DocumentFormat.OpenXml.Office2013.Drawing.ChartStyle;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BillingSystem   // keep YOUR project's namespace
{
    public static class AppTheme
    {
        public static bool IsDark = false;

        // ---------- Colors (all built-in named colors) ----------
        public static Color FormBack => IsDark ? Color.Black : Color.WhiteSmoke;
        public static Color Surface => IsDark ? Color.DarkSlateGray : Color.White;
        public static Color RowAlt => IsDark ? Color.DimGray : Color.GhostWhite;
        public static Color TextColor => IsDark ? Color.White : Color.Black;
        public static Color TextMuted => IsDark ? Color.Gainsboro : Color.DimGray;
        public static Color Header => IsDark ? Color.Gainsboro : Color.MidnightBlue;
        public static Color HeaderText => IsDark ? Color.Black : Color.White;
        public static Color Line => IsDark ? Color.DimGray : Color.Gainsboro;
        public static Color Select => Color.RoyalBlue;
        public static Color Primary => IsDark ? Color.RoyalBlue : Color.MidnightBlue;
        public static Color Danger => Color.Firebrick;
        public static Color Success => Color.DarkGreen;

        // ---------- Fonts (3 sizes = clear hierarchy) ----------
        public static Font Title = new Font("Segoe UI", 14f, FontStyle.Bold);
        public static Font Body = new Font("Segoe UI", 9f, FontStyle.Regular);
        public static Font Bold = new Font("Segoe UI", 9f, FontStyle.Bold);

        // ---------- Switch light/dark for every open form ----------
        public static void SetDark(bool dark)
        {
            IsDark = dark;
            foreach (Form f in Application.OpenForms) Apply(f);
        }

        // ---------- Call this once in each form ----------
        public static void Apply(Control root)
        {
            if (root is Form)
            {
                root.BackColor = FormBack;
                root.ForeColor = TextColor;
                root.Font = Body;
            }

            foreach (Control c in root.Controls)
            {
                StyleControl(c);
                if (c.HasChildren) Apply(c);
            }
        }

        private static void StyleControl(Control c)
        {
            if (c is Label lbl)
            {
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = TextColor;
                lbl.Font = lbl.Font.Size >= 12 ? Title : Body;  // big labels = titles
            }
            else if (c is Button btn) StyleButton(btn);
            else if (c is TextBox tb)
            {
                tb.BackColor = Surface; tb.ForeColor = TextColor;
                tb.BorderStyle = BorderStyle.FixedSingle; tb.Font = Body;
            }
            else if (c is ComboBox cb)
            {
                cb.BackColor = Surface; cb.ForeColor = TextColor;
                cb.FlatStyle = FlatStyle.Flat; cb.Font = Body;
            }
            else if (c is DateTimePicker dtp)
            {
                dtp.CalendarMonthBackground = Surface;
                dtp.CalendarForeColor = TextColor;
                dtp.Font = Body;
            }
            else if (c is CheckBox chk)
            {
                chk.BackColor = Color.Transparent; chk.ForeColor = TextColor; chk.Font = Body;
            }
            else if (c is DataGridView dgv) StyleGrid(dgv);
            else if (c is StatusStrip ss)
            {
                ss.BackColor = Surface;
                foreach (ToolStripItem item in ss.Items) item.ForeColor = TextMuted;
            }
            else if (c is Panel || c is GroupBox)
            {
                c.BackColor = FormBack; c.ForeColor = TextColor;
            }
        }

        private static void StyleButton(Button b)
        {
            string t = (b.Text ?? "").Trim().ToLower();

            string[] primary = { "save", "login", "search", "view billing", "change password", "save password", "save permissions" };
            string[] accent = { "export to excel", "export to pdf", "analytics", "audit log", "cancel", "clear", "close", "close", "close", "close", "cancel" };
            string[] danger = { "delete", "manage permissions", "logout" };

            Color back, fore, border;
            if (Array.IndexOf(danger, t) >= 0) { back = Danger; fore = Color.White; border = Danger; }
            else if (t == "add customer") { back = Success; fore = Color.White; border = Success; }
            else if (Array.IndexOf(primary, t) >= 0) { back = Primary; fore = Color.White; border = Primary; }
            else if (Array.IndexOf(accent, t) >= 0) { back = Color.SteelBlue; fore = Color.White; border = Color.SteelBlue; }
            else
            {
                // Cancel, Back, Clear, Close, Change Password
                back = IsDark ? Color.DarkSlateGray : Color.White;
                fore = IsDark ? Color.White : Color.Black;
                border = IsDark ? Color.DimGray : Color.Gray;
            }

            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = border;
            b.BackColor = back;
            b.ForeColor = fore;
            b.Font = Body;
            b.Cursor = Cursors.Hand;
        }

        private static void StyleGrid(DataGridView g)
        {
            g.EnableHeadersVisualStyles = false;
            g.BorderStyle = BorderStyle.None;
            g.BackgroundColor = FormBack;          // the empty area under the rows
            g.GridColor = Line;
            g.RowHeadersVisible = false;           // cleaner, minimalist look

            g.ColumnHeadersDefaultCellStyle.BackColor = Header;
            g.ColumnHeadersDefaultCellStyle.ForeColor = HeaderText;
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = Header;
            g.ColumnHeadersDefaultCellStyle.SelectionForeColor = HeaderText;
            g.ColumnHeadersDefaultCellStyle.Font = Bold;

            g.DefaultCellStyle.BackColor = Surface;
            g.DefaultCellStyle.ForeColor = TextColor;
            g.DefaultCellStyle.SelectionBackColor = Select;
            g.DefaultCellStyle.SelectionForeColor = Color.White;
            g.DefaultCellStyle.Font = Body;

            g.AlternatingRowsDefaultCellStyle.BackColor = RowAlt;
            g.AlternatingRowsDefaultCellStyle.ForeColor = TextColor;
            g.AlternatingRowsDefaultCellStyle.SelectionBackColor = Select;
            g.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
        }
    }
}