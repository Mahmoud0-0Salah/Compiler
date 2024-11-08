using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Parser
    {
        private List<Token> tokens;
        private Token currentToken;
        private int index;
        private List<string> errors;
        private List<string> rulesCalled;

        public Parser(List<Token> tokens)
        {
            this.tokens = tokens;
            this.currentToken = null;
            this.index = 0;
            this.errors = new List<string>();
            this.rulesCalled = new List<string>();
        }

        private void TrackFunction(Action function, string functionName)
        {
            rulesCalled.Add(functionName);
            function.Invoke();
        }

        private void Match(string tokenType)
        {
            if (currentToken != null && currentToken.IsToken(tokenType))
            {
                Consume();
            }
            else
            {
                Error(currentToken, tokenType);
            }
        }

        private void Consume()
        {
            index++;
            if (index < tokens.Count)
            {
                currentToken = tokens[index];
            }
            else
            {
                currentToken = new Token { Type = "EOF", Value = "" };
            }
        }

        private void Error(Token foundToken = null, string expectedType = null)
        {
            if (foundToken != null && expectedType != null)
            {
                errors.Add($"Error: Expected {expectedType} but found {foundToken}");
            }
            else
            {
                errors.Add("Error: Invalid syntax");
            }
        }

        public (List<string> Errors, List<string> RulesCalled) Parse()
        {
            if (tokens.Count == 0)
            {
                errors.Add("Error: No tokens to parse");
                return (errors, rulesCalled);
            }
            currentToken = tokens[0];
            Program();
            return (errors, rulesCalled);
        }

        private void Program()
        {
            while (!currentToken.IsToken("EOF"))
            {
                if (currentToken.IsToken("DATATYPE"))
                     TrackFunction(Declaration, nameof(Declaration));
                else
                {
                    errors.Add($"Unexpected error");
                    Consume();
                }
            }
        }

        private void Declaration()
        {
            if (currentToken.IsToken("DATATYPE"))
            {
                Match("DATATYPE");
                Match("ID");
                if (currentToken.IsToken("PARENTHESES"))
                {
                    FunDeclaration();
                }
                else if (currentToken.IsToken("ASSIGNOP"))
                {
                    VarDeclaration();
                }
                else
                {
                    errors.Add($"Unexpected error");
                    Consume();
                }
            }
            else
            {
                errors.Add($"Unexpected error");
                Consume();
            }
        }

        private void VarDeclaration()
        {
            if (currentToken.IsToken("ASSIGNOP"))
            {
                Match("ASSIGNOP");
                Exp();
            }
            else if (currentToken.IsToken("SQUARE"))
            {
                Match("SQUARE");
                Match("NUM");
                Match("SQUARE");
            }
            Match("SEMICOLON");
        }

        private void FunDeclaration()
        {
            Match("PARENTHESES");
            Params();
            Match("PARENTHESES");
            Match("COLON");
        }

        private void Params() {

            while (true)
            {
                Match("DATATYPE");
                Match("ID");
                if (currentToken.IsToken("PARENTHESES"))
                    break;
                else
                    Match("COMMA");
            }
        }
        private void Exp()
        {

            while (true)
            {
                if (currentToken.IsToken("ID"))
                    Match("ID");
                else
                    Match("NUM");

                if (currentToken.IsToken("MATHOP"))
                    Match("MATHOP");
                else
                    break;
            }
        }


    }
}
