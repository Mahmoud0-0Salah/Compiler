using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Label titleLabel = new Label();
            titleLabel.Text = "Compiler";
            titleLabel.Font = new Font("Arial", 24, FontStyle.Bold);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Height = 50;

            this.Controls.Add(titleLabel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Tokens = new[] {
                ("KEYWORD", @"^(if|else|for|int|float|double|while|do|return)$"),
                ("ID", @"^[A-Za-z_](\w)*$"),
                ("NUM", @"^(-|\+)?(\d+)(\.(\d+))?([eE][-\+]?\d+)?$"),
                ("DELIMITER", @"[();{}\[\]]"),
                ("OP", @"(\+|/|-|\*|=|<|>|<=|>=|\||&|\^)")
            };
            var input = txt1.Text;
            input = Regex.Replace(input, $@"{Tokens[3].Item2}", match => $" {match.Value} ");
            string[] result = Regex.Split(input, @"\s+");

            txt2.Clear();  
            foreach (string s in result)
            {
                foreach (var token in Tokens)
                {
                    if (Regex.IsMatch(s, token.Item2))
                    {
                        txt2.AppendText($"{s} => {token.Item1}{Environment.NewLine}");
                        break;
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
