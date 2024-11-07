﻿using System.Text.RegularExpressions;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Token> tokens;

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
        private void TokenizeInput(string inputText)
        {
            var TokensDefinitions = new[] {
            ("BOOLEAN", @"^(صح|خطأ)$"),
            ("LOOP", @"^(من|الي|طالما|افعل)$"),
            ("DATATYPE", @"^(صحيح|عائم|مزدوج|كلمة)$"),
            ("else_stmt", @"^(اخر)$"),
            ("if_stmt", @"^(اذا)$"),
            ("return", @"^(ارجع)$"),
            ("ID", @"^[\u0600-\u06FF_](\w)*$"),
            ("NUM", @"^(-|\+)?(\d+)(\.(\d+))?([eE][-\+]?\d+)?$"),
            ("SEMICOLON", @";"),
            ("PARENTHESES", @"[()]"),
            ("CURLY", @"[{}]"),
            ("SQUARE", @"[\[\]]"),
            ("BITSOP", @"(\||&)"),
            ("ASSIGNOP", @"^(=)"),
            ("MATHOP", @"(\+|/|-|\*|\^)"),
            ("COMPARISONOP", @"(<|>|<=|>=|==|\!=)")
            };

            var input = Regex.Replace(inputText, $@"{TokensDefinitions[3].Item2}", match => $" {match.Value} ");
            input = Regex.Replace(input, $@"{TokensDefinitions[5].Item2}", match => $" {match.Value} ");
            string[] result = Regex.Split(input, @"\s+");

            tokens = new List<Token>();
            txt2.Clear();

            foreach (string s in result)
            {
                foreach (var tokenDef in TokensDefinitions)
                {
                    if (Regex.IsMatch(s, tokenDef.Item2))
                    {
                        tokens.Add(new Token { Type = tokenDef.Item1, Value = s });
                        txt2.AppendText($"{s} => {tokenDef.Item1}{Environment.NewLine}");
                        break;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TokenizeInput(txt1.Text);
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
