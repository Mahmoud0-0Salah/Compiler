using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Token> tokens;
        public TextBox Txt1 => txt1;
        public TextBox Txt2 => txt2;

        private bool isDarkMode = true;
        public Form1()
        {
            InitializeComponent();

            Label titleLabel = new Label();
            titleLabel.Text = "Compiler";
            titleLabel.Font = new Font("Arial", 24, FontStyle.Bold);
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Height = 50;
            titleLabel.ForeColor = Color.White;


            this.Controls.Add(titleLabel);
        }
        private void TokenizeInput(string inputText,bool Scan = false)
        {
            var TokensDefinitions = new[] {
            ("BOOLEAN", @"^(صح|خطأ)$"),
            ("LOOP", @"^(طالما|من)$"),
            ("RANGE", @"^(الي)$"),
            ("PRINT", @"^(اطبع)$"),
            ("DATATYPE", @"^(صحيح|عائم|مزدوج|كلمة|متغير)$"),
            ("else_stmt", @"^(اخر)$"),
            ("if_stmt", @"^(اذا)$"),
            ("return", @"^(ارجع)$"),
            ("IN", @"في"),
            ("ID", @"(^[\u0600-\u06FF_][\w]*$)|(^[A-Za-z_][\w]*$)"),
            ("NUM", @"^(-|\+)?(\d+)(\.(\d+))?([eE][-\+]?\d+)?$"),
            ("SEMICOLON", @";"), //10
            ("(", @"\("),
            (")", @"\)"),
            ("{", @"{"),
            ("}", @"}"),
            ("[", @"\["),
            ("]", @"\]"),
            ("BITSOP", @"(\||&)"),
            ("COMPARISONOP", @"(<|>|<=|>=|==|\!=)"),
            ("ASSIGNOP", @"^(=)"),
            ("MATHOP", @"(\+|/|-|\*|\^|%)"),
            ("COMMA", @"(,)")
            };

            inputText = Regex.Replace(inputText, @"//.*$", string.Empty, RegexOptions.Multiline);

            var input = Regex.Replace(inputText, $@"{TokensDefinitions[17].Item2}", match => $" {match.Value} ");
            input = Regex.Replace(input, $@"{TokensDefinitions[11].Item2}", match => $" {match.Value} ");
            input = Regex.Replace(input, $@"{TokensDefinitions[12].Item2}", match => $" {match.Value} ");
            input = Regex.Replace(input, $@"{TokensDefinitions[13].Item2}", match => $" {match.Value} ");
            input = Regex.Replace(input, $@"{TokensDefinitions[14].Item2}", match => $" {match.Value} ");
            input = Regex.Replace(input, $@"{TokensDefinitions[15].Item2}", match => $" {match.Value} ");
            input = Regex.Replace(input, $@"{TokensDefinitions[16].Item2}", match => $" {match.Value} ");
            string[] result = Regex.Split(input, @"\s+");

            tokens = new List<Token>();
            if (Scan)
                textBox1.Clear();

            foreach (string s in result)
            {
                bool found = false;
                if (s == "")
                    continue;
                foreach (var tokenDef in TokensDefinitions)
                {
                    if (Regex.IsMatch(s, tokenDef.Item2))
                    {
                        found = true;
                        tokens.Add(new Token { Type = tokenDef.Item1, Value = s });
                        if (Scan)
                            textBox1.AppendText($"{s} => {tokenDef.Item1}{Environment.NewLine}");
                        break;
                    }
                }
                if (!found)
                    tokens.Add(new Token { Type = "Unknown", Value = s });
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TokenizeInput(txt1.Text,true);
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
            TokenizeInput(txt1.Text);
            txt2.Clear();
            var parser = new Parser(tokens);
            var (errors, rulesCalled) = parser.Parse();
            txt2.AppendText("Parser Output:" + Environment.NewLine);
            if (errors.Count > 0)
            {
                txt2.AppendText("Errors:" + Environment.NewLine);
                foreach (var error in errors)
                {
                    txt2.AppendText(error + Environment.NewLine);
                }
            }
            else
            {
                txt2.AppendText("Parsing successful! Rules called:" + Environment.NewLine);
                foreach (var rule in rulesCalled)
                {
                    txt2.AppendText(rule + Environment.NewLine);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (isDarkMode)
            {
                this.BackColor = System.Drawing.Color.FromArgb(122, 178, 211);
                this.ForeColor = System.Drawing.Color.Black;

                foreach (Control control in this.Controls)
                {
                    if (control is Button button)
                    {
                        button.BackColor = System.Drawing.Color.FromArgb(185, 229, 232);
                        button.ForeColor = System.Drawing.Color.Black;
                    }
                    else if (control is TextBox textBox)
                    {
                        textBox.BackColor = System.Drawing.Color.FromArgb(223, 242, 235);
                        textBox.ForeColor = System.Drawing.Color.Black;
                    }
                    else if (control is Label label)
                    {
                        label.ForeColor = System.Drawing.Color.Black;
                    }
                }

                button3.Text = "Switch to Dark Mode";
                isDarkMode = false;
            }
            else
            {
                this.BackColor = System.Drawing.Color.FromArgb(29, 62, 83);
                this.ForeColor = System.Drawing.Color.White;

                foreach (Control control in this.Controls)
                {
                    if (control is Button button)
                    {
                        button.BackColor = System.Drawing.Color.FromArgb(71, 109, 124);
                        button.ForeColor = System.Drawing.Color.White;
                    }
                    else if (control is TextBox textBox)
                    {
                        textBox.BackColor = System.Drawing.Color.FromArgb(71, 109, 124);
                        textBox.ForeColor = System.Drawing.Color.White;
                    }
                    else if (control is Label label)
                    {
                        label.ForeColor = System.Drawing.Color.White;
                    }
                }

                button3.Text = "Switch to Light  Mode";
                isDarkMode = true;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }
    }
}
