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
            TrackFunction(DeclarationList, nameof(Program));
        }

        private void DeclarationList()
        {
            while (!currentToken.IsToken("EOF"))
            {
                Declaration();
            }
        }

        private void Declaration()
        {
            if (currentToken.IsToken("KEYWORD"))
            {
                Match("KEYWORD");
                Match("ID");
                if (currentToken.IsToken("("))
                {
                    FunDeclaration();
                }
                else
                {
                    VarDeclaration();
                }
            }
            else
            {
                errors.Add($"Error: Expected keyword but found {currentToken.Value}");
                Consume();
            }
        }

        private void VarDeclaration()
        {
            if (currentToken.IsToken("="))
            {
                Match("=");
                Match("NUM");
            }
            else if (currentToken.IsToken("["))
            {
                Match("[");
                Match("NUM");
                Match("]");
            }
            Match("DELIMITER");
        }

        private void FunDeclaration()
        {
            Match("(");
            Params();
            Match(")");
            CompoundStmt();
        }

        private void Params() { /* Implementation for parsing function parameters */ }
        private void CompoundStmt() { /* Implementation for parsing compound statements */ }
    }
}
