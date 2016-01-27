using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Formatter.Parser;
using Formatter.utilities;

namespace Formatter
{
    public partial class SqlFormatter : Form
    {
        public SqlFormatter()
        {
            InitializeComponent();
            cmdQueryType.DataSource = Enum.GetNames(typeof(QueryTypes));
            cmdQueryType.SelectedIndex = 0;
        }

        private void btnFormat_Click(object sender, EventArgs e)
        {
            String queryType = (string)cmdQueryType.SelectedValue;
            FormatterFactory formatterFactory = new FormatterFactory();
            ISqlFormatter formatter = formatterFactory.GetFormatter(queryType);
            txtFormat.Text = formatter.FormatQuery(txtUnformatted.Text);
        }
    }
}
